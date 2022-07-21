using System;
using Vehicle.Core;
using Vehicle.Factories;
using Vehicle.Models;
using Vehicle.Models.Interfaces;

namespace Vehicle
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var factory = new VehicleFactory();
            var car = factory.CreateVehicleWithCapacity(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
            var truck = factory.CreateVehicleWithCapacity(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
            var bus = factory.CreateVehicleWithCapacity(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));

            Engine engine = new Engine(car, truck, bus);
            engine.Run();
        }
    }
}

