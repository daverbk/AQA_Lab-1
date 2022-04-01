using System;
using System.Linq;
using WordsToNumbers;

namespace CurrencyConvertor
{
    public static class Convertor
    {
        public const string UsdType = "USD";
        public const string EurType = "EUR";
        public const string RubType = "RUB";

        private const decimal BankPercentage = 0.03M;
        private const decimal DecimalValueByDefault = 0M;

        // Мб создадим класс Currecny  c полями Type и Value? : solved, создал класс Currency
        public static void RequestAmount()
        {
            Console.WriteLine(
                "Введите сумму конвертации числами или буквами (на английском) и трехзначный буквенный код валюты по форме: '12345 USD'");
        }

        public static (string, decimal) TakeAmount()
        {
            var userAmountCurrency = Console.ReadLine();
            // а если будут цифры и буквы? : операции под if блоком обработают ввод, разобрав его на сумму и валюту пользователя
            userAmountCurrency = InputValidation(userAmountCurrency);
            // свитч кейс не подойдет тут? : не менял на него, ибо использовал новый метод InputValidation,
            // а случай с вводом чисел словами  пойдет в if 
            if (!userAmountCurrency.Any(char.IsDigit))
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

        public static decimal ConvertCurrency(decimal userAmount, string userCurrency, string exchangeCurrency,
            decimal eurRate, decimal usdRate, decimal rubRate)
        {
            // Just to have the method returning anything at the end.
            var resultOfConversion = DecimalValueByDefault;
            switch (userCurrency)
            {
                case UsdType:
                    switch (exchangeCurrency)
                    {
                        case EurType:
                        {
                            resultOfConversion = ConvertUsdOrEur(userAmount, userCurrency, exchangeCurrency, usdRate,
                                eurRate, rubRate);
                            return resultOfConversion;
                        }
                            break;
                        case RubType:
                        {
                            resultOfConversion = ConvertToRub(userAmount, userCurrency, rubRate, eurRate, usdRate);
                            return resultOfConversion;
                        }
                            break;
                    }

                    break;
                case EurType:
                    switch (exchangeCurrency)
                    {
                        case RubType:
                        {
                            resultOfConversion = ConvertToRub(userAmount, userCurrency, rubRate, eurRate, usdRate);
                            return resultOfConversion;
                            break;
                        }
                        case UsdType:
                        {
                            resultOfConversion = ConvertUsdOrEur(userAmount, userCurrency, exchangeCurrency, usdRate,
                                eurRate, rubRate);
                            return resultOfConversion;
                            break;
                        }
                    }

                    break;
                case RubType:
                {
                    resultOfConversion = ConvertRub(userAmount, exchangeCurrency, rubRate, eurRate, usdRate);
                    return resultOfConversion;
                    break;
                }
            }

            return resultOfConversion;
        }

        private static decimal ConvertUsdOrEur(decimal userAmount, string userCurrency, string exchangeCurrency,
            decimal usdRate, decimal eurRate, decimal rubRate)
        {
            var userCurrencyRate = GetCurrencyRate(userCurrency, eurRate, usdRate, rubRate);
            var exchangeCurrencyRate = GetCurrencyRate(exchangeCurrency, eurRate, usdRate, rubRate);

            var resultBeforeSubtracting = ((userAmount * userCurrencyRate) / exchangeCurrencyRate);
            var finalResultOfConversion = SubtractBankPercentage(resultBeforeSubtracting);
            return finalResultOfConversion;
        }

        private static decimal ConvertRub(decimal userAmount, string exchangeCurrency, decimal rubRate, decimal eurRate,
            decimal usdRate)
        {
            var exchangeCurrencyRate = GetCurrencyRate(exchangeCurrency, eurRate, usdRate, rubRate);

            var resultBeforeSubtracting = ((userAmount / 100) * rubRate / exchangeCurrencyRate);
            var finalResultOfConversion = SubtractBankPercentage(resultBeforeSubtracting);
            return finalResultOfConversion;
        }

        private static decimal ConvertToRub(decimal userAmount, string userCurrency, decimal rubRate, decimal eurRate,
            decimal usdRate)
        {
            var userCurrencyRate = GetCurrencyRate(userCurrency, eurRate, usdRate, rubRate);
            var resultBeforeSubtracting = ((userAmount * userCurrencyRate) * 100 / rubRate);
            var finalResultOfConversion = SubtractBankPercentage(resultBeforeSubtracting);
            return finalResultOfConversion;
        }

        private static decimal SubtractBankPercentage(decimal resultOfConversion)
        {
            resultOfConversion -= resultOfConversion * BankPercentage;
            return resultOfConversion;
        }

        private static decimal GetCurrencyRate(string userCurrency, decimal eurRate, decimal usdRate, decimal rubRate)
        {
            var userCurrencyRate = userCurrency switch
            {
                EurType => eurRate,
                UsdType => usdRate,
                RubType => rubRate,
                _ => DecimalValueByDefault
            };
            return userCurrencyRate;
        }
    }
}
