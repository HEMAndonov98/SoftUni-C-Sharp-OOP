namespace Facade.Models
{
    public class CarBuilderFacade
    {
        protected Car Car { get; set; }

        public CarBuilderFacade()
        {
            this.Car = new Car();
        }


        public CarInfoBuilder Info
            => new CarInfoBuilder(this.Car);

        public Car Build() => Car;

    }
}

