using System;
using System.IO;
using System.Linq;
using WordsToNumbers;

namespace CurrencyConvertor
{
    public static class Currencies
    {
        public static decimal UsdRate { get; set; }

        public static decimal RubRate { get; set; }

        public static decimal EurRate { get; set; }

        public static void RequestAmount()
        {
            Console.WriteLine("Введите сумму конвертации числами или буквами (на англисйком) и трехзначный буквенный код валюты по форме: '12345 USD'");
        }

        public static (string, decimal) TakeAmount()
        {
            var amount = Console.ReadLine();
            
            if (amount is null or " ")
            {
                throw new InvalidDataException("Сумма конвертации не может быть null.");
            }
            else if(!amount.Any(char.IsDigit))
            {
                var convertor = new SimpleReplacementStrategy();
                amount = convertor.ConvertWordsToNumbers(amount).ToUpper();
                
            }
            
            var substring = amount.Split(' ');
            var userCurrency = substring[1];
            var pureAmount = Convert.ToDecimal(substring[0]);

            return (userCurrency, pureAmount);
        }

        public static void RequestExchangeCurrency()
        {
            Console.WriteLine("Введите трехзначный буквенный код валюты обмена по примеру: 'RUB' ");
        }

        public static string TakeExchangeCurrency()
        {
            var exchangeCurrency = Console.ReadLine();
            if (exchangeCurrency is null or " ")
            {
                throw new InvalidDataException("Валюта обмена не может быть null.");
            }
            
            return exchangeCurrency;
        }

    }
}
