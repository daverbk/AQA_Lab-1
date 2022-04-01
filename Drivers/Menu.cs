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
            _selectedIndex = 0;
        }

        // Constructor for custom menus.
        public Menu(string prompt, string[] options)
        {
            _prompt = prompt;
            _hardcodedOptions = options;
            _selectedIndex = 0;
        }

        // Method for the main menu.
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

        // Method for custom menus.
        private void DisplayOptions(string[] options)
        {
            Console.WriteLine(_prompt);
            for (var i = 0; i < _hardcodedOptions.Length; i++)
            {
                var currentOption = _hardcodedOptions[i];
                string prefix;

                if (i == _selectedIndex)
                {
                    prefix = "=> ";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine($"{prefix}<<{currentOption}>>\n");
            }

            Console.ResetColor();
        }

        // Method for the main menu.
        public int Run(List<Driver> vehicles)
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions(vehicles);

                var keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    _selectedIndex--;
                    if (_selectedIndex == -1)
                    {
                        _selectedIndex = _options.Count - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    _selectedIndex++;
                    if (_selectedIndex == _options.Count)
                    {
                        _selectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);

            return _selectedIndex;
        }

        // Method for custom menus.
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

        // As MM/dd/yyyy is not a string here, I didn't make it const.
        // I hope, it's not a mistake.
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
