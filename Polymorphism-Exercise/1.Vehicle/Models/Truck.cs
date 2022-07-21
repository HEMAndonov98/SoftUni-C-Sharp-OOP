using System;
namespace Vehicle.Models
{
    public class Truck : Vehicle
    {
        private const double refuelCoefficient = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption)
            :base(fuelQuantity, fuelConsumption)
        {
            base.fuelCoefficient = 1.6;
            base.FuelConsumption = fuelConsumption;
        }

        public override void Refuel(double amount)
        {
            base.Refuel(amount * refuelCoefficient);
        }
    }
}

