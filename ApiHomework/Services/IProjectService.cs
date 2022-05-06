using System.Net;
using System.Threading.Tasks;
using ApiHomework.Models;

namespace ApiHomework.Services;

public interface IProjectService
{
    Task<Project> GetProject(string projectId);

    Task<Projects> GetProjects();

    Task<Project> AddProject(Project project);

    Task<Project> UpdateProject(Project project);

    HttpStatusCode DeleteProject(string projectId);
}
