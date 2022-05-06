using ApiHomework.Models;
using Bogus;

namespace ApiHomework.Fakers;

public class MilestoneFaker : Faker<Milestone>
{
    public MilestoneFaker()
    {
        RuleFor(m => m.Name, f => f.Commerce.ProductName());
        RuleFor(m => m.Description, f => f.Company.CatchPhrase());
        RuleFor(m => m.Refs, f => f.Commerce.Ean8());
    }
}
