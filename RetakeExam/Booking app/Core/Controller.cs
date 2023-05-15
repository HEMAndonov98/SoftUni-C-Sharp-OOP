namespace BookingApp.Core
{

    using System;
    using System.Linq;
    using Contracts;
    using Repositories;
    using Models.Hotels.Contacts;
    using Models.Hotels;
    using Models.Rooms.Contracts;
    using Models.Rooms;
    using Models.Bookings;
    using Utilities.Messages;
    using System.Text;

    public class Controller : IController
    {
        private readonly HotelRepository hotelRepository;

        public Controller()
        {
            this.hotelRepository = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = this.hotelRepository.Select(hotelName);

            if (hotel != null)
            {
                return $"Hotel {hotelName} is already registered in our platform.";
            }

            hotel = new Hotel(hotelName, category);
            this.hotelRepository.AddNew(hotel);
            return $"{category} stars hotel {hotelName} is registered in our platform and expects room availability to be uploaded.";
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            var availableHotels = this.hotelRepository.All()
                .Where(h => h.Category == category)
                .ToList();


            if (availableHotels.Count <= 0)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

            var hotelsOrdered = availableHotels
                .OrderBy(h => h.FullName)
                .ToList();

            foreach (var hotel in hotelsOrdered)
            {
                var availableRooms = hotel.Rooms.All()
                    .Where(r => r.PricePerNight > 0)
                    .ToList();

                var roomsOrdered = availableRooms.OrderBy(r => r.BedCapacity)
                    .ToList();

                var totalGuests = adults + children;

                foreach (var room in roomsOrdered)
                {
                    if (room.BedCapacity >= totalGuests)
                    {
                        var bookingNumber = hotel.Bookings.All().Count + 1;
                        hotel.Bookings.AddNew(new Booking(room, duration, adults, children, bookingNumber));
                        return string.Format(OutputMessages.BookingSuccessful, bookingNumber, hotel.FullName);
                    }
                }
            }

            return OutputMessages.RoomNotAppropriate;
        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = this.hotelRepository.Select(hotelName);

            if (hotel == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            var reportSb = new StringBuilder();

            reportSb.AppendLine($"Hotel name: {hotelName}");
            reportSb.AppendLine($"--{hotel.Category} star hotel");
            reportSb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            reportSb.AppendLine("--Bookings:");
            if (hotel.Bookings.All().Count <= 0)
            {
                reportSb.AppendLine(Environment.NewLine);
                reportSb.AppendLine("none");
                return reportSb.ToString().Trim();
            }

            foreach (var booking in hotel.Bookings.All())
            {
                reportSb.AppendLine(Environment.NewLine);
                reportSb.AppendLine(booking.BookingSummary());
            }

            return reportSb.ToString().Trim();

        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = this.hotelRepository.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            var isValidRoomType = roomTypeName switch
            {
                nameof(DoubleBed) => true,
                nameof(Studio) => true,
                nameof(Apartment) => true,
                _ => false
            };

            if (isValidRoomType == false)
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);

            if (room == null)
            {
                return OutputMessages.RoomTypeNotCreated;
            }

            if (room.PricePerNight != 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }

            room.SetPrice(price);
            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);

        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = this.hotelRepository.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }


            IRoom room = hotel.Rooms.Select(roomTypeName);

            if (room != null)
            {
                return OutputMessages.RoomTypeAlreadyCreated;
            }
            

            room = roomTypeName switch
            {
                nameof(DoubleBed) => new DoubleBed(),
                nameof(Studio) => new Studio(),
                nameof(Apartment) => new Apartment(),
                _ => throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect)
            };

            hotel.Rooms.AddNew(room);
            return string.Format(OutputMessages.RoomTypeAdded, room.GetType().Name, hotelName);
        }
    }
}

