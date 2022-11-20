namespace CarRacing.Models.Cars
{
    using System;
    public class TunnedCar : Car
    {
        private static int startingFuel = 65;
        private static double startingConsumption = 7.5;
        protected static double engineWearPercentage = 0.03;

        public TunnedCar(string make, string model, string VIN, int horsePower)
            :base(make, model, VIN, horsePower, startingFuel, startingConsumption)
        {
        }

        public override void Drive()
        {
            double engineWearCalculation = this.HorsePower - (this.HorsePower * engineWearPercentage);
            int engineAfterWear = (int)Math.Round(engineWearCalculation, MidpointRounding.AwayFromZero);
            this.HorsePower = engineAfterWear;
            base.Drive();
        }
    }
}

