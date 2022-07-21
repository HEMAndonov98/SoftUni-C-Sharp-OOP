using System;
using System.Runtime.InteropServices;

namespace Vehicle.Models
{
    public class Bus : Vehicle
    {
        private const double AcModifier = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            :base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            base.fuelCoefficient = AcModifier;
            base.FuelConsumption = fuelConsumption;
        }

        public override string DriveEmpty(double distance)
        {
            double fuelNeeded = (this.FuelConsumption - AcModifier) * distance;
            if (fuelNeeded < this.FuelQuantity)
            {
                //enough fuel
                this.FuelQuantity -= fuelNeeded;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                //not enough fuel
                return $"{this.GetType().Name} needs refueling";
            }
        }
    }
}

