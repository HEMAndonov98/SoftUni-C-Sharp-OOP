using System;
using Vehicle.Models;
using Vehicle.Models.Interfaces;

namespace Vehicle.Core
{
    public class Engine : IEngine
    {
        private readonly IVehicle car;
        private readonly IVehicle truck;

        public Engine(IVehicle car, IVehicle truck)
        {
            this.car = car;
            this.truck = truck;
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var commandArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (commandArgs[0] == "Drive")
                {
                    if (commandArgs[1] == "Car")
                    {
                        Console.WriteLine(this.car.Drive(double.Parse(commandArgs[2])));
                    }
                    else if (commandArgs[1] == "Truck")
                    {
                        Console.WriteLine(this.truck.Drive(double.Parse(commandArgs[2])));
                    }
                }
                else if (commandArgs[0] == "Refuel")
                {
                    if (commandArgs[1] == "Car")
                    {
                        this.car.Refuel(double.Parse(commandArgs[2]));
                    }
                    else if (commandArgs[1] == "Truck")
                    {
                        this.truck.Refuel(double.Parse(commandArgs[2]));
                    }
                }
            }

            Console.WriteLine(this.car);
            Console.WriteLine(this.truck);
        }
    }
}

