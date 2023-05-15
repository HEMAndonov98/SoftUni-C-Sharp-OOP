using System;

namespace BookingApp.Models.Hotels
{

    using System;
    using Contacts;
    using System.Linq;
    using Rooms.Contracts;
    using Bookings.Contracts;
    using Repositories.Contracts;
    using Repositories;
    using Utilities.Messages;

    public class Hotel : IHotel
    {
        private string fullName;
        private int category;

        public Hotel(string fullName, int category)
        {
            this.FullName = fullName;
            this.Category = category;
            this.Rooms = new RoomRepository();
            this.Bookings = new BookingRepository();
        }

        public string FullName
        {
            get { return this.fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                }

                this.fullName = value;
            }
        }

        public int Category
        {
            get { return this.category; }
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }
                this.category = value;
            }
        }

        public double Turnover { get
            {
                return this.Bookings.All().Select(b => Math.Round(b.ResidenceDuration * b.Room.PricePerNight, 2)).Sum();
            } }

        public IRepository<IRoom> Rooms { get; set; }
        public IRepository<IBooking> Bookings { get; set; }

    }
}