
namespace SmallShop
{
    public class Program
    {
        static void Main(string[] args)
        {
            var products = ProductGenerator.GenerateProducts(5);
            var users = UserGenerator.GenerateUsers(5, products);

            var ui = new UserInterface();
            ui.Start(users);
        }
    }
}
