using System;

namespace PhoneStore.CustomExceptions
{
    public class PhoneNotFoundException : Exception
    {
        public PhoneNotFoundException(string message) : base(message)
        {
        }
    }
}
