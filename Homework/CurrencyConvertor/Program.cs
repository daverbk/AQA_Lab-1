using System;

namespace CurrencyConvertor
{
    // модификатор : solved
    public class Program
    {
        public static void Main(string[] args)
        {
            var eur = new Currency
            {
                Type = Convertor.EurType, Value = CurrencyApi.GetRate(CurrencyApi.CheckRate(Endpoints.EurRate))
            };

            var usd = new Currency
            {
                Type = Convertor.UsdType, Value = CurrencyApi.GetRate(CurrencyApi.CheckRate(Endpoints.UsdRate))
            };

            var rub = new Currency
            {
                Type = Convertor.RubType, Value = CurrencyApi.GetRate(CurrencyApi.CheckRate(Endpoints.RubRate))
            };

            Convertor.RequestAmount();
            var (userCurrency, userAmount) = Convertor.TakeAmount();

            Convertor.RequestExchangeCurrency();
            var exchangeCurrency = Convertor.TakeExchangeCurrency();

            var converted = Convertor.ConvertCurrency(userAmount, userCurrency, exchangeCurrency, eur.Value, usd.Value,
                rub.Value);
            Console.WriteLine(Math.Round(converted, 2) + " " + exchangeCurrency);

            // В константы пж USD EUR etc : solved, добавил константы в класс Currency
            // дублирование в кейсах : solved, добавил методы в классе Convertor
            // лишние скобки в выражении : solved 
            // 0.3М тоже непонятно что это : solved, добавил в класс  Сonvertor костанту
        }
    }
}
