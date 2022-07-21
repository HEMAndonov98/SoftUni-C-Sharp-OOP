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
        }

        private bool IsEmpty { get; set; }

        public void SetStatus(string status)
        {
            if (status == "Drive")
            {
                this.IsEmpty = true;
            }
            else
            {
                this.IsEmpty = false;
            }
        }

        public override string Drive(double distance)
        {
            double fuelNeeded;
            if (IsEmpty == true)
            {
                return base.Drive(distance);
            }
            else
            {
                fuelNeeded = (this.FuelConsumption + AcModifier) * distance;
            }

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

