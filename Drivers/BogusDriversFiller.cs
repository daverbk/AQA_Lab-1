using System;
using System.Collections.Generic;
using Bogus;

namespace Drivers
{
    public static class BogusDriversFiller
    {
        // DEVNOTE: Let's assume driving license must be reissued every 10 years.
        private const int YearsToGoBack = 10;

        public static List<Driver> FillDriver(int count)
        {
            var driverFaker = new Faker<Driver>()
                .RuleFor(x => x.FirstName, x => x.Person.FirstName)
                .RuleFor(x => x.LastName, x => x.Person.LastName)
                .RuleFor(x => x.DateOfBirth, x => x.Person.DateOfBirth)
                .RuleFor(x => x.DateGotDrivingLicense, x => x.Date.Past(YearsToGoBack))
                .RuleFor(x => x.Id, Guid.NewGuid);
            return driverFaker.Generate(count);
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
