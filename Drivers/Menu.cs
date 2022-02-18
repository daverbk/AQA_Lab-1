using System;
using System.Collections.Generic;

namespace Drivers
{
    public class Menu
    {
        private int _selectedIndex;
        private List<Driver> _options;
        private string[] _hardcodedOptions;
        private string _prompt;

        public Menu(string prompt, List<Driver> options)
        {
            _prompt = prompt;
            _options = options;
        }

        // DEVNOTE: Constructor for custom menus.
        public Menu(string prompt, string[] options)
        {
            _prompt = prompt;
            _hardcodedOptions = options;
        }

        // DEVNOTE: Method for the main menu.
        private void DisplayOptions(List<Driver> drivers)
        {
            Console.WriteLine(_prompt);
            for (var i = 0; i < _options.Count; i++)
            {
                var currentOption = _options[i].FirstName;
                string prefix;
                string info;

                if (i == _selectedIndex)
                {
                    prefix = "=> ";
                    info = GetDriverInfo(drivers, _selectedIndex);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    info = "";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine($"{prefix}<<{currentOption}>>\n" + $"{info}");
            }

            Console.ResetColor();
        }

        // DEVNOTE: Method for custom menus.
        private void DisplayOptions(string[] options) // Метод, который выводит в консоль все опции меню.
        {
            Console.WriteLine(_prompt); // Выводим заглавие.
            for (var i = 0; i < _hardcodedOptions.Length; i++) // С помощью этого цикла выводим все опции, которые 
            {                                                  // пользователь сможет кликать.
                var currentOption = _hardcodedOptions[i]; 
                string prefix; 

                if (i == _selectedIndex)                       // Задача этого if - визуально обозначить на какой опции  
                {                                              // находится юзер.
                    prefix = "=> ";
                    Console.ForegroundColor = ConsoleColor.Black;  // Так, если индекс цикла будет равен индексу,  
                    Console.BackgroundColor = ConsoleColor.White;  // на котором находиться пользователь, то перед 
                }                                                  // опцией будет =>. 
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine($"{prefix}<<{currentOption}>>\n"); // Сам вывод опций(пунктов) меню с обозначением  
            }                                                        // на какой опции находится пользователь.

            Console.ResetColor();
        }

        // DEVNOTE: Method for the main menu.
        public int Run(List<Driver> vehicles)
        {
            ConsoleKey keyPressed;
            do // Цикл, который будет сопровождать логику переключения по опциям меню.
            {
                Console.Clear(); // Очищаем консоль.
                DisplayOptions(vehicles); // Выводим опции меню с указателем на выбранный пункт.

                var keyInfo = Console.ReadKey(true); // Юзер может нажимать любые клавиши, но т.к. в параметры
                keyPressed = keyInfo.Key;                    // метода ReadKey мы передаем true-они не будут выводиться
                                                             // в консоль, без этого параметра, все нажатые клавиши
                if (keyPressed == ConsoleKey.UpArrow)        // выводились бы в консоль.
                {
                    _selectedIndex--;
                    if (_selectedIndex == -1)                // Логика if и else if заключается в переключении между 
                    {                                        // между опциями.
                        _selectedIndex = _options.Count - 1;
                    }                                        //  _selectedIndex не имеет никакого отношения к самому 
                }                                            // массиву или списку опций, т.к. само по себе это поле 
                else if (keyPressed == ConsoleKey.DownArrow) // класса Menu, оно нужно лишь для визуального обозначения 
                {                                            // опции на которой находиться пользователь.
                    _selectedIndex++;
                    if (_selectedIndex == _options.Count)    // Из-за того, что _selectedIndex не связан с индексом 
                    {                                        // массива или списка опций, следует, что, если юзер 
                        _selectedIndex = 0;                  // наикрементит или надерементит, выходя за рамки массива
                    }                                        // или списка опций, исключение "Index out of bounds" 
                }                                            // не будет выкинуто. Но для того, чтобы "перепрыгивать", 
            } while (keyPressed != ConsoleKey.Enter);        // например, с крайнего верхнего пункта меню в крайнее  
                                                             // нижнее, если юзер нажимает стрелку "вверх",  
            return _selectedIndex;                           // используется вложенный if. Метод возращает индекс,
        }                                                    // на котором юзер нажал клавишу "Enter". С помощью 
                                                             // этого индекса в дальнейшем вызывается следующее,   
        // DEVNOTE: Method for custom menus.                 // выбранное пользователем меню.
        public int Run(string[] options)
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions(options);

                var keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    _selectedIndex--;
                    if (_selectedIndex == -1)
                    {
                        _selectedIndex = _hardcodedOptions.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    _selectedIndex++;
                    if (_selectedIndex == _hardcodedOptions.Length)
                    {
                        _selectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);

            return _selectedIndex;
        }

        private string GetDriverInfo(List<Driver> drivers, int selectedIndex)
        {
            var index = selectedIndex;
            var driverInfo = FormatDriverInfo(drivers[index]);
            return driverInfo;
        }
        
        private string FormatDriverInfo(Driver driver)
        {
            var formattedInfo = $"Name: {driver.FirstName + " " + driver.LastName}\n" +
                                $"Date of birth: {driver.DateOfBirth:MM/dd/yyyy}\n" +
                                $"Date license was issued: {driver.DateGotDrivingLicense:MM/dd/yyyy}\n" +
                                $"Driving license ID: {driver.Id}";

            return formattedInfo;
        }
    }
}
