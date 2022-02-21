using System;
using System.Collections.Generic;
using Bogus;

namespace SmallShop
{
    public static class ProductGenerator
    {
        public static List<Product> GenerateProducts(int count)
        {
            var productFaker = new Faker<Product>().RuleFor(x => x.Barcode, x => x.Commerce.Ean8())
                .RuleFor(x => x.Category, x => x.Commerce.Product())
                .RuleFor(x => x.Name, x => x.Commerce.ProductName())
                .RuleFor(x => x.Price, x => Convert.ToDecimal(x.Commerce.Price()));

            return productFaker.Generate(count);
        }
    }
}
