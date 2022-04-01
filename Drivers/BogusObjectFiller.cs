using System;
using Bogus;

namespace Drivers
{
    public static class BogusObjectFiller
    {
        // Let's assume driving license must be reissued every 10 years.
        private const int YearsToGoBack = 10;

        public static Driver FillDriver()
        {
            var driverFaker = new Faker<Driver>()
                .RuleFor(x => x.FirstName, x => x.Person.FirstName)
                .RuleFor(x => x.LastName, x => x.Person.LastName)
                .RuleFor(x => x.DateOfBirth, x => x.Person.DateOfBirth)
                .RuleFor(x => x.DateGotDrivingLicense, x => x.Date.Past(YearsToGoBack))
                .RuleFor(x => x.Id, Guid.NewGuid);
            return driverFaker.Generate();
        }
        
        private const double MinEngineCapacity = 1.4;
        private const double MaxEngineCapacity = 8.4;
        private const int MinHorsePower = 200;
        private const int MaxHorsePower = 300;
        private const int LowerBoundaryMaxSpeed = 160;
        private const int UpperBoundaryMaxSpeed = 220;

        public static Engine FillEngine()
        {
            var engineFaker = new Faker<Engine>()
                .RuleFor(x => x.Capacity, x => x.Random.Double(MinEngineCapacity, MaxEngineCapacity))
                .RuleFor(x => x.Power, x => x.Random.Int(MinHorsePower, MaxHorsePower))
                .RuleFor(x => x.FuelType, x => x.Vehicle.Fuel())
                .RuleFor(x => x.MaximumSpeed, x => x.Random.Int(LowerBoundaryMaxSpeed, UpperBoundaryMaxSpeed));
            return engineFaker.Generate();
        }
        
        private const int MinManufactureYear = 1980;
        private const int MaxManufactureYear = 2022;
        
        private static Faker<TVehicle> ApplyVehicleRules<TVehicle>(Faker<TVehicle> faker, Driver owner, Engine engine)
            where TVehicle : Vehicle
        {
            return faker.RuleFor(x => x.Model, x => x.Vehicle.Manufacturer())
                .RuleFor(x => x.Year, x => x.Random.Int(MinManufactureYear, MaxManufactureYear))
                .RuleFor(x => x.Owner, owner)
                .RuleFor(x => x.Engine, engine);
        }

        public static Vehicle FillVehicle(Driver owner, Engine engine)
        {
            var vehicleFaker = new Faker<Vehicle>();
            ApplyVehicleRules(vehicleFaker, owner, engine);

            return vehicleFaker.Generate();
        }

        public static SportCar FillSportCar(Driver owner, Engine engine)
        {
            var sportCarFaker = new Faker<SportCar>();
            ApplyVehicleRules(sportCarFaker, owner, engine);

            return sportCarFaker.Generate();
        }

        internal static Truck FillTruck(Driver owner, Engine engine)
        {
            var truckFaker = new Faker<Truck>();
            ApplyVehicleRules(truckFaker, owner, engine);
                truckFaker
                    .RuleFor(x => x.IsPricep, x => x.Random.Bool());
                
            return truckFaker.Generate();
        }

        private const int MinSeatsCount = 8;
        private const int MaxSeatsCount = 22;

        public static Minivan FillMinivan(Driver owner, Engine engine)
        {
            var minivanFaker = new Faker<Minivan>();
            ApplyVehicleRules(minivanFaker, owner, engine);
            minivanFaker
                .RuleFor(x => x.SeatsCount, x => x.Random.Int(MinSeatsCount, MaxSeatsCount));

            return minivanFaker.Generate();
        }

        public static bool CheckIfEnoughDrivingExp(Driver driver)
        {
            if (DateTime.Now.Year - driver.DateGotDrivingLicense.Year < 5)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
