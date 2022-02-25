using System.Collections.Generic;
using System.Linq;
using NLog;

namespace PhoneStore
{
    public static class ShopSearch
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static void SearchShopUntilFound(List<Shop> shopsWherePhoneAvailable, string userInputShop,
            string userInputModel)
        {
            var shopIsFound = SearchShop(shopsWherePhoneAvailable, userInputShop, userInputModel);

            while (!shopIsFound)
            {
                userInputShop = UserInput.AskInput();
                shopIsFound = SearchShop(shopsWherePhoneAvailable, userInputShop, userInputModel);
            }
        }
        
        private static bool SearchShop(List<Shop> shopsWherePhoneAvailable, string userInputShop, string userInputModel)
        {
            var searchIsSuccessful = false;
            try
            {
                var shopCanBeFound = CheckIfShopCanBeFound(shopsWherePhoneAvailable, userInputShop);
                if (shopCanBeFound)
                {
                    searchIsSuccessful = true;
                    var finalResultPhone =
                        PhoneSearch.GetFinalPhone(shopsWherePhoneAvailable, userInputModel, userInputShop);

                    Messages.PrintFinalMessage(finalResultPhone);
                    WorkWithJson.WriteInvoice(finalResultPhone);
                }
                else
                {
                    Messages.PrintShopNotFound();
                    throw new ShopNotFoundException();
                }
            }
            catch (ShopNotFoundException)
            {
                _logger.Error("Shop {shopName} was not found", userInputShop);
            }
            finally
            {
                _logger.Info("Shop was successfully found and invoice was created.");
            }

            return searchIsSuccessful;
        }

        private static bool CheckIfShopCanBeFound(List<Shop> shopsWherePhoneFoundAvailable, string userInputShop)
        {
            var shopCanBeFound = shopsWherePhoneFoundAvailable.Any(shop => shop.Name.Contains(userInputShop));

            return shopCanBeFound;
        }
    }
}
