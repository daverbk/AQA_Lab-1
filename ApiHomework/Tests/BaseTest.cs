using ApiHomework.Clients;
using ApiHomework.Configuration.Enums;
using ApiHomework.Fakers;
using ApiHomework.Models;
using ApiHomework.Services;
using Bogus;
using NUnit.Framework;
using RestSharp;

namespace ApiHomework.Tests;

public class BaseTest
{
    protected ProjectService AdminProjectService;
    protected MilestoneService AdminMilestoneService;
    
    protected MilestoneService UserMilestoneService;

    protected MilestoneService UnauthorizedUserMilestoneService;

    protected static Faker<Project> FakeProject => new ProjectFaker();
    
    protected static Faker<Milestone> FakeMilestone => new MilestoneFaker();

    [OneTimeSetUp]
    public void SetUpApi()
    {
        var adminRestClient = new RestClientExtended(UserType.Admin);
        AdminProjectService = new ProjectService(adminRestClient);
        AdminMilestoneService = new MilestoneService(adminRestClient);
        
        var userRestClient = new RestClientExtended(UserType.User);
        UserMilestoneService = new MilestoneService(userRestClient);
        
        var unauthorizedUserRestClient = new RestClientExtended(UserType.Unauthorized);
        UnauthorizedUserMilestoneService = new MilestoneService(unauthorizedUserRestClient);
    }
}
