namespace BookingApp.Models.Bookings
{
    using System;
    using System.Text;
    using Contracts;
    using Rooms.Contracts;
    using Utilities.Messages;

    public class Booking : IBooking
    {
        private int residanceDuration;
        private int adultCount;
        private int childCount;

        public Booking(IRoom room, int residanceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            this.Room = room;
            this.ResidenceDuration = residanceDuration;
            this.AdultsCount = adultsCount;
            this.ChildrenCount = childrenCount;
            this.BookingNumber = bookingNumber;
        }

        public IRoom Room { get; private set; }

        public int ResidenceDuration
        {
            get { return this.residanceDuration; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }
                this.residanceDuration = value;
            }
        }

        public int AdultsCount
        {
            get { return this.adultCount; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }

                this.adultCount = value;
            }
        }

        public int ChildrenCount
        {
            get { return this.childCount; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }

                this.childCount = value;
            }
        }

        public int BookingNumber { get; private set; }

        public string BookingSummary()
        {
            var summarySb = new StringBuilder();
            summarySb.AppendLine($"Booking number: {this.BookingNumber}");
            summarySb.AppendLine($"Room type: {this.Room.GetType().Name}");
            summarySb.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
            summarySb.AppendLine($"Total amount paid: {TotalPaid():F2} $");

            return summarySb.ToString().Trim();
        }

        private double TotalPaid()
        {
            var total = Math.Round(this.ResidenceDuration * this.Room.PricePerNight, 2);

            return total;
        }
    }
}

