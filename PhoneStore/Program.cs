using System;

namespace PhoneStore
{
    public class Program
    {
        static void Main(string[] args)
        {
            var shops = WorkWithJson.DeserializeJson();
            
            Console.Clear();
            Messages.PrintShopsInfo(shops);
            
            Messages.AskForPhoneModel();
            var (shopsWherePhoneAvailable, userInputModel) = PhoneSearch.SearchPhoneUntilFound(shops);
            
            Messages.AskForShop(userInputModel);
            var userInputShop = UserInput.AskInput();
            ShopSearch.SearchShopUntilFound(shopsWherePhoneAvailable, userInputShop, userInputModel);
        }
    }
}
