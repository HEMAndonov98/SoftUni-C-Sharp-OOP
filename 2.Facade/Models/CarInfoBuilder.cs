using System;
namespace Facade.Models
{
    public class CarInfoBuilder : CarBuilderFacade
    {
        public CarInfoBuilder(Car car)
        {
            this.Car = car;
        }

        public CarInfoBuilder WithMake(string make)
        {
            this.Car.Make = make;
            return this;
        }

        public CarInfoBuilder WithModel(string model)
        {
            this.Car.Model = model;
            return this;
        }

        public CarInfoBuilder WithYear(int year)
        {
            this.Car.Year = year;
            return this;
        }

        public CarInfoBuilder WithKilometers(int kilometers)
        {
            this.Car.Kilometers = kilometers;
            return this;
        }
    }
}

