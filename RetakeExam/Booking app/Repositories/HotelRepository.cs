namespace BookingApp.Repositories
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Hotels.Contacts;

    public class HotelRepository : IRepository<IHotel>
    {
        private readonly List<IHotel> data;

        public HotelRepository()
        {
            this.data = new List<IHotel>();
        }

        public void AddNew(IHotel model)
        {
            this.data.Add(model);
        }

        public IReadOnlyCollection<IHotel> All()
            => this.data;

        public IHotel Select(string criteria)
            => this.data.FirstOrDefault(h => h.FullName == criteria);
    }
}

