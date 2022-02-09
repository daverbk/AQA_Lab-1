using System;
using System.Globalization;

public class Bot
{

    public void RequestSurname()
    {
        Console.WriteLine($"Здравствуйте! Введите вашу фамилию.\n");
    }
    
    public void RequestName()
    {
        Console.WriteLine("Введите ваше имя.\n");
    }
    public void RequestDate()
    {
        Console.WriteLine("Введите дату приема в формате: год (ГГГГ), месяц (ММ), день (ДД). Нажимайте ENTER после ввода каждой секции даты.\n");
    }
    
    
    public void PrintFinalMessage()
    {
        
        var visitDate = User.SetVisitDate();
        Console.WriteLine($"{User.Name} {User.Surname}, Вы записаны на прием {visitDate.ToString("dd/MM/yyyy hh:mm",new CultureInfo("ru-RU"))}");
    }
    
    
}