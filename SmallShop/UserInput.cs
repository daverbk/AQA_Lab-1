using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallShop
{
    public static class UserInput
    {
        private const int GuidInputLenght = 32;
        private const int FirstLetterIndex = 0;

        public static int InputAge()
        {
            var userAgeInput = Console.ReadLine();
            int age;

            while (userAgeInput == null || !int.TryParse(userAgeInput, out age) ||
                   age is > Constats.PersonAge.Max or < Constats.PersonAge.Min)
            {
                Console.Clear();
                Console.WriteLine(
                    "User's age must be not less than 8 or greater than 100, cannot contain letters or be null.");
                userAgeInput = Console.ReadLine();
            }

            return age;
        }

        public static string InputFirstName()
        {
            var userFirstNameInput = Console.ReadLine();
            while (string.IsNullOrEmpty(userFirstNameInput) || string.IsNullOrWhiteSpace(userFirstNameInput) ||
                   userFirstNameInput.Any(char.IsDigit) || char.IsLower(userFirstNameInput[FirstLetterIndex]))
            {
                Console.Clear();
                Console.WriteLine(
                    "User's first name must start with a capital letter, must not contain numbers or be null.");
                userFirstNameInput = Console.ReadLine();
            }

            return userFirstNameInput;
        }

        public static Guid InputPassportId()
        {
            var userPassportIdInput = Console.ReadLine();
            Guid passportId;
            while (string.IsNullOrEmpty(userPassportIdInput) || string.IsNullOrWhiteSpace(userPassportIdInput) ||
                   userPassportIdInput.Length != GuidInputLenght || !Guid.TryParse(userPassportIdInput, out passportId))
            {
                Console.Clear();
                Console.WriteLine("User's passport ID must be 32 characters long and must not be null");
                userPassportIdInput = Console.ReadLine();
            }

            return passportId;
        }

        public static int InputChosenIndex(List<User> currentUsers)
        {
            var userChoice = Console.ReadLine();
            int chosenIndex;

            while (string.IsNullOrEmpty(userChoice) || string.IsNullOrWhiteSpace(userChoice) ||
                   !int.TryParse(userChoice, out chosenIndex) || chosenIndex > currentUsers.Count ||
                   chosenIndex < Constats.Indexes.Min)
            {
                Console.WriteLine("Index must be in boundaries of the typed list and must contain only numbers.");
                userChoice = Console.ReadLine();
            }

            chosenIndex -= Constats.ListSubtrahend.Subtrahend;
            return chosenIndex;
        }
    }
}
