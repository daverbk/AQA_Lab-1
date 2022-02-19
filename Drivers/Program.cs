using System;

namespace Drivers
{
    public class Program
    {
        static void Main(string[] args)
        {
            const int countOfDrivers = 3;
            const int countOfEngines = 4;
            var random = new Random();

            var drivers = DriverGenerator.GenerateDrivers(countOfDrivers);
            var engines = EngineGenerator.GenerateEngines(countOfEngines);
            var vehicles = RandomCarAssigner.AssignRandomCar(drivers, engines, random);

            var ui = new UserInterface();
            ui.Start(drivers, vehicles);
        }
    }
}
