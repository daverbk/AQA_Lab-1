using PhoneStore.Helpers;
using PhoneStore.Models;

namespace PhoneStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            JsonParser.DeserializeJsonFile();
            ConsoleRepresentationHelper.PrintGeneralShopInfo();

            var phoneModel = ConsoleRepresentationHelper.GetPhoneModel();
            var shopName = ConsoleRepresentationHelper.GetShop(phoneModel);
            var finalPhone = PhonesHelper.GetPhone(shopName, phoneModel);

            BillHelper.IssueBill(
                new OrderReceipt
                {
                    PhoneModel = finalPhone.Model,
                    PhonePrice = finalPhone.Price,
                    MarketLaunchDate = finalPhone.MarketLaunchDate,
                    Shop = shopName
                });
        }
    }
}
