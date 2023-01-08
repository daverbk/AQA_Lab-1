using System.Linq;
using PhoneStore.CustomExceptions;

namespace PhoneStore.Helpers
{
    public static class ShopsHelper
    {
        public static bool DoesShopExist(string shopName)
        {
            shopName = shopName ?? throw new ShopNotFoundException("Invalid shop name.");

            return ProgramData.RootObject.Shops.Any(s => s.Name == shopName);
        }

        public static int GetCountAvailablePhonesByOperationSystem(string shopName, string operationSystem)
        {
            var shop = ProgramData.RootObject.Shops.FirstOrDefault(s => s.Name == shopName)
                ?? throw new ShopNotFoundException($"Shop \"{shopName}\" was not found.");

            return shop.Phones.Count(p => p.IsAvailable && p.OperationSystemType == operationSystem);
        }
    }
}
