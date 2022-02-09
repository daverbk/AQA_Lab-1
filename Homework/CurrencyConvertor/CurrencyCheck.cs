using System;
using System.Net.Http;

namespace CurrencyConvertor
{
    public static class CurrencyApi
    {
        public static void CurrencyCheck()
        {
            string[] endpoints = new string[]
            {
                "https://www.nbrb.by/api/exrates/rates/431",
                "https://www.nbrb.by/api/exrates/rates/451", 
                "https://www.nbrb.by/api/exrates/rates/456"
            };
            
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