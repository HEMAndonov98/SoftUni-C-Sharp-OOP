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
            IVehicle car = factory.CreateVehicle(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
            IVehicle truck = factory.CreateVehicle(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
            Engine engine = new Engine(car, truck);
            engine.Run();
        }
    }
}

