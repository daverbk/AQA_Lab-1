using Bogus;

namespace Drivers
{
    public static class VehicleGenerator
    {
        private static Faker<TVehicle> ApplyVehicleRules<TVehicle>(Faker<TVehicle> faker, Driver owner, Engine engine)
            where TVehicle : Vehicle
        {
            return faker.RuleFor(x => x.Model, x => x.Vehicle.Manufacturer())
                .RuleFor(x => x.Year, x => x.Random.Int(ManufactureYear.Min, ManufactureYear.Max))
                .RuleFor(x => x.Owner, owner)
                .RuleFor(x => x.Engine, engine);
        }

        public static SportCar GenerateSportCar(Driver owner, Engine engine)
        {
            var sportCarFaker = new Faker<SportCar>();
            ApplyVehicleRules(sportCarFaker, owner, engine);
            sportCarFaker.RuleFor(x => x.MaxSpeed,
                x => x.Random.Int(SportCarMaxSpeed.LowerBoundary, SportCarMaxSpeed.UpperBoundary));

            return sportCarFaker.Generate();
        }

        internal static Truck GenerateTruck(Driver owner, Engine engine)
        {
            var truckFaker = new Faker<Truck>();
            ApplyVehicleRules(truckFaker, owner, engine);
            truckFaker
                .RuleFor(x => x.WithTrailer, x => x.Random.Bool());
                
            return truckFaker.Generate();
        }

        public static Minivan GenerateMinivan(Driver owner, Engine engine)
        {
            var minivanFaker = new Faker<Minivan>();
            ApplyVehicleRules(minivanFaker, owner, engine);
            minivanFaker
                .RuleFor(x => x.SeatsCount, x => x.Random.Int(SeatsCount.Min, SeatsCount.Max));

            return minivanFaker.Generate();
        }
    }
}
