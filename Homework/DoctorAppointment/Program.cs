using System;

// модификатор
class Program
{
    public static void Main(string[] args)
    {
        var bot = new Bot();
            
        bot.RequestSurname();
        User.Surname = Console.ReadLine();
            
        bot.RequestName();
        User.Name = Console.ReadLine();
            
        bot.RequestDate();
            
        bot.PrintFinalMessage();

    }
}