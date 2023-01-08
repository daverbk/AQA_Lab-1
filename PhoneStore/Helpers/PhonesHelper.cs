using System.Linq;
using PhoneStore.CustomExceptions;
using PhoneStore.Models;

namespace PhoneStore.Helpers
{
    public static class PhonesHelper
    {
        public static Phone GetPhone(string shopName, string model)
        {
            return ProgramData.RootObject.Shops
                .First(s => s.Name == shopName).Phones.First(p => p.Model == model); // на скорую руку, first() тут не самый лучший вариант
        }

        public static bool IsPhoneModelPresent(string? model)
        {
            model = model ?? throw new PhoneNotFoundException("Invalid phone name.");

            return ProgramData.RootObject.Shops
                .Any(s => s.Phones.Any(p => p.Model == model));
        }

        public static bool IsPhoneModelAvailable(string? model)
        {
            model = model ?? throw new PhoneNotFoundException("Invalid phone name.");

            return ProgramData.RootObject.Shops
                .Any(s => s.Phones.Any(p => p.Model == model && p.IsAvailable));
        }
    }
}
