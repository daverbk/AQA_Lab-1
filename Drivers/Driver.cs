using System;

namespace Drivers
{
    public class Driver : Person
    {
        private const int AgeAllowedToGetLicense = 16;
        private DateTime _dateGotDrivingLicense;

        public DateTime DateGotDrivingLicense
        {
            get => _dateGotDrivingLicense;
            set
            {
                while (value < DateOfBirth || value.Year - DateOfBirth.Year < AgeAllowedToGetLicense)
                {
                    value = DriverGenerator.GenerateDriverNewDateOfBirth().DateOfBirth;
                }

                _dateGotDrivingLicense = value;
                IsDriver = true;
            }
        }

        public Guid Id { get; set; }
    }
}
