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
            const string prompt = @"
██████╗ ███████╗████████╗ ██████╗ ██████╗ ███████╗    ███████╗██╗███╗   ███╗██╗   ██╗██╗      █████╗ ████████╗ ██████╗ ██████╗ 
██╔══██╗██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗██╔════╝    ██╔════╝██║████╗ ████║██║   ██║██║     ██╔══██╗╚══██╔══╝██╔═══██╗██╔══██╗
██████╔╝███████╗   ██║   ██║   ██║██████╔╝█████╗      ███████╗██║██╔████╔██║██║   ██║██║     ███████║   ██║   ██║   ██║██████╔╝
██╔══██╗╚════██║   ██║   ██║   ██║██╔══██╗██╔══╝      ╚════██║██║██║╚██╔╝██║██║   ██║██║     ██╔══██║   ██║   ██║   ██║██╔══██╗
██████╔╝███████║   ██║   ╚██████╔╝██║  ██║███████╗    ███████║██║██║ ╚═╝ ██║╚██████╔╝███████╗██║  ██║   ██║   ╚██████╔╝██║  ██║
╚═════╝ ╚══════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚══════╝    ╚══════╝╚═╝╚═╝     ╚═╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝
                                                                                                                               
Welcome to BStore! Use arrow keys to cycle through the options and press enter to select an option. At any <<User list>> menu you can type 0 to return to the main menu.";
            var options = new[] {"User list", "Add a user", "Exit"};
            var mainMenu = new Menu(prompt, options);
            var selectedIndex = mainMenu.Run(options);

            switch (selectedIndex)
            {
                case Constats.MainMenuOptions.UserListOption:
                    RunSecondMenu(users);
                    break;
                case Constats.MainMenuOptions.AddUserOption:
                    AddUserWithEmptyCart(users);
                    RunMainMenu(users);
                    break;
                case Constats.MainMenuOptions.ExitOption:
                    Exit();
                    break;
            }
        }

        private void RunSecondMenu(List<User> users)
        {
            const string prompt = null;
            var options = new[] {"Let's add some wine", "Let's delete some products"};
            var secondMenu = new Menu(prompt, options);
            var selectedIndex = secondMenu.Run(options);

            switch (selectedIndex)
            {
                case 0:
                    var chosenUserIndex1 = ChooseUser(users);
                    users[chosenUserIndex1].TryAddAlcohol(users[chosenUserIndex1].ShoppingCart);

                    RunMainMenu(users);
                    break;
                case 1:
                    var chosenUserIndex = ChooseUser(users);
                    var chosenProduct = ChooseProduct(users, chosenUserIndex);
                    users[chosenUserIndex].DeleteProduct(users[chosenUserIndex].ShoppingCart, chosenProduct);

                    RunMainMenu(users);
                    break;
            }
        }

        private int ChooseUser(List<User> users)
        {
            PrintUsers(users);
            Console.Write("Type the index of the user you would like to see the cart of: ");
            var chosenIndex = UserInput.InputChosenIndex(users);
            ToMainMenu(users, chosenIndex);
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
            ToMainMenu(users, chosenIndex);
            return chosenIndex;
        }

        private void PrintProducts(List<User> users, int chosenUserIndex)
        {
            PrepareConsoleForTyping();

            var index = Constats.Indexes.StartingIndexForPrint;
            var sum = 0M;
            AddProductToEmptyCart(users, chosenUserIndex);

            foreach (var product in users[chosenUserIndex].ShoppingCart)
            {
                Console.WriteLine($"{index}.{product.Category}\n" + $"\t{product.Price}$\n" + $"\t{product.Name}\n" +
                                  $"\t{product.Barcode}");
                sum += product.Price;
                index++;
            }

            Console.WriteLine($"Grand total: {sum}$");
        }

        private void AddProductToEmptyCart(List<User> users, int chosenUserIndex)
        {
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
        }

        private void AddUserWithEmptyCart(List<User> currentUsers)
        {
            PrepareConsoleForTyping();
            Console.WriteLine(
                "Alternately insert user's age, first name and passport ID. After each point press \"Enter\".");
            Console.WriteLine("Passport ID must contain 32 character (upper- and lower-case letters or numbers).");
            
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

        private void ToMainMenu(List<User> users, int selectedIndex)
        {
            if (selectedIndex == Constats.Indexes.ToMainMenuIndex)
            {
                RunMainMenu(users);
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
