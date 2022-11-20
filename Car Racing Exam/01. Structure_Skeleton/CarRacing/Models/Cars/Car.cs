namespace CarRacing.Models.Cars
{
    using System;
    using CarRacing.Utilities.Messages;
    using Contracts;

    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsepower;
        private double fuelAvailable;
        private double fuelConsumptionPerRace;


        protected Car(string make, string model, string VIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = VIN;
            this.FuelAvailable = fuelAvailable;
            this.FuelConsumptionPerRace = fuelConsumptionPerRace;
        }

        public string Make
        {
            get => this.make;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidCarMake);
                this.make = value;
            }
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidCarModel);
                this.model = value;
            }
        }

        public string VIN
        {
            get => this.vin;
            private set
            {
                if (value.Length != 17)
                    throw new ArgumentException(ExceptionMessages.InvalidCarVIN);
                this.vin = value;
            }
        }

        public int HorsePower
        {
            get => this.horsepower;
            protected set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.InvalidCarHorsePower);
                this.horsepower = value;
            }
        }

        public double FuelAvailable
        {
            get => this.fuelAvailable;
            protected set
            {
                this.fuelAvailable = value;

                if (this.fuelAvailable < 0)
                    this.fuelAvailable = 0;
            }
        }

        public double FuelConsumptionPerRace
        {
            get => this.fuelConsumptionPerRace;
            private set
            {
                this.fuelConsumptionPerRace = value;
                if (this.fuelConsumptionPerRace < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarFuelConsumption);
                }
            }
        }

        public virtual void Drive()
        {
            this.FuelAvailable -= this.FuelConsumptionPerRace;
        }
    }
}

