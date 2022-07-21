using System;
using Vehicle.Models.Interfaces;

namespace Vehicle.Models
{
    public class Vehicle : IVehicle
    {
        protected double fuelCoefficient;
        private double fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
            :this(fuelQuantity, fuelConsumption)
        {
            this.TankCapacity = tankCapacity;
        }

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; protected set; }

        public double FuelConsumption { get
            { return this.fuelConsumption; }
            protected set
            {
                this.fuelConsumption = value + this.fuelCoefficient;
            }
        }

        public double TankCapacity { get; protected set; }

        public virtual string Drive(double distance)
        {
            double fuelNeeded = this.FuelConsumption * distance;
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

        public virtual void Refuel(double amount)
        {
            this.FuelQuantity += amount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}

