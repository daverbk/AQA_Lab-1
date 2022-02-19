using System.Collections.Generic;
using Bogus;

namespace Drivers
{
    public static class EngineGenerator
    {
        public static List<Engine> GenerateEngines(int count)
        {
            var engineFaker = new Faker<Engine>()
                .RuleFor(x => x.Capacity, x => x.Random.Double(EngineCapacity.Min, EngineCapacity.Max))
                .RuleFor(x => x.Power, x => x.Random.Int(HorsePower.Min, HorsePower.Max))
                .RuleFor(x => x.FuelType, x => x.Vehicle.Fuel())
                .RuleFor(x => x.MaximumSpeed, x => x.Random.Int(MaxSpeed.LowerBoundary, MaxSpeed.UpperBoundary));
            return engineFaker.Generate(count);
        }
    }
}
