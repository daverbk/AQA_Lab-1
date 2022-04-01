
using System;
using System.Collections.Generic;

namespace Drivers
{
    public class Program
    {
        static void Main(string[] args)
        {
            var drivers = new List<Driver>();
            var engines = new List<Engine>();
            var vehicles = new List<Vehicle>();
            var random = new Random();

            var countOfDrivers = 3;
            // Generating some count of drivers.
            for (var i = 0; i < countOfDrivers; i++)
            {
                drivers.Add(BogusObjectFiller.FillDriver());
                engines.Add(BogusObjectFiller.FillEngine());
            }

            // Generating some amount of vehicles of different type to provide the logic
            // of one driver having N count of cars. And I've decided to provide the logic 
            // that cars might have same engines.
            for (var i = 0; i < countOfDrivers * 2; i++)
            {
                vehicles.Add(BogusObjectFiller.FillMinivan(drivers[random.Next(countOfDrivers)],
                    engines[random.Next(countOfDrivers)]));
                vehicles.Add(BogusObjectFiller.FillTruck(drivers[random.Next(countOfDrivers)],
                    engines[random.Next(countOfDrivers)]));
                var indexForSportCar = random.Next(countOfDrivers);
                if (BogusObjectFiller.CheckIfEnoughDrivingExp(drivers[indexForSportCar]))
                {
                    vehicles.Add(BogusObjectFiller.FillSportCar(drivers[indexForSportCar],
                        engines[random.Next(countOfDrivers)]));
                }
            }

            var ui = new UserInterface();
            ui.Start(drivers, vehicles);
        }
    }
}
