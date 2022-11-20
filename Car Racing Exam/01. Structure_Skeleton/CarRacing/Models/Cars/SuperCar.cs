namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private static int startingFuel = 80;
        private static int startingConsumption = 10;

        public SuperCar(string make, string model, string VIN, int horsePower)
            :base(make, model, VIN, horsePower, startingFuel, startingConsumption)
        {
        }
    }
}

