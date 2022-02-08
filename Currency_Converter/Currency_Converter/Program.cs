using System;
using WordsToNumbers;

namespace Currency_Converter
{
    class Program
    {
        public static void Main(string[] args)
        {
            CurrencyAPI.CurrencyCheck();
            
            Currencies.RequestAmount();
            var (userCurrency, pureAmount) = Currencies.TakeAmount();
       
            Currencies.RequestExchangeCurrency();
            var exchangeCurrency = Currencies.TakeExchangeCurrency();

            switch (userCurrency)
            {
                case "USD":
                    if (exchangeCurrency == "EUR")
                    {
                        var result = ((pureAmount * Currencies.UsdRate) / Currencies.EurRate);
                        result -= result * 0.03M;
                        Console.WriteLine($"Результат: {result:0.00} EUR");
                    }
                    else if (exchangeCurrency == "RUB")
                    {
                        var result = (((pureAmount * Currencies.UsdRate) * 100) / Currencies.RubRate);
                        result -= result * 0.03M;
                        Console.WriteLine($"Результат: {result:0.00} RUB");
                    }
                    else
                    {
                        Console.WriteLine("Неверное значение валюты.");
                    }

                    break;
                case "EUR":
                    if (exchangeCurrency == "RUB")
                    {
                        var result = (((pureAmount * Currencies.EurRate) * 100) / Currencies.RubRate);
                        result -= result * 0.03M;
                        Console.WriteLine($"Результат: {result:0.00} RUB");
                    }
                    else if (exchangeCurrency == "USD")
                    {
                        var result = ((pureAmount * Currencies.EurRate) / Currencies.UsdRate);
                        result -= result * 0.03M;
                        Console.WriteLine($"Результат: {result:0.00} USD");
                    }
                    else
                    {
                        Console.WriteLine("Неверное значение валюты.");
                    }

                    break;
                case "RUB":
                    if (exchangeCurrency == "USD")
                    {
                        var result = (((pureAmount / 100) * Currencies.RubRate) / Currencies.UsdRate);
                        result -= result * 0.03M;
                        Console.WriteLine($"Результат: {result:0.00} USD");
                    }
                    else if (exchangeCurrency == "EUR")
                    {
                        var result = (((pureAmount / 100) * Currencies.RubRate)  / Currencies.EurRate);
                        result -= result * 0.03M;
                        Console.WriteLine($"Результат: {result:0.00} EUR");
                    }
                    else
                    {
                        Console.WriteLine("Неверное значение валюты.");
                    }
                    break;

            }
        }
    }
}