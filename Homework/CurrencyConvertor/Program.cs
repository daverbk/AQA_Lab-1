using System;

namespace CurrencyConvertor
{
    // модификатор : solved
    public class Program
    {
        public static void Main(string[] args)
        {
            CurrencyApi.CurrencyCheck();
            
            Convertor.RequestAmount();
            var (userCurrency, userAmount) = Convertor.TakeAmount();
       
            Convertor.RequestExchangeCurrency();
            var exchangeCurrency = Convertor.TakeExchangeCurrency();

            switch (userCurrency)
            {
                // В константы пж USD EUR etc : solved, добавил константы в класс Currency
                case (Currency.UsdType): 
                    switch (exchangeCurrency)
                    {
                        // дублирование в кейсах : solved, добавил методы в классе Convertor
                        case (Currency.EurType):
                        {
                            var result = Convertor.ConvertUsdToEur(userAmount);
                            Console.WriteLine(result + "EUR");
                            break;
                        }
                        case (Currency.RubType):
                        {
                            var result = Convertor.ConvertUsdToRub(userAmount);
                            Console.WriteLine(result + "RUB");
                            break;
                        }
                        default:
                            Console.WriteLine("Неверное значение валюты.");
                            break;
                    }
                    break;
                case (Currency.EurType): 
                    switch (exchangeCurrency)
                    {
                        case (Currency.RubType):
                        {
                            // лишние скобки в выражении : solved 
                            var result = Convertor.ConvertEurToRub(userAmount);
                            // 0.3М тоже непонятно что это : solved, добавил в класс  Сonvertor костанту
                            Console.WriteLine(result + "RUB");
                            break;
                        }
                        case (Currency.UsdType):
                        {
                            var result = Convertor.ConvertEurToUsd(userAmount);
                            Console.WriteLine(result + "USD");
                            break;
                        }
                        default:
                            Console.WriteLine("Неверное значение валюты.");
                            break;
                    }
                    break;
                case nameof(Currency.RubType) :
                    switch (exchangeCurrency)
                    {
                        case (Currency.UsdType):
                        {
                            var result = Convertor.ConvertRubToUsd(userAmount);
                            Console.WriteLine(result + "USD");
                            break;
                        }
                        case (Currency.EurType):
                        {
                            var result = Convertor.ConvertRubToEur(userAmount);
                            Console.WriteLine(result + "EUR");
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
