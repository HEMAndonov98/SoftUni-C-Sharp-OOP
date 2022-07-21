using System;
using Vehicle.Models.Interfaces;

namespace Vehicle.Models
{
    public class Vehicle : IVehicle
    {
        private const double AcModifier = 1.4;

        protected double fuelCoefficient;
        private double fuelConsumption;
        private double tankCapacity;
        
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

        public double TankCapacity {
            get
            {
                return this.tankCapacity;
            }
            protected set
            {
                if (value < this.FuelQuantity)
                {
                    this.FuelQuantity = 0;
                }
                this.tankCapacity = value;
            }
        }

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

        public virtual string DriveEmpty(double distance)
        {
            throw new NotImplementedException();
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + amount > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }

            this.FuelQuantity += amount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}

