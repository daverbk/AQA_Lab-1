using System;
using System.Net;
using System.Threading.Tasks;
using ApiHomework.Clients;
using ApiHomework.Models;
using RestSharp;

namespace ApiHomework.Services;

public class ProjectService : IProjectService, IDisposable
{
    private readonly RestClientExtended _restClient;

    public ProjectService(RestClientExtended restClient)
    {
        _restClient = restClient;
    }

    public Task<Project> GetProject(string projectId)
    {
        var request = new RestRequest("index.php?/api/v2/get_project/{project_id}")
            .AddUrlSegment("project_id", projectId);

        return _restClient.ExecuteAsync<Project>(request);
    }

    public Task<Projects> GetProjects()
    {
        var request = new RestRequest("index.php?/api/v2/get_projects");

        return _restClient.ExecuteAsync<Projects>(request);
    }

    public Task<Project> AddProject(Project project)
    {
        var request = new RestRequest("index.php?/api/v2/add_project", Method.Post)
            .AddJsonBody(project);

        return _restClient.ExecuteAsync<Project>(request);
    }

    public Task<Project> UpdateProject(Project project)
    {
        var request = new RestRequest("index.php?/api/v2/update_project/{project_id}", Method.Post)
            .AddUrlSegment("project_id", project.Id)
            .AddJsonBody(project);

        return _restClient.ExecuteAsync<Project>(request);
    }

    public HttpStatusCode DeleteProject(string projectId)
    {
        var request = new RestRequest("index.php?/api/v2/delete_project/{project_id}", Method.Post)
            .AddUrlSegment("project_id", projectId)
            .AddJsonBody("{}");

        return _restClient.ExecuteAsync(request).Result.StatusCode;
    }

    public void Dispose()
    {
        _restClient.Dispose();
        GC.SuppressFinalize(this);
    }
}
