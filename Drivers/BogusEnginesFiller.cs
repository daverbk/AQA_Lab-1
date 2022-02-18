using System.Collections.Generic;
using Bogus;

namespace Drivers
{
    public static class BogusEnginesFiller
    {
        private const double MinEngineCapacity = 1.4;
        private const double MaxEngineCapacity = 8.4;
        
        private const int MinHorsePower = 200;
        private const int MaxHorsePower = 300;
        
        private const int LowerBoundaryMaxSpeed = 160;
        private const int UpperBoundaryMaxSpeed = 220;

        public static List<Engine> FillEngine(int count)
        {
            var engineFaker = new Faker<Engine>()
                .RuleFor(x => x.Capacity, x => x.Random.Double(MinEngineCapacity, MaxEngineCapacity))
                .RuleFor(x => x.Power, x => x.Random.Int(MinHorsePower, MaxHorsePower))
                .RuleFor(x => x.FuelType, x => x.Vehicle.Fuel())
                .RuleFor(x => x.MaximumSpeed, x => x.Random.Int(LowerBoundaryMaxSpeed, UpperBoundaryMaxSpeed));
            return engineFaker.Generate(count);
        }
    }
}
