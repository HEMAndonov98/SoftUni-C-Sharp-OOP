using System;
using Vehicle.Models.Interfaces;

namespace Vehicle.Factories.Interfaces
{
    public interface IFactory
    {
        public IVehicle CreateVehicle(string[] vehicleArgs);
    }
}

