using System;

namespace Drivers
{
    public class Driver : Person
    {
        private DateTime _dateGotDrivingLicense;

        public DateTime DateGotDrivingLicense
        {
            get => _dateGotDrivingLicense;
            set
            {
                while (value < DateOfBirth || value.Year - DateOfBirth.Year < 16)
                {
                    value = BogusDriversFiller.FillDriver(1)[0].DateGotDrivingLicense;
                }

                _dateGotDrivingLicense = value;
                IsDriver = true;
            }
        }

        public Guid Id { get; set; }
    }
}
