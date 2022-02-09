using System;
using System.Globalization;

// Может быть статик

public class Bot
{

    public void RequestSurname()
    {
        // Избыточный $
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
    // код конвеншены!!! Лишние пустые линии. Нет пустой строки в конце каждого файла (гугл поиск конфигур иде то эд блэнк лайн эт зе энд оф файл)
    
    
    public void PrintFinalMessage()
    {
        
        var visitDate = User.SetVisitDate();
        Console.WriteLine($"{User.Name} {User.Surname}, Вы записаны на прием {visitDate.ToString("dd/MM/yyyy hh:mm",new CultureInfo("ru-RU"))}");
    }
    
    
}