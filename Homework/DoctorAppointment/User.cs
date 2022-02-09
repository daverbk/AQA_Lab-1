using System;
using System.Linq;

public class User
{
    private static string? _userName;
    private static string? _userSurame;
    
    public static string? Name
    {
        get => _userName;

        set
        {
            while (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || char.IsLower(value[0]) || value.Any(char.IsDigit))
            {
                Console.WriteLine("Введите имя с большой буквы. Имя не может состоять из цифр.");
                value = Console.ReadLine();
            }
            
            _userName = value;

        }
    }

    public static string? Surname 
    {
        get
        {
            return _userSurame;
        }

        set
        {
            while (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) ||  char.IsLower(value[0]) || value.Any(char.IsDigit))
            {
                Console.WriteLine("Введите фамилию с большой буквы. Имя не может состоять из цифр.");
                value = Console.ReadLine();
            }

            _userSurame = value;

        }
    }
    
    public static DateTime SetVisitDate()
    {
        var random = new Random();
        // Assume the doctor's working hours are 9am-8pm.
        var date = new DateTime(
            Convert.ToInt32(Console.ReadLine()), 
            Convert.ToInt32(Console.ReadLine()), 
            Convert.ToInt32(Console.ReadLine()),
            random.Next(9,20),
            random.Next(0,60),
            0
        );

        while (date < DateTime.Now )
        {
            Console.WriteLine("Вы ввели дату из прошлого, повторите ввод даты.");
            date = new DateTime(
                Convert.ToInt32(Console.ReadLine()), 
                Convert.ToInt32(Console.ReadLine()), 
                Convert.ToInt32(Console.ReadLine()),
                random.Next(9,20),
                random.Next(0,60),
                0
            );
        }
        
        return date;
    }

}