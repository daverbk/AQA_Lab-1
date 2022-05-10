using System.Net;
using System.Threading.Tasks;
using DBHomework.Models;

namespace DBHomework.Services.ApiServices;

public interface IMilestoneService
{
    Task<Milestone> GetMilestone(string milestoneId);

    Task<Milestones> GetMilestones(string projectId);

    Task<Milestone> AddMilestone(Milestone milestone, string projectId);

    Task<Milestone> UpdateMilestone(Milestone milestone);

    HttpStatusCode DeleteMilestone(string milestoneId);
}
