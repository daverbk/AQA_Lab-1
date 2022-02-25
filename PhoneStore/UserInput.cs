using System;

namespace PhoneStore
{
    public static class UserInput
    {
        public static string AskInput()
        {
            var userInput = Console.ReadLine();

            while (ValidateInput(userInput))
            {
                Console.Clear();
                Messages.PrintPhoneNotFound();
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        private static bool ValidateInput(string userInput)
        {
            return string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(userInput);
        }
    }
}
