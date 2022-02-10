using System;
using System.Globalization;

// Может быть статик : solved 
namespace DoctorAppointment
{
    public static class Bot
    {
        private const int s_openingHours = 9;
        private const int s_closingHours = 20;
        private const int s_minutesLowerBoundary = 0;
        private const int s_minutesUpperBoundary = 60;
        
        public static int MinutesLowerBoundary => s_minutesLowerBoundary;
        public static int MinutesUpperBoundary => s_minutesUpperBoundary;
        public static int OpeningHours => s_openingHours;
        public static int ClosingHours => s_closingHours;
        
        public static void RequestSurname()
        {
            // Избыточный $ : solved
            Console.WriteLine("Здравствуйте! Введите вашу фамилию.\n");
        }
        public static void RequestName()
        {
            Console.WriteLine("Введите ваше имя.\n");
        }
        public static void RequestDate()
        {
            Console.WriteLine("Введите дату приема в формате: год (ГГГГ), месяц (ММ), день (ДД). Нажимайте ENTER после ввода каждой секции даты.\n");
        }
        // код конвеншены!!! Лишние пустые линии. Нет пустой строки в конце каждого файла
        // (гугл поиск конфигур иде то эд блэнк лайн эт зе энд оф файл) : надеюсь, solved, убрал лишние строки
        public static void PrintFinalMessage()
        {
            var visitDate = User.SetVisitDate();
            Console.WriteLine($"{User.Name} {User.Surname}, Вы записаны на прием {visitDate.ToString("dd/MM/yyyy hh:mm",new CultureInfo("ru-RU"))}");
        }
    }
}
