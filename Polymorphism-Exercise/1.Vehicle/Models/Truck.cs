using System;
namespace Vehicle.Models
{
    public class Truck : Vehicle
    {
        private const double refuelCoefficient = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            :this(fuelQuantity, fuelConsumption)
        {
            this.TankCapacity = tankCapacity;
        }

        public Truck(double fuelQuantity, double fuelConsumption)
            :base(fuelQuantity, fuelConsumption)
        {
            base.fuelCoefficient = 1.6;
            base.FuelConsumption = fuelConsumption;
        }

        public override void Refuel(double amount)
        {
            if (this.FuelQuantity + amount > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }

            base.Refuel(amount * refuelCoefficient);
        }
    }
}

