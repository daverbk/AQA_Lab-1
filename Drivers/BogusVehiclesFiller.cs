using Bogus;

namespace Drivers
{
    public static class BogusVehiclesFiller
    {
        private const int MinManufactureYear = 1980;
        private const int MaxManufactureYear = 2022;
        
        private const int MinSeatsCount = 8;
        private const int MaxSeatsCount = 22;

        private const int LowerBoundaryMaxSpeed = 260;
        private const int UpperBoundaryMaxSpeed = 300;
        
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
            sportCarFaker.RuleFor(x => x.MaxSpeed,
                x => x.Random.Int(LowerBoundaryMaxSpeed, UpperBoundaryMaxSpeed));

            return sportCarFaker.Generate();
        }

        internal static Truck FillTruck(Driver owner, Engine engine)
        {
            var truckFaker = new Faker<Truck>();
            ApplyVehicleRules(truckFaker, owner, engine);
            truckFaker
                .RuleFor(x => x.WithTrailer, x => x.Random.Bool());
                
            return truckFaker.Generate();
        }

        public static Minivan FillMinivan(Driver owner, Engine engine)
        {
            var minivanFaker = new Faker<Minivan>();
            ApplyVehicleRules(minivanFaker, owner, engine);
            minivanFaker
                .RuleFor(x => x.SeatsCount, x => x.Random.Int(MinSeatsCount, MaxSeatsCount));

            return minivanFaker.Generate();
        }
    }
}
