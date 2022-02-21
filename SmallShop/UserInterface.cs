using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SmallShop
{
    public class UserInterface
    {
        public void Start(List<User> users)
        {
            RunMainMenu(users);
        }

        private void RunMainMenu(List<User> users)
        {
            while (true) // DEVNOTE: "While" is intended to come back to the main menu using "continue;".
            {
                const string prompt = @"
██████╗ ███████╗████████╗ ██████╗ ██████╗ ███████╗    ███╗   ███╗ █████╗ ███╗   ██╗ █████╗  ██████╗ ███████╗██████╗ 
██╔══██╗██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗██╔════╝    ████╗ ████║██╔══██╗████╗  ██║██╔══██╗██╔════╝ ██╔════╝██╔══██╗
██████╔╝███████╗   ██║   ██║   ██║██████╔╝█████╗      ██╔████╔██║███████║██╔██╗ ██║███████║██║  ███╗█████╗  ██████╔╝
██╔══██╗╚════██║   ██║   ██║   ██║██╔══██╗██╔══╝      ██║╚██╔╝██║██╔══██║██║╚██╗██║██╔══██║██║   ██║██╔══╝  ██╔══██╗
██████╔╝███████║   ██║   ╚██████╔╝██║  ██║███████╗    ██║ ╚═╝ ██║██║  ██║██║ ╚████║██║  ██║╚██████╔╝███████╗██║  ██║
╚═════╝ ╚══════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚══════╝    ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝

Welcome to BStore! Use arrow keys to cycle through the options and press enter to select an option. At any <<User list>> menu you can type 0 to return to the main menu.";
                var options = new[] {"User list", "Add a user", "Exit"};
                var mainMenu = new Menu(prompt, options);
                var selectedIndex = mainMenu.Run(options);

                switch (selectedIndex)
                {
                    case Constats.MainMenuOptions.UserListOption:
                        var chosenUserIndex = ChooseUser(users);
                        if (chosenUserIndex == Constats.Indexes.ToMainMenuIndex)
                        {
                            continue;
                        }

                        var chosenProduct = ChooseProduct(users, chosenUserIndex);
                        if (chosenProduct == Constats.Indexes.ToMainMenuIndex)
                        {
                            continue;
                        }

                        users[chosenUserIndex].DeleteProduct(users[chosenUserIndex].ShoppingCart, chosenProduct);
                        continue;
                    case Constats.MainMenuOptions.AddUserOption:
                        AddUserWithEmptyCart(users);
                        continue;
                    case Constats.MainMenuOptions.ExitOption:
                        Exit();
                        break;
                }

                break;
            }
        }

        private int ChooseUser(List<User> users)
        {
            PrintUsers(users);
            Console.Write("Type the index of the user you would like to see the cart of: ");
            var chosenIndex = UserInput.InputChosenIndex(users);
            return chosenIndex;
        }

        private void PrintUsers(List<User> users)
        {
            PrepareConsoleForTyping();

            var index = Constats.Indexes.StartingIndexForPrint;
            foreach (var user in users)
            {
                Console.WriteLine($"{index}.{user.FirstName}\n" + $"\tAge: {user.Age}\n" +
                                  $"\tPassport ID: {user.PassportId}");
                index++;
            }
        }

        private int ChooseProduct(List<User> users, int chosenUserIndex)
        {
            PrintProducts(users, chosenUserIndex);
            Console.Write("Type the index of the product you want to delete: ");
            var chosenIndex = UserInput.InputChosenIndex(users);
            return chosenIndex;
        }

        private void PrintProducts(List<User> users, int chosenUserIndex)
        {
            PrepareConsoleForTyping();

            var index = Constats.Indexes.StartingIndexForPrint;
            var sum = 0M;
            if (users[chosenUserIndex].ShoppingCart.Count == 0)
            {
                Console.WriteLine("The user's cart is yet empty. If you want to add one press \"Enter\".");
                Console.WriteLine("If you don't want to add anything, press any other button.");
                var keyInfo = Console.ReadKey(true);
                var keyPressed = keyInfo.Key;
                if (keyPressed == ConsoleKey.Enter)
                {
                    users[chosenUserIndex].AddNewProduct(users[chosenUserIndex].ShoppingCart);
                }
            }
            else
            {
                foreach (var product in users[chosenUserIndex].ShoppingCart)
                {
                    Console.WriteLine($"{index}.{product.Category}\n" + $"\t{product.Price}$\n" +
                                      $"\t{product.Name}\n" + $"\t{product.Barcode}");
                    sum += product.Price;
                    index++;
                }

                Console.WriteLine($"Grand total: {sum}$");
            }
        }

        private void AddUserWithEmptyCart(List<User> currentUsers)
        {
            PrepareConsoleForTyping();

            Console.WriteLine(
                "Alternately insert user's age, first name and passport ID. After each point press \"Enter\".");
            var userToAdd = new User()
            {
                Age = UserInput.InputAge(),
                FirstName = UserInput.InputFirstName(),
                PassportId = UserInput.InputPassportId(),
                ShoppingCart = ProductGenerator.GenerateProducts(Constats.NewUser.CountOfProductsWhenCreated)
            };

            var isEqualToAny = currentUsers.Any(u => u.Equals(userToAdd));
            if (isEqualToAny)
            {
                Console.WriteLine("User with this passport ID is already signed in.");
                Thread.Sleep(Constats.TimeToWait.InMilliseconds);
            }
            else
            {
                currentUsers.Add(userToAdd);
            }
        }

        private void Exit()
        {
            Environment.Exit(0);
        }

        private void PrepareConsoleForTyping()
        {
            Console.Clear();
            Console.CursorVisible = true;
        }
    }
}
