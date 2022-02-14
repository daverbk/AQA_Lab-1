using System.Net.Http;
using Newtonsoft.Json;

namespace CurrencyConvertor
{
    public static class CurrencyApi
    {
        public static string CheckRate(string endpoint)
        {
            // Лучше создать файлик Endpoints.cs и там хранить все эндпоинты
            // public const ServiceUrl = "https://www.nbrb.by",
            //public const ApiPrefix = '/api'
            // public const RubRate = "{BASE_YRL}{ApiPrefix}/exrates/rates/431", : solved, добавил класс Endpoints
            //Ну и этот код абсолютно бесполезный в будущем 
            // лучше создать класс, который будет уметь отправлять запросы : CurrencyApi, метод CheckRate
            // передавать в него эндпоинт и возвращать респонс : 
            // Потом уже где то парсить данные : решил добавить метод GetRate прямо в этот класс для этого дела
            // То есть разбиваем логически на методы и классы и стараемся думать о переиспользовании 
            using var client = new HttpClient();
            var fullJson = client.GetAsync(endpoint).Result.Content.ReadAsStringAsync().Result;

            return fullJson;
        }

        public static decimal GetRate(string fullJson)
        {
            var deserializeObject = JsonConvert.DeserializeObject<RateShort>(fullJson);

            return deserializeObject.Cur_OfficialRate;
        }
    }
}
