using System;
using NLog;
using PhoneStore.Constants;
using PhoneStore.CustomExceptions;

namespace PhoneStore.Helpers
{
    public static class ConsoleRepresentationHelper
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static void PrintGeneralShopInfo() =>
            ProgramData.RootObject.Shops.ForEach(shop =>
            {
                var shopName = shop.Name;
                Logger.Info($"{shop.Name} - {shop.Description}.\n");

                OperationSystems.AllOperationSystems.ForEach(operationSystemName =>
                {
                    var shopAvailablePhonesByOperationSystem =
                        ShopsHelper.GetCountAvailablePhonesByOperationSystem(shopName, operationSystemName);

                    Logger.Info($"\t=> Available {operationSystemName} phones count: {shopAvailablePhonesByOperationSystem}");
                });
            });

        public static string GetPhoneModel()
        {
            AskPhoneModel();
            var userInput = Console.ReadLine();
            var isPhonePresent = PhonesHelper.IsPhoneModelPresent(userInput);
            var isPhoneAvailable = PhonesHelper.IsPhoneModelAvailable(userInput);

            switch (isPhonePresent)
            {
                case true when isPhoneAvailable:
                    PrintGeneralShopInfo();
                    break;
                case true when !isPhoneAvailable:
                    PrintPhoneNotAvailable();
                    GetPhoneModel();
                    break;
                default: throw new PhoneNotFoundException("The phone you entered wasn't found.");
            }

            return userInput!;
        }

        public static string GetShop(string phoneModel)
        {
            AskShop(phoneModel);
            var userInput = Console.ReadLine();
            var doesShopExist = ShopsHelper.DoesShopExist(userInput);

            if (!doesShopExist)
            {
                GetShop(phoneModel);
            }

            var phone = PhonesHelper.GetPhone(userInput, phoneModel);
            var phoneInformation = $"Phone model: {phoneModel},\n Market launch date: {phone.MarketLaunchDate},\n Shop: {userInput},\n Phone price: {phone.Price}.";
            BillHelper.PrintOrderInformation(phoneInformation);
            return userInput;
        }

        private static void AskPhoneModel() => Logger.Info("What phone do you want to buy?");

        private static void PrintPhoneNotAvailable() =>
            Logger.Info("This phone is out of stock. Please choose another one.");

        private static void AskShop(string phoneModel) =>
            Logger.Info($"In which shop do you want to buy {phoneModel}?");
    }
}
