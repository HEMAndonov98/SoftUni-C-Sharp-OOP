using System;
namespace Vehicle.Models.Interfaces
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        double TankCapacity { get; }

        public string Drive(double distance);
        public void Refuel(double amount);
    }
}

