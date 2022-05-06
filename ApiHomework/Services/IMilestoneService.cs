using System.Net;
using System.Threading.Tasks;
using ApiHomework.Models;

namespace ApiHomework.Services;

public interface IMilestoneService
{
    Task<Milestone> GetMilestone(string milestoneId);

    Task<Milestones> GetMilestones(string projectId);

    Task<Milestone> AddMilestone(Milestone milestone, string projectId);

    Task<Milestone> UpdateMilestone(Milestone milestone);

    HttpStatusCode DeleteMilestone(string milestoneId);
}
