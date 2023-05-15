namespace BookingApp.Repositories
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Bookings.Contracts;

    public class BookingRepository : IRepository<IBooking>
    {
        private readonly List<IBooking> data;

        public BookingRepository()
        {
            this.data = new List<IBooking>();
        }

        public void AddNew(IBooking model)
        {
            this.data.Add(model);
        }

        public IReadOnlyCollection<IBooking> All()
            => this.data;

        public IBooking Select(string criteria)
            => this.data.FirstOrDefault(b => b.BookingNumber == int.Parse(criteria));
    }
}

