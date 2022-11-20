namespace CarRacing.Models.Racers
{
    using System;
    using Contracts;
    using Cars.Contracts;
    using CarRacing.Utilities.Messages;

    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehaviour;
        private int drivingExperience;
        private ICar car;

        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;
        }

        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);

                this.username = value;
            }
        }

        public string RacingBehavior
        {
            get => this.racingBehaviour;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);

                this.racingBehaviour = value;
            }
        }

        public int DrivingExperience
        {
            get => this.drivingExperience;
            protected set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);

                this.drivingExperience = value;
            }
        }

        public ICar Car
        {
            get => this.car;
            private set
            {
                if (value == null)
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);

                this.car = value;
            }
        }

        public bool IsAvailable()
            => this.car.FuelAvailable >= this.car.FuelConsumptionPerRace;

        public virtual void Race()
        {
            this.car.Drive();
        }
    }
}

