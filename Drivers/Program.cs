using System;
using System.Collections.Generic;

namespace Drivers
{
    public class Program
    {
        static void Main(string[] args)
        {
            const int countOfDrivers = 3;
            const int countOfEngines = 4;
            var random = new Random();

            // DEVNOTE: Generating some count of drivers.
            var drivers = BogusDriversFiller.FillDriver(countOfDrivers);
            var engines = BogusEnginesFiller.FillEngine(countOfEngines);
            var vehicles = new List<Vehicle>();

            // DEVNOTE: Generating some amount of vehicles of different type to provide the logic
            // of one driver having N count of cars. And I've decided to provide the logic 
            // that cars might have same engines.
            for (var i = 0; i < countOfDrivers ; i++)
            {
                vehicles.Add(BogusVehiclesFiller.FillMinivan(drivers[random.Next(countOfDrivers)],
                    engines[random.Next(countOfEngines)]));
                vehicles.Add(BogusVehiclesFiller.FillTruck(drivers[random.Next(countOfDrivers)],
                    engines[random.Next(countOfEngines)]));
                
                var indexForSportCar = random.Next(countOfDrivers);
                if (BogusDriversFiller.CheckIfEnoughDrivingExp(drivers[indexForSportCar]))
                {
                    vehicles.Add(BogusVehiclesFiller.FillSportCar(drivers[indexForSportCar],
                        engines[random.Next(countOfEngines)]));
                }
            }

            var ui = new UserInterface();
            ui.Start(drivers, vehicles);
        }
    }
}
