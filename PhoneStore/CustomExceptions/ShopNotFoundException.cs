using System;

namespace PhoneStore.CustomExceptions
{
    public class ShopNotFoundException : Exception
    {
        public ShopNotFoundException(string message) : base(message)
        {
        }
    }
}
