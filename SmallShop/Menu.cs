using System;

namespace SmallShop
{
    public class Menu
    {
        private int _selectedIndex;
        private string[] _options;
        private string _prompt;

        public Menu(string prompt, string[] options)
        {
            _prompt = prompt;
            _options = options;
        }

        private void DisplayOptions(string[] options)
        {
            Console.WriteLine(_prompt);
            for (var i = 0; i < options.Length; i++)
            {
                string prefix;

                if (i == _selectedIndex)
                {
                    prefix = "=> ";
                    //info = GetUserCartInfo(, _selectedIndex);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine($"{prefix}<<{_options[i]}>>");
            }

            Console.ResetColor();
        }

        public int Run(string[] options)
        {
            ConsoleKey keyPressed;
            do
            {
                Console.CursorVisible = false;
                Console.Clear();
                DisplayOptions(options);

                var keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                switch (keyPressed)
                {
                    case ConsoleKey.UpArrow:
                    {
                        _selectedIndex--;
                        if (_selectedIndex == -1)
                        {
                            _selectedIndex = _options.Length - 1;
                        }

                        break;
                    }
                    case ConsoleKey.DownArrow:
                    {
                        _selectedIndex++;
                        if (_selectedIndex == _options.Length)
                        {
                            _selectedIndex = 0;
                        }

                        break;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);

            return _selectedIndex;
        }
    }
}
