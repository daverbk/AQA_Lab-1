using System;
using System.Net;
using System.Threading.Tasks;
using DBHomework.Clients;
using DBHomework.Models;
using RestSharp;

namespace DBHomework.Services.ApiServices;

public class MilestoneService : IMilestoneService, IDisposable
{
    private readonly RestClientExtended _restClient;

    public MilestoneService(RestClientExtended restClient)
    {
        _restClient = restClient;
    }

    public Task<Milestone> GetMilestone(string milestoneId)
    {
        var request = new RestRequest("index.php?/api/v2/get_milestone/{milestone_id}")
            .AddUrlSegment("milestone_id", milestoneId);

        return _restClient.ExecuteAsync<Milestone>(request);
    }

    public Task<Milestones> GetMilestones(string projectId)
    {
        var request = new RestRequest("index.php?/api/v2/get_milestones/{project_id}")
            .AddUrlSegment("project_id", projectId);

        return _restClient.ExecuteAsync<Milestones>(request);
    }

    public Task<Milestone> AddMilestone(Milestone milestone, string projectId)
    {
        var request = new RestRequest("index.php?/api/v2/add_milestone/{project_id}", Method.Post)
            .AddUrlSegment("project_id", projectId)
            .AddJsonBody(milestone);

        return _restClient.ExecuteAsync<Milestone>(request);
    }

    public Task<Milestone> UpdateMilestone(Milestone milestone)
    {
        var request = new RestRequest("index.php?/api/v2/update_milestone/{milestone_id}", Method.Post)
            .AddUrlSegment("milestone_id", milestone.Id)
            .AddJsonBody(milestone);

        return _restClient.ExecuteAsync<Milestone>(request);
    }

    public HttpStatusCode DeleteMilestone(string milestoneId)
    {
        var request = new RestRequest("index.php?/api/v2/delete_milestone/{milestone_id}", Method.Post)
            .AddUrlSegment("milestone_id", milestoneId)
            .AddJsonBody("{}");

        return _restClient.ExecuteAsync(request).Result.StatusCode;
    }

    public void Dispose()
    {
        _restClient.Dispose();
        GC.SuppressFinalize(this);
    }
}
