using System;
using System.Net.Http;

namespace CurrencyConvertor
{
    public static class CurrencyApi
    {
        public static void CurrencyCheck()
        {
            // Лучше создать файлик Endpoints.cs и там хранить все эндпоинты
            // public const ServiceUrl = "https://www.nbrb.by",
            //public const ApiPrefix = '/api'
            // public const RubRate = "{BASE_YRL}{ApiPrefix}/exrates/rates/431",
            string[] endpoints = new string[]
            {
                "https://www.nbrb.by/api/exrates/rates/431",
                "https://www.nbrb.by/api/exrates/rates/451", 
                "https://www.nbrb.by/api/exrates/rates/456"
            };
            
            //Ну и этот код абсолютно бесполезный в будущем 
            // лучше создать класс, который будет уметь отправлять запросы 
            // передавать в него эндпоинт и возвращать респонс 
            // Потом уже где то парсить данные 
            // То есть разбиваем логически на методы и классы и стараемся думать о переиспользовании 
            using (var client = new HttpClient())
            {
                for (int i = 0; i < 3; i++)
                {
                    var fullJson = client.GetAsync( endpoints[i] ).Result.Content
                        .ReadAsStringAsync().Result;
                    fullJson = fullJson.Substring(1, fullJson.Length - 2);
                    var splittedResult = fullJson.Split(':');
                    var rate = Convert.ToDecimal(splittedResult[8]);
                    
                    switch (i)
                    {
                        case 0:
                            Currencies.UsdRate = rate;
                            break;
                        case 1:
                            Currencies.EurRate = rate;
                            break;
                        case 2:
                            Currencies.RubRate = rate;
                            break;
                        
                    }
                }
            }
        }
    }
}