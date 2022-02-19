using System;
using System.Collections.Generic;

namespace Drivers
{
    public static class RandomCarAssigner
    {
        private const int CaseAddMinivanOnly = 1;
        private const int CaseAddMinivanAndSportCar = 2;
        private const int CaseAddMinivanTruckAndSportCar = 3;

        private const int MinSwitchRandom = 1;
        private const int MaxSwitchRandom = 4;

        public static List<Vehicle> AssignRandomCar(List<Driver> drivers, List<Engine> engines, Random random)
        {
            var cars = new List<Vehicle>();
            foreach (var driver in drivers)
            {
                switch (random.Next(MinSwitchRandom, MaxSwitchRandom))
                {
                    case CaseAddMinivanOnly:
                        cars.Add(VehicleGenerator.GenerateMinivan(driver, engines[random.Next(engines.Count)]));
                        break;
                    case CaseAddMinivanAndSportCar:
                        cars.Add(VehicleGenerator.GenerateTruck(driver, engines[random.Next(engines.Count)]));
                        if (DriverGenerator.CheckIfEnoughDrivingExperience(driver))
                        {
                            cars.Add(VehicleGenerator.GenerateSportCar(driver, engines[random.Next(engines.Count)]));
                        }

                        break;
                    case CaseAddMinivanTruckAndSportCar:
                        cars.Add(VehicleGenerator.GenerateMinivan(driver, engines[random.Next(engines.Count)]));
                        cars.Add(VehicleGenerator.GenerateTruck(driver, engines[random.Next(engines.Count)]));
                        if (DriverGenerator.CheckIfEnoughDrivingExperience(driver))
                        {
                            cars.Add(VehicleGenerator.GenerateSportCar(driver, engines[random.Next(engines.Count)]));
                        }

                        break;
                }
            }

            return cars;
        }
    }
}
