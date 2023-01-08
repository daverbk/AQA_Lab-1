using System;
using System.IO;
using Newtonsoft.Json;
using NLog;
using PhoneStore.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace PhoneStore.Helpers
{
    public static class BillHelper
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static void PrintOrderInformation(string phoneInformation) =>
            Logger.Info($"Your order:\n {phoneInformation}\n The order was successfully completed!");

        public static void IssueBill(OrderReceipt receiptData)
        {
            var fileName = $"invoice - {DateTime.Now:s}.json";
            var path = Path.Combine(JsonParser.BasePath!, fileName);

            var orderReceipt = new OrderReceipt
            {
                PhoneModel = receiptData.PhoneModel,
                MarketLaunchDate = receiptData.MarketLaunchDate,
                PhonePrice = receiptData.PhonePrice,
                Shop = receiptData.Shop
            };

            var orderReceiptJson = JsonSerializer.Serialize(orderReceipt);

            try
            {
                var file = new StreamWriter(path);
                file.Write(orderReceiptJson);
                file.Close();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
            }
        }
    }
}
