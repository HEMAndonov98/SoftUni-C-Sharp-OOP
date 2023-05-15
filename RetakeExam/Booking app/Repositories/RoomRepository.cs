
namespace BookingApp.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Rooms.Contracts;
    public class RoomRepository : IRepository<IRoom>
    {
        private readonly List<IRoom> data;

        public RoomRepository()
        {
            this.data = new List<IRoom>();
        }

        public void AddNew(IRoom model)
        {
            this.data.Add(model);
        }

        public IReadOnlyCollection<IRoom> All()
            => this.data;

        public IRoom Select(string criteria)
            => this.data.FirstOrDefault(r => r.GetType().Name == criteria);
    }
}

