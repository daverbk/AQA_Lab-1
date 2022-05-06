using System.Net;
using ApiHomework.Clients;
using ApiHomework.Models;
using NUnit.Framework;

namespace ApiHomework.Tests;

public class MilestoneNegativeTests : BaseTest
{
    private Project _onSiteProject = null!;
    private Milestone _onSiteMilestone = null!;

    [OneTimeSetUp]
    public void CreateNewProject()
    {
        var newProject = FakeProject.Generate();
        _onSiteProject = AdminProjectService.AddProject(newProject).Result;

        var newMilestone = FakeMilestone.Generate();
        _onSiteMilestone = AdminMilestoneService.AddMilestone(newMilestone, _onSiteProject.Id.ToString()).Result;
    }
    
    [Category("Negative tests")]
    [Test]
    public void NoAccessUser_AddMilestone_Forbidden()
    {
        var milestoneToAdd = FakeMilestone.Generate();
        UserMilestoneService.AddMilestone(milestoneToAdd, _onSiteProject.Id.ToString()).Wait();

        Assert.AreEqual(HttpStatusCode.Forbidden, RestClientExtended.LastCallResponse.StatusCode);
    }

    [Category("Negative tests")]
    [Test]
    public void NoAccessUser_GetMilestone_Forbidden()
    {
        UserMilestoneService.GetMilestone(_onSiteMilestone.Id.ToString()).Wait();

        Assert.AreEqual(HttpStatusCode.Forbidden, RestClientExtended.LastCallResponse.StatusCode);
    }

    [Category("Negative tests")]
    [Test]
    public void NoAccessUser_UpdateMilestone_Forbidden()
    {
        var newMilestoneBody = FakeMilestone.Generate();
        newMilestoneBody.Id = _onSiteMilestone.Id;

        UserMilestoneService.UpdateMilestone(newMilestoneBody).Wait();
        Assert.AreEqual(HttpStatusCode.Forbidden, RestClientExtended.LastCallResponse.StatusCode);
    }

    [Category("Negative tests")]
    [Test]
    public void NoAccessUser_GetMilestones_Forbidden()
    {
        UserMilestoneService.GetMilestones(_onSiteProject.Id.ToString()).Wait();
        Assert.AreEqual(HttpStatusCode.Forbidden, RestClientExtended.LastCallResponse.StatusCode);
    }

    [Category("Negative tests")]
    [Test]
    public void NoAccessUser_DeleteMilestone_Forbidden()
    {
        var deletionCallStatusCode = UserMilestoneService.DeleteMilestone(_onSiteMilestone.Id.ToString());
        Assert.AreEqual(HttpStatusCode.Forbidden, deletionCallStatusCode);
    }
    
    [Category("Negative tests")]
    [Test]
    public void UnauthorizedUser_AddMilestone_Unauthorized()
    {
        var milestoneToAdd = FakeMilestone.Generate();
        UnauthorizedUserMilestoneService.AddMilestone(milestoneToAdd, _onSiteProject.Id.ToString()).Wait();

        Assert.AreEqual(HttpStatusCode.Unauthorized, RestClientExtended.LastCallResponse.StatusCode);
    }

    [Category("Negative tests")]
    [Test]
    public void UnauthorizedUser_GetMilestone_Unauthorized()
    {
        UnauthorizedUserMilestoneService.GetMilestone(_onSiteMilestone.Id.ToString()).Wait();

        Assert.AreEqual(HttpStatusCode.Unauthorized, RestClientExtended.LastCallResponse.StatusCode);
    }

    [Category("Negative tests")]
    [Test]
    public void UnauthorizedUser_UpdateMilestone_Unauthorized()
    {
        var newMilestoneBody = FakeMilestone.Generate();
        newMilestoneBody.Id = _onSiteMilestone.Id;

        UnauthorizedUserMilestoneService.UpdateMilestone(newMilestoneBody).Wait();
        Assert.AreEqual(HttpStatusCode.Unauthorized, RestClientExtended.LastCallResponse.StatusCode);
    }

    [Category("Negative tests")]
    [Test]
    public void UnauthorizedUser_GetMilestones_Unauthorized()
    {
        UnauthorizedUserMilestoneService.GetMilestones(_onSiteProject.Id.ToString()).Wait();
        Assert.AreEqual(HttpStatusCode.Unauthorized, RestClientExtended.LastCallResponse.StatusCode);
    }

    [Category("Negative tests")]
    [Test]
    public void UnauthorizedUser_DeleteMilestone_Unauthorized()
    {
        var deletionCallStatusCode = UnauthorizedUserMilestoneService.DeleteMilestone(_onSiteMilestone.Id.ToString());
        Assert.AreEqual(HttpStatusCode.Unauthorized, deletionCallStatusCode);
    }
    
    [Test]
    [Category("Negative tests")]
    [TestCase("0")]
    [TestCase("-1")]
    [TestCase("0,1")]
    [TestCase("*")]
    [TestCase("a")]
    public void BadId_AddMilestone_BadRequest(string fakeId)
    {
        var milestoneToAdd = FakeMilestone.Generate();
        AdminMilestoneService.AddMilestone(milestoneToAdd, fakeId).Wait();

        Assert.AreEqual(HttpStatusCode.BadRequest, RestClientExtended.LastCallResponse.StatusCode);
    }

    [Test]
    [Category("Negative tests")]
    [TestCase("0")]
    [TestCase("-1")]
    [TestCase("0,1")]
    [TestCase("-0,1")]
    [TestCase("*")]
    [TestCase("a")]
    public void BadId_GetMilestone_BadRequest(string fakeId)
    {
        AdminMilestoneService.GetMilestone(fakeId).Wait();

        Assert.AreEqual(HttpStatusCode.BadRequest, RestClientExtended.LastCallResponse.StatusCode);
    }

    [Test]
    [Category("Negative tests")]
    [TestCase(0)]
    [TestCase(-1)]
    public void BadId_UpdateMilestone_BadRequest(int fakeId)
    {
        var newMilestoneBody = FakeMilestone.Generate();
        newMilestoneBody.Id = fakeId;

        AdminMilestoneService.UpdateMilestone(newMilestoneBody).Wait();

        Assert.AreEqual(HttpStatusCode.BadRequest, RestClientExtended.LastCallResponse.StatusCode);
    }

    [Test]
    [Category("Negative tests")]
    [TestCase("0")]
    [TestCase("-1")]
    [TestCase("0,1")]
    [TestCase("-0,1")]
    [TestCase("*")]
    [TestCase("a")]
    public void BadId_GetMilestones_BadRequest(string fakeId)
    {
        AdminMilestoneService.GetMilestones(fakeId).Wait();
        Assert.AreEqual(HttpStatusCode.BadRequest, RestClientExtended.LastCallResponse.StatusCode);
    }

    [Test]
    [Category("Negative tests")]
    [TestCase("0")]
    [TestCase("-1")]
    [TestCase("0,1")]
    [TestCase("-0,1")]
    [TestCase("*")]
    [TestCase("a")]
    public void BadId_DeleteMilestone_BadRequest(string fakeId)
    {
        var deletionCallStatusCode = AdminMilestoneService.DeleteMilestone(fakeId);
        Assert.AreEqual(HttpStatusCode.BadRequest, deletionCallStatusCode);
    }

    [Category("Negative tests")]
    [Test]
    public void NoNameParameter_AddMilestone_BadRequest()
    {
        var milestoneToAdd = FakeMilestone.Generate();
        milestoneToAdd.Name = null;

        AdminMilestoneService.AddMilestone(milestoneToAdd, _onSiteProject.Id.ToString()).Wait();

        Assert.AreEqual(HttpStatusCode.BadRequest, RestClientExtended.LastCallResponse.StatusCode);
    }

    [OneTimeTearDown]
    public void DeleteNewProject()
    {
        AdminProjectService.DeleteProject(_onSiteProject.Id.ToString());
    }
}
