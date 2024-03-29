﻿using System;
namespace Vehicle.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            :this(fuelQuantity, fuelConsumption) 
        {
            this.TankCapacity = tankCapacity;
        }

        public Car(double fuelQuantity, double fuelConsumption)
            :base(fuelQuantity, fuelConsumption)
        {
            base.fuelCoefficient = 0.9;
            base.FuelConsumption = fuelConsumption;
        }
    }
}

