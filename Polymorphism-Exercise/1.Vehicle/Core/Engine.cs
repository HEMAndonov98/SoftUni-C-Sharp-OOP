using System;
using Vehicle.Models;
using Vehicle.Models.Interfaces;

namespace Vehicle.Core
{
    public class Engine : IEngine
    {
        private readonly IVehicle car;
        private readonly IVehicle truck;
        private readonly IVehicle bus;

        public Engine(IVehicle car, IVehicle truck, IVehicle bus)
            :this(car, truck)
        {
            this.bus = bus;
        }

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
                try
                {
                    var commandArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (commandArgs.Length == 0)
                    {
                        //This is only because I am pasting the example data from the website
                        //and it prints it with an extra new line between the arguments.
                        i--;
                        continue;
                    }

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
                        else if (commandArgs[1] == "Bus")
                        {
                            Console.WriteLine(this.bus.Drive(double.Parse(commandArgs[2])));
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
                        else if (commandArgs[1] == "Bus")
                        {
                            this.bus.Refuel(double.Parse(commandArgs[2]));
                        }
                    }
                    else if (commandArgs[0] == "DriveEmpty")
                    {
                        Console.WriteLine(this.bus.DriveEmpty(double.Parse(commandArgs[2])));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(this.car);
            Console.WriteLine(this.truck);
            Console.WriteLine(this.bus);
        }
    }
}

