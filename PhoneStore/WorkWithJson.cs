using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using NLog;

namespace PhoneStore
{
    public static class WorkWithJson
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static List<Shop> DeserializeJson()
        {
            var json = ReadJson();
            List<Shop> shops = null;
            
            try
            {
                var deserializedRootObject = JsonConvert.DeserializeObject<RootObject>(json);
                shops = deserializedRootObject?.Shops;
            }
            catch (JsonSerializationException e)
            {
                _logger.Error(e.Message);
            }
            
            return shops;
        }

        private static string ReadJson()
        {
            string json;

            try
            {
                json = File.ReadAllText(FileLocation.FullPath);
            }
            catch (FileNotFoundException e)
            {
                _logger.Error(e.Message);
                throw;
            }
            finally
            {
                _logger.Info("Json was successfully read");
            }

            return json;
        }

        public static void WriteInvoice(Phone finalResultPhone)
        {
            var fileName = $"invoice - {DateTime.Now:s}.json";
            var path = Path.Combine(FileLocation.BasePath, fileName);
            var json = SerializeFinalResultPhone(finalResultPhone);

            try
            {
                var file = new StreamWriter(path);
                file.Write(json);
                file.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static string SerializeFinalResultPhone(Phone finalResultPhone)
        {
            var jsonInvoice = "";
            try
            {
                var settings = new JsonSerializerSettings() {Formatting = Formatting.Indented};

                jsonInvoice = JsonConvert.SerializeObject(finalResultPhone, settings);
            }
            catch (JsonSerializationException e)
            {
                _logger.Error(e.Message);
            }

            return jsonInvoice;
        }
    }
}
