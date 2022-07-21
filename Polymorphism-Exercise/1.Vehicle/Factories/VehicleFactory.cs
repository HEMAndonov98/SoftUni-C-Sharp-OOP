using System;
using Vehicle.Factories.Interfaces;
using Vehicle.Models;
using Vehicle.Models.Interfaces;

namespace Vehicle.Factories
{
    public class VehicleFactory : IFactory
    {
        public IVehicle CreateVehicle(string[] vehicleArgs)
        {
            double fuelQuantity = double.Parse(vehicleArgs[1]);
            double fuelConsumption = double.Parse(vehicleArgs[2]);

            if (vehicleArgs[0] == "Car")
            {
                return new Car(fuelQuantity, fuelConsumption);
            }
            else if (vehicleArgs[0] == "Truck")
            {
                return new Truck(fuelQuantity, fuelConsumption);
            }

            throw new ArgumentException("Vehicle type should only be of type Car/Truck");
        }
    }
}

