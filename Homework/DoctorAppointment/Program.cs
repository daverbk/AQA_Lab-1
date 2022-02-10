using System;

// модификатор : solved
namespace DoctorAppointment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Bot.RequestSurname();
            User.Surname = Console.ReadLine();
            
            Bot.RequestName();
            User.Name = Console.ReadLine();
            
            Bot.RequestDate();
            Bot.PrintFinalMessage();
        }
    }
}
