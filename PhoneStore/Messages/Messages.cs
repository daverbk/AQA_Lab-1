using System;
using System.Collections.Generic;
using System.Linq;
using NLog;

namespace PhoneStore
{
    public static class Messages
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static void PrintShopsInfo(List<Shop> shops)
        {
            foreach (var shop in shops)
            {
                var iosDevicesCount = shop.Phones.Count(p =>
                    p.OperationSystemType.Contains(OperationSystemType.IOS.ToString()) && p.IsAvailable);
                var androidDevicesCount = shop.Phones.Count(p =>
                    p.OperationSystemType.Contains(OperationSystemType.Android.ToString()) && p.IsAvailable);

                _logger.Info("Shop name: {shopName}\n\n\tShop description: {shopDescription}", shop.Name,
                    shop.Description);
                _logger.Info("\tHas {iosCount} IOS devices and {androidCount} android devices.\n", iosDevicesCount,
                    androidDevicesCount);
            }
        }

        public static void PrintAvailablePhonesAndShopsWhereSold(List<Shop> shopsWherePhoneAvailable, string userInput)
        {
            Console.Clear();

            foreach (var shop in shopsWherePhoneAvailable)
            {
                _logger.Info("\nStore: {shopName}\n", shop.Name);
                foreach (var phone in shop.Phones.Where(phone => phone.Model.Contains(userInput)))
                {
                    _logger.Info(
                        "Model: {phoneModel}\n\tPrice: {phonePrice}$\n\tOperatio system: {phoneOperationSystemType}\n\tMarket launch date: {phone.MarketLaunchDate}",
                        phone.Model, phone.Price, phone.OperationSystemType, phone.MarketLaunchDate);
                }
            }
        }

        public static void AskForPhoneModel()
        {
            _logger.Info("Insert what phone model you whould like to buy.");
        }

        public static void AskForShop(string userInputModel)
        {
            _logger.Info("What shop would you like to by {chosenModel} at?", userInputModel);
        }

        public static void PrintShopNotFound()
        {
            _logger.Info("Shop not found.Insert the shop again.");
        }

        public static void PrintPhoneNotFound()
        {
            _logger.Info("Phone not found. Insert the model again.");
        }

        public static void PrintPhoneOutOfStock()
        {
            _logger.Info("Phone is out of stock. See another model.");
        }

        public static void PrintFinalMessage(Phone finalResultPhone)
        {
            Console.Clear();
            _logger.Info("Order {userInputPhone} for {phonePrice}$ is successfully created.", finalResultPhone.Model,
                finalResultPhone.Price);
        }
    }
}
