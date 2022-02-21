using System;
using System.Collections.Generic;
using System.Threading;

namespace SmallShop
{
    public class User
    {
        public Guid PassportId { get; set; }

        public string FirstName { get; set; }

        public int Age { get; set; }

        public List<Product> ShoppingCart { get; set; }

        public void AddNewProduct(List<Product> userProductCart)
        {
            userProductCart.Add(
                ProductGenerator.GenerateProducts(Constats.NewProduct.CountOfProductsWhenAdding)[
                    Constats.NewProduct.IndexOfProductWhenAdding]);
        }

        public void DeleteProduct(List<Product> userProductCart, int selectedProductIndex)
        {
            userProductCart.RemoveAt(selectedProductIndex);
        }

        public void TryAddAlcohol(List<Product> userProductCart)
        {
            if (Age <= Constats.AgeToBuyAlcohol.Age)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Too young to drink alcohol.");
                Thread.Sleep(Constats.TimeToWait.InMilliseconds);
                Console.ResetColor();
            }
            else
            {
                userProductCart.Add(new Product {Name = "Alcohol"});
            }
        }

        public override bool Equals(object someUser)
        {
            if (someUser == null || this.GetType() != someUser.GetType())
            {
                return false;
            }

            var user = (User) someUser;
            return PassportId.Equals(user.PassportId);
        }
    }
}
