using System;
using System.Net;
using System.Threading;
using ApiHomework.Clients;
using ApiHomework.Models;
using NUnit.Framework;

namespace ApiHomework.Tests;

public class MilestoneTooManyRequestsTests : BaseTest
{
    private const int SecondsToRenewCalls = 55;

    private Project _onSiteProject = null!;
    private Milestone _onSiteMilestone = null!;

    [OneTimeSetUp]
    public void CreateNewProject()
    {
        var newProject = FakeProject.Generate();
        _onSiteProject = AdminProjectService.AddProject(newProject).Result;
    }

    [Test]
    [Category("Too many requests tests")]
    [Order(1)]
    public void AddMilestoneTooManyRequestsTest()
    {
        var milestoneToAdd = FakeMilestone.Generate();
        _onSiteMilestone = AdminMilestoneService.AddMilestone(milestoneToAdd, _onSiteProject.Id.ToString()).Result;
        
        while(RestClientExtended.LastCallResponse.StatusCode != HttpStatusCode.TooManyRequests)
        {
            AdminMilestoneService.AddMilestone(milestoneToAdd, _onSiteProject.Id.ToString());
        }
        
        Assert.AreEqual(HttpStatusCode.TooManyRequests, RestClientExtended.LastCallResponse.StatusCode);
    }
    
    [Test]
    [Category("Too many requests tests")]
    [Order(2)]
    public void GetMilestoneTooManyRequestsTest()
    {
        AdminMilestoneService.GetMilestone(_onSiteMilestone.Id.ToString());
        Assert.AreEqual(HttpStatusCode.TooManyRequests, RestClientExtended.LastCallResponse.StatusCode);
    }
    
    [Test]
    [Category("Too many requests tests")]
    [Order(3)]
    public void UpdateMilestoneTooManyRequestsTest()
    {
        var newMilestoneBody = FakeMilestone.Generate();
        newMilestoneBody.Id = _onSiteMilestone.Id;
        newMilestoneBody.IsStarted = true;
        
        AdminMilestoneService.UpdateMilestone(newMilestoneBody);
        Assert.AreEqual(HttpStatusCode.TooManyRequests, RestClientExtended.LastCallResponse.StatusCode);
    }
    
    [Test]
    [Category("Too many requests tests")]
    [Order(4)]
    public void GetMilestonesTooManyRequestsTest()
    {
        AdminMilestoneService.GetMilestones(_onSiteProject.Id.ToString());
        Assert.AreEqual(HttpStatusCode.TooManyRequests, RestClientExtended.LastCallResponse.StatusCode);
    }
    
    [Test]
    [Category("Too many requests tests")]
    [Order(5)]
    public void DeleteMilestoneTooManyRequestsTest()
    {
        AdminMilestoneService.DeleteMilestone(_onSiteMilestone.Id.ToString());

        Assert.AreEqual(HttpStatusCode.TooManyRequests, RestClientExtended.LastCallResponse.StatusCode);
        Thread.Sleep(TimeSpan.FromSeconds(SecondsToRenewCalls)); 
        // TODO: Improve the wait until calls are possible. It's needed to then successfully make a delete-project-call.
    }

    [OneTimeTearDown]
    public void DeleteNewProject()
    {
        AdminProjectService.DeleteProject(_onSiteProject.Id.ToString());
    }
}
