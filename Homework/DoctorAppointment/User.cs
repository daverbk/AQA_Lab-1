using System;
using System.Linq;

// Неймспейсы проверь : solved 
namespace DoctorAppointment
{
    public static class User
    {
        // Почему они налабл? : solved, были налабл, ибо во время разработки добавил ? для тествых запусков, позже,
        // когда добавил проверку в сеттере, забыл убрать. 
        private static string _userName;
        private static string _userSurname;

        public static string Name
        {
            get => _userName;

            set
            {
                InputValidation(value);
                _userName = value;
            }
        }

        public static string Surname
        {
            // Лучше через стрелочную : solved 
            get => _userSurname;

            set
            {
                // опять дублирование : solved
                InputValidation(value);
                _userSurname = value;
            }
        }

        private static string InputValidation(string userInput)
        {
            while (string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(userInput) ||
                   char.IsLower(userInput[0]) || userInput.Any(char.IsDigit))
            {
                Console.WriteLine("Произведите ввод с большой буквы. Ввод не может содержать цифры.");
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        public static DateTime SetVisitDate()
        {
            // Константы для чисел. Код должен читаться легко и любой человек должен понимать что в нем происходит,
            // не вдаваясь в логику : solved 
            var date = SetDate();

            while (date < DateTime.Now)
            {
                Console.WriteLine("Вы ввели дату из прошлого, повторите ввод даты.");
                date = SetDate();
            }

            return date;
        }

        private static DateTime SetDate()
        {
            var random = new Random();
            var setDate = new DateTime(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), 
                Convert.ToInt32(Console.ReadLine()), random.Next(Bot.OpeningHours, Bot.ClosingHours), 
                random.Next(Bot.MinutesLowerBoundary, Bot.MinutesUpperBoundary), 0);
            return setDate;
        }
    }
}
