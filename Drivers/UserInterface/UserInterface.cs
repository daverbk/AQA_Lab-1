using System;
using System.Collections.Generic;
using System.Linq;

namespace Drivers
{
    public class UserInterface
    {
        private const int AverageConsumptionMultiplier = 5;
        private const string MinivanClassName = "Drivers.Minivan";
        private const string TruckClassName = "Drivers.Truck";
        private const string SportCarClassName = "Drivers.SportCar";

        public void Start(List<Driver> drivers, List<Vehicle> vehicles)
        {
            RunMainMenu(drivers, vehicles);
        }

        private void RunMainMenu(List<Driver> drivers, List<Vehicle> vehicles)
        {
            const string prompt = @"
                        ██████╗ ██████╗ ██╗██╗   ██╗███████╗██████╗ ███████╗
                        ██╔══██╗██╔══██╗██║██║   ██║██╔════╝██╔══██╗██╔════╝
                        ██║  ██║██████╔╝██║██║   ██║█████╗  ██████╔╝███████╗
                        ██║  ██║██╔══██╗██║╚██╗ ██╔╝██╔══╝  ██╔══██╗╚════██║
                        ██████╔╝██║  ██║██║ ╚████╔╝ ███████╗██║  ██║███████║
                        ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═══╝  ╚══════╝╚═╝  ╚═╝╚══════╝
Welcome to Drivers! Use arrow keys to cycle through the options and press enter to select an option.";
            var mainMenu = new Menu(prompt, drivers);
            var selectedIndex = mainMenu.Run(drivers);
            RunSecondMenu(vehicles[selectedIndex], drivers, vehicles, selectedIndex);
        }

        private void RunSecondMenu(Vehicle vehicle, List<Driver> drivers, List<Vehicle> vehicles,
            int selectedDriverIndex)
        {
            Console.Clear();
            const string prompt = "Here you can see driver's car(s) info.";
            string[] options = {"Technical characteristics", "Performance characteristics", "Return"};
            var secondMenu = new Menu(prompt, options);
            var selectedIndex = secondMenu.Run(options);

            switch (selectedIndex)
            {
                case 0:
                    RunThirdMenu(vehicle, drivers, vehicles, selectedDriverIndex, selectedIndex);
                    break;
                case 1:
                    RunThirdMenu(vehicle, drivers, vehicles, selectedDriverIndex, selectedIndex);
                    break;
                case 2:
                    RunMainMenu(drivers, vehicles);
                    break;
            }
        }

        private void RunThirdMenu(Vehicle vehicle, List<Driver> drivers, List<Vehicle> vehicles,
            int selectedDriverIndex, int secondMenuSelectedIndex)
        {
            var prompt = "";
            switch (secondMenuSelectedIndex)
            {
                case 0:
                    var carStats = CreateCarStats(vehicles, drivers, selectedDriverIndex);
                    prompt = $"Choose 'return' to return to the previous menu.\n{carStats}";
                    break;
                case 1:
                    var calculatedResult = CalculateFuelTimeConsumption(vehicle);
                    prompt = $"Choose 'return' to return to the previous menu.\n{calculatedResult}";
                    break;
            }

            string[] options = {"Return"};
            var returnMenu = new Menu(prompt, options);
            var selectedIndex = returnMenu.Run(options);

            if (selectedIndex == 0)
            {
                RunSecondMenu(vehicle, drivers, vehicles, selectedDriverIndex);
            }
        }

        private string CreateCarStats(List<Vehicle> vehicles, List<Driver> drivers, int selectedDriverIndex)
        {
            var driverCars = vehicles.Where(vehicle => vehicle.Owner.Id == drivers[selectedDriverIndex].Id).ToList();
            var vehicleStats = "";

            foreach (var car in driverCars)
            {
                vehicleStats += ($"Type: {GetVehicleType(car)}\n" + $"Model: {car.Model}\n" +
                                 $"Year of manufacture: {car.Year}\n" +
                                 $"Engine capacity: {Math.Round(car.Engine.Capacity, 1)}\n" +
                                 $"Fuel consumption: {(int) car.Engine.Capacity * AverageConsumptionMultiplier}L/100km\n" +
                                 $"Max speed: {car.Engine.MaximumSpeed}\n\n");
            }

            return vehicleStats;
        }

        private string GetVehicleType(Vehicle vehicle)
        {
            return vehicle.GetType().ToString() switch
            {
                MinivanClassName => VehicleTypes.Minivan.ToString(),
                SportCarClassName => VehicleTypes.SportCar.ToString(),
                TruckClassName => VehicleTypes.Truck.ToString(),
                _ => ""
            };
        }

        private string CalculateFuelTimeConsumption(Vehicle vehicle)
        {
            Console.WriteLine("Insert the count of kilometers.");
            var kilometers = Convert.ToInt32(Console.ReadLine());
            var amountOfFuel = (kilometers * (int) vehicle.Engine.Capacity * AverageConsumptionMultiplier) / 100;
            var hoursItTakes = kilometers / vehicle.Engine.MaximumSpeed;
            var result =
                ($"It will take {hoursItTakes} hours and {amountOfFuel} fuel amount to get to the destination.");
            return result;
        }
    }
}
