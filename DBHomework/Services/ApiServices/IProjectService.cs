using System.Net;
using System.Threading.Tasks;
using DBHomework.Models;

namespace DBHomework.Services.ApiServices;

public interface IProjectService
{
    Task<Project> GetProject(string projectId);

    Task<Projects> GetProjects();

    Task<Project> AddProject(Project project);

    Task<Project> UpdateProject(Project project);

    HttpStatusCode DeleteProject(string projectId);
}
