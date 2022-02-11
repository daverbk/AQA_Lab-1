using System;
using System.Linq;
using WordsToNumbers;

namespace CurrencyConvertor
{
    public static class Convertor
    {
        private const decimal BankPercentage = 0.03M;

        // Мб создадим класс Currecny  c полями Type и Value? : solved, создал класс Currency
        public static void RequestAmount()
        {
            Console.WriteLine("Введите сумму конвертации числами или буквами (на английском) и трехзначный буквенный код валюты по форме: '12345 USD'");
        }
        
        public static (string, decimal) TakeAmount()
        {
            var userAmountCurrency = Console.ReadLine();
            // а если будут цифры и буквы? : операции под if блоком обработают ввод, разобрав его на сумму и валюту пользователя.
            userAmountCurrency = InputValidation(userAmountCurrency);
            // свитч кейс не подойдет тут? : не менял на него, ибо использовал новый метод InputValidation,
            // а случай с вводом чисел словами  пойдет в if 
            if(!userAmountCurrency.Any(char.IsDigit))
            {
                var convertor = new SimpleReplacementStrategy();
                userAmountCurrency = convertor.ConvertWordsToNumbers(userAmountCurrency).ToUpper();
            }
            
            var splittedUserAmountCurrency = userAmountCurrency.Split(' ');
            var userCurrency = splittedUserAmountCurrency[1];
            var userAmount = Convert.ToDecimal(splittedUserAmountCurrency[0]);

            return (userCurrency, userAmount);
            // абсолютно непонятно что мы дальше делаем что вырезаем и для чего : надеюсь, solved, поменял названия переменных
        }
        
        public static void RequestExchangeCurrency()
        {
            Console.WriteLine("Введите трехзначный буквенный код валюты обмена по примеру: 'RUB' ");
        }

        // Можно создать метод который будет чекать не нал ли и переиспользовать тут и выше  : solved, доабавил метод InputValidation
        public static string TakeExchangeCurrency()
        {
            var exchangeCurrency = Console.ReadLine();
            // Мне кажется есть что то типа isNullOrEmptyString() : solved, добавил метод InpurValidation
            exchangeCurrency = InputValidation(exchangeCurrency);
            return exchangeCurrency;
        }

        private static string InputValidation(string userInput)
        {
            while (string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(userInput))
            {
                userInput = Console.ReadLine();
                Console.WriteLine("Ввод не может быть null.");
            }
            return userInput;
        }

        public static decimal ConvertUsdToEur(decimal userAmount)
        {
            var inEuro = ((userAmount * Currency.UsdValue) / Currency.EurValue);
            inEuro -= inEuro * BankPercentage;
            return inEuro;
        }
        
        public static decimal ConvertUsdToRub(decimal userAmount)
        {
            var inRub = ((userAmount * Currency.UsdValue) * 100 / Currency.RubValue);
            inRub -= inRub * BankPercentage;
            return inRub;
        }
        
        public static decimal ConvertEurToRub(decimal userAmount)
        {
            var inRub = ((userAmount * Currency.EurValue) * 100 / Currency.RubValue);
            inRub -= inRub * BankPercentage;
            return inRub;
        }
        
        public static decimal ConvertEurToUsd(decimal userAmount)
        {
            var inUsd = ((userAmount * Currency.EurValue) / Currency.UsdValue);
            inUsd -= inUsd * BankPercentage;
            return inUsd;
        }
        
        public static decimal ConvertRubToUsd(decimal userAmount)
        {
            var inUsd = ((userAmount / 100) * Currency.RubValue / Currency.UsdValue);
            inUsd -= inUsd * BankPercentage;
            return inUsd;
        }
        
        public static decimal ConvertRubToEur(decimal userAmount)
        {
            var inEur = ((userAmount / 100) * Currency.RubValue  / Currency.EurValue);
            inEur -= inEur * BankPercentage;
            return inEur;
        }
    }
}
