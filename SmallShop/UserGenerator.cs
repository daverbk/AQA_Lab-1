using System;
using System.Collections.Generic;
using Bogus;

namespace SmallShop
{
    public static class UserGenerator
    {
        public static List<User> GenerateUsers(int count, List<Product> products)
        {
            var userFaker = new Faker<User>().RuleFor(x => x.FirstName, x => x.Person.FirstName)
                .RuleFor(x => x.Age, x => x.Random.Int(Constats.PersonAge.Min, Constats.PersonAge.Max))
                .RuleFor(x => x.PassportId, x => Guid.NewGuid())
                .RuleFor(x => x.ShoppingCart, x => new List<Product>(products));

            return userFaker.Generate(count);
        }
    }
}
