using System;
using System.Collections.Generic;

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

        public bool Equals(User someUser)
        {
            return PassportId.Equals(someUser.PassportId);
        }
    }
}
