using System;

namespace CurrencyConvertor
{
    class Program
    {
        public static void Main(string[] args)
        {
            CurrencyApi.CurrencyCheck();
            
            Currencies.RequestAmount();
            var (userCurrency, pureAmount) = Currencies.TakeAmount();
       
            Currencies.RequestExchangeCurrency();
            var exchangeCurrency = Currencies.TakeExchangeCurrency();

            switch (userCurrency)
            {
                case "USD":
                    switch (exchangeCurrency)
                    {
                        case "EUR":
                        {
                            var result = ((pureAmount * Currencies.UsdRate) / Currencies.EurRate);
                            result -= result * 0.03M;
                            Console.WriteLine($"Результат: {result:0.00} EUR");
                            break;
                        }
                        case "RUB":
                        {
                            var result = (((pureAmount * Currencies.UsdRate) * 100) / Currencies.RubRate);
                            result -= result * 0.03M;
                            Console.WriteLine($"Результат: {result:0.00} RUB");
                            break;
                        }
                        default:
                            Console.WriteLine("Неверное значение валюты.");
                            break;
                    }

                    break;
                case "EUR":
                    switch (exchangeCurrency)
                    {
                        case "RUB":
                        {
                            var result = (((pureAmount * Currencies.EurRate) * 100) / Currencies.RubRate);
                            result -= result * 0.03M;
                            Console.WriteLine($"Результат: {result:0.00} RUB");
                            break;
                        }
                        case "USD":
                        {
                            var result = ((pureAmount * Currencies.EurRate) / Currencies.UsdRate);
                            result -= result * 0.03M;
                            Console.WriteLine($"Результат: {result:0.00} USD");
                            break;
                        }
                        default:
                            Console.WriteLine("Неверное значение валюты.");
                            break;
                    }

                    break;
                case "RUB":
                    switch (exchangeCurrency)
                    {
                        case "USD":
                        {
                            var result = (((pureAmount / 100) * Currencies.RubRate) / Currencies.UsdRate);
                            result -= result * 0.03M;
                            Console.WriteLine($"Результат: {result:0.00} USD");
                            break;
                        }
                        case "EUR":
                        {
                            var result = (((pureAmount / 100) * Currencies.RubRate)  / Currencies.EurRate);
                            result -= result * 0.03M;
                            Console.WriteLine($"Результат: {result:0.00} EUR");
                            break;
                        }
                        default:
                            Console.WriteLine("Неверное значение валюты.");
                            break;
                    }
                    break;

            }
        }
    }
}