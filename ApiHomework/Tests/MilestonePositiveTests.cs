using System.Net;
using ApiHomework.Clients;
using ApiHomework.Models;
using NUnit.Framework;

namespace ApiHomework.Tests;

public class MilestonePositiveTests : BaseTest
{
    private Project _onSiteProject = null!;
    private Milestone _onSiteMilestone = null!;

    [OneTimeSetUp]
    public void CreateNewProject()
    {
        var newProject = FakeProject.Generate();
        _onSiteProject = AdminProjectService.AddProject(newProject).Result;
    }

    [Test]
    [Category("Positive tests")]
    [Order(1)]
    public void AddMilestoneTest()
    {
        var milestoneToAdd = FakeMilestone.Generate();

        _onSiteMilestone = AdminMilestoneService.AddMilestone(milestoneToAdd, _onSiteProject.Id.ToString()).Result;
        
        Assert.Multiple(() =>
        {
            Assert.AreEqual(HttpStatusCode.OK, RestClientExtended.LastCallResponse.StatusCode);
            Assert.AreEqual(milestoneToAdd.Name, _onSiteMilestone.Name);
            Assert.AreEqual(milestoneToAdd.Description, _onSiteMilestone.Description);
            Assert.AreEqual(milestoneToAdd.Refs, _onSiteMilestone.Refs); 
        });
    }

    [Test]
    [Category("Positive tests")]
    [Order(2)]
    public void GetMilestoneTest()
    {
        var addedMilestone = _onSiteMilestone;
        var gotMilestone = AdminMilestoneService.GetMilestone(_onSiteMilestone.Id.ToString()).Result;

        Assert.Multiple(() =>
        {
            Assert.AreEqual(HttpStatusCode.OK, RestClientExtended.LastCallResponse.StatusCode);
            Assert.AreEqual(addedMilestone.Name, gotMilestone.Name);
            Assert.AreEqual(addedMilestone.Description, gotMilestone.Description);
            Assert.AreEqual(addedMilestone.Refs, gotMilestone.Refs); 
        });
    }

    [Test]
    [Category("Positive tests")]
    [Order(3)]
    public void UpdateMilestoneTest()
    {
        var newMilestoneBody = FakeMilestone.Generate();
        newMilestoneBody.Id = _onSiteMilestone.Id;
        newMilestoneBody.IsStarted = true;
        
        _onSiteMilestone = AdminMilestoneService.UpdateMilestone(newMilestoneBody).Result;

        Assert.Multiple(() =>
        {
            Assert.AreEqual(HttpStatusCode.OK, RestClientExtended.LastCallResponse.StatusCode);
            Assert.AreEqual(newMilestoneBody.Name, _onSiteMilestone.Name);
            Assert.AreEqual(newMilestoneBody.Description, _onSiteMilestone.Description);
            Assert.AreEqual(newMilestoneBody.Refs, _onSiteMilestone.Refs);
            Assert.AreEqual(newMilestoneBody.IsStarted, _onSiteMilestone.IsStarted);
        });
    }
    
    [Test]
    [Category("Positive tests")]
    [Order(4)]
    public void GetMilestonesTest()
    {
        var milestones = AdminMilestoneService.GetMilestones(_onSiteProject.Id.ToString()).Result;
        
        Assert.Multiple(() => 
        {
            Assert.AreEqual(HttpStatusCode.OK, RestClientExtended.LastCallResponse.StatusCode);
            Assert.AreEqual(1 ,milestones.MilestoneList.Length);
        });
    }
    
    [Test]
    [Category("Positive tests")]
    [Order(5)]
    public void DeleteMilestoneTest()
    {
        var deletionCallStatusCode = AdminMilestoneService.DeleteMilestone(_onSiteMilestone.Id.ToString());
        Assert.AreEqual(HttpStatusCode.OK, deletionCallStatusCode);
        
        var milestonesAfterDeletion = AdminMilestoneService.GetMilestones(_onSiteProject.Id.ToString()).Result;
        Assert.AreEqual(0, milestonesAfterDeletion.MilestoneList.Length);
    }

    [OneTimeTearDown]
    public void DeleteNewProject()
    {
        AdminProjectService.DeleteProject(_onSiteProject.Id.ToString());
    }
}
