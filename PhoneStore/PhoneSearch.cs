using System.Collections.Generic;
using System.Linq;
using NLog;

namespace PhoneStore
{
    public static class PhoneSearch
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static (List<Shop> shopsWherePhoneAvailable, string userInputModel) SearchPhoneUntilFound(
            List<Shop> shops)
        {
            var userInputModel = UserInput.AskInput();
            var shopsWherePhoneFoundAvailable = SearchPhone(shops, userInputModel);
            while (shopsWherePhoneFoundAvailable == null)
            {
                userInputModel = UserInput.AskInput();
                shopsWherePhoneFoundAvailable = SearchPhone(shops, userInputModel);
            }

            return (shopsWherePhoneFoundAvailable, userInputModel);
        }
        
        private static List<Shop> SearchPhone(List<Shop> shops, string userInputModel)
        {
            List<Shop> shopsWhereThePhoneAvailable = null;

            try
            {
                var phoneCanBeFound = CheckIfPhoneCanBeFound(shops, userInputModel);
                if (phoneCanBeFound)
                {
                    var phoneIsInStock = CheckIfPhoneInStock(shops, userInputModel);
                    if (phoneIsInStock)
                    {
                        shopsWhereThePhoneAvailable = GetShopsWherePhoneAvailable(shops, userInputModel);
                        Messages.PrintAvailablePhonesAndShopsWhereSold(shopsWhereThePhoneAvailable, userInputModel);
                    }
                    else
                    {
                        Messages.PrintPhoneOutOfStock();
                        throw new PhoneNotFoundException();
                    }
                }
                else
                {
                    Messages.PrintPhoneNotFound();
                    throw new PhoneNotFoundException();
                }
            }
            catch (PhoneNotFoundException)
            {
                _logger.Error("Phone {modelName} was not found", userInputModel);
            }
            finally
            {
                _logger.Info("Phone successfully found. List of shops where phone is avaliable returned.");
            }

            return shopsWhereThePhoneAvailable;
        }

        private static bool CheckIfPhoneCanBeFound(List<Shop> shops, string userInputModel)
        {
            var phoneCanBeFound = shops.SelectMany(shop => shop.Phones).Any(phone => phone.Model.Contains(userInputModel));

            return phoneCanBeFound;
        }

        private static bool CheckIfPhoneInStock(List<Shop> shops, string userInputModel)
        {
            var phoneIsInStock = shops.SelectMany(shop => shop.Phones)
                .Where(phone => phone.Model.Contains(userInputModel))
                .Any(phone => phone.IsAvailable == true);

            return phoneIsInStock;
        }

        private static List<Shop> GetShopsWherePhoneAvailable(List<Shop> shops, string userInputModel)
        {
            var shopsWherePhoneAvailable = shops.Where(shop =>
                    shop.Phones.Any(phone => phone.Model.Contains(userInputModel) && phone.IsAvailable == true))
                .ToList();

            return shopsWherePhoneAvailable;
        }

        public static Phone GetFinalPhone(List<Shop> shopsWherePhoneAvailable, string userInputModel,
            string userInputShop)
        {
            var finalResultPhone = shopsWherePhoneAvailable.Where(shop => shop.Name.Contains(userInputShop))
                .SelectMany(shop => shop.Phones)
                .Where(phone => phone.Model.Contains(userInputModel))
                .ToList()
                .SingleOrDefault();

            return finalResultPhone;
        }
    }
}
