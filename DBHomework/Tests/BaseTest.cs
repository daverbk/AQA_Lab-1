using DBHomework.Clients;
using DBHomework.Services.ApiServices;
using NUnit.Framework;

namespace DBHomework.Tests;

public class BaseTest
{
    protected ProjectService AdminProjectService = null!;
    protected MilestoneService AdminMilestoneService = null!;

    [OneTimeSetUp]
    public void SetUpApi()
    {
        var adminRestClient = new RestClientExtended();
        AdminProjectService = new ProjectService(adminRestClient);
        AdminMilestoneService = new MilestoneService(adminRestClient);
    }
}
