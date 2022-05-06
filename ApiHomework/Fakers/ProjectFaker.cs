using ApiHomework.Models;
using Bogus;

namespace ApiHomework.Fakers;

public sealed class ProjectFaker : Faker<Project>
{
    private const int MinSuiteMode = 1;
    private const int MaxSuiteMode = 3;

    public ProjectFaker()
    {
        RuleFor(p => p.Name, f => f.Commerce.ProductName());
        RuleFor(p => p.Announcement, f => f.Company.CatchPhrase());
        RuleFor(p => p.SuiteMode, f => f.Random.Int(MinSuiteMode, MaxSuiteMode));
        RuleFor(p => p.ShowAnnouncement, f => f.Random.Bool());
    }
}
