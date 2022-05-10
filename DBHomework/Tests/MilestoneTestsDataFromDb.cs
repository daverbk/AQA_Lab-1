using System;
using System.Net;
using DBHomework.Clients;
using DBHomework.Databases;
using DBHomework.Models;
using NLog;
using NUnit.Framework;

namespace DBHomework.Tests;

public class MilestoneTestsDataFromDb : BaseTest
{
    private Logger _logger = LogManager.GetCurrentClassLogger();
    
    private Project _fromDbProject = null!;
    private Milestone _fromDbMilestone = null!;
    
    private Project _onSiteProject = null!;
    private Milestone _onSiteMilestone = null!;
    
    [OneTimeSetUp]
    public void CreateNewProject()
    {
        using (var dbConnector = new DataBaseConnector())
        {
            const int projectToAddDbId = 1;
            const int milestoneToAddDbId = 1;

            _fromDbProject = dbConnector.Projects.Find(projectToAddDbId) ??
                             throw new InvalidOperationException(
                                 $"No record with {projectToAddDbId} as primary key was found.");

             _logger.Info($"Successfully read {_fromDbProject.Name} from database.");
            
            _fromDbMilestone = dbConnector.Milestones.Find(milestoneToAddDbId) ??
                               throw new InvalidOperationException(
                                   $"No record with {milestoneToAddDbId} as primary key was found.");
            
            _logger.Info($"Successfully read {_fromDbMilestone.Name} from database.");
        }

        _onSiteProject = AdminProjectService.AddProject(_fromDbProject).Result;
    }

    [Test]
    [Category("Positive tests")]
    [Order(1)]
    public void AddMilestoneTest()
    {
        var milestoneToAdd = _fromDbMilestone;

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
        Milestone newMilestoneBody;
        
        using (var dbConnector = new DataBaseConnector())
        {
            const int updatedMilestoneToAddDbId = 2;

            newMilestoneBody = dbConnector.Milestones.Find(updatedMilestoneToAddDbId) ??
                               throw new InvalidOperationException(
                                   $"No record with {updatedMilestoneToAddDbId} as primary key was found.");
            
            _logger.Info($"Successfully read {newMilestoneBody.Name} from database.");
        }

        newMilestoneBody.Id = _onSiteMilestone.Id;
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
            Assert.AreEqual(1 ,milestones.MilestoneList.Count);
            Assert.AreEqual(1, milestones.Size);
            
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
        Assert.AreEqual(0, milestonesAfterDeletion.MilestoneList.Count);
    }


    [OneTimeTearDown]
    public void DeleteNewProject()
    {
        AdminProjectService.DeleteProject(_onSiteProject.Id.ToString());
    }
}
