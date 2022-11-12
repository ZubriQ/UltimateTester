using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PlagiarismApp.Pages.Catalogs;

namespace PlagiarismApp.Data.Database
{
    public class ProjectService : Service<Project>
    {
        public List<Project>? Projects { get; set; }

        private HttpClient client { get; set; } = new();

        public override Task<Project> GetItemAsync(int studentId)
        {
            return Task.FromResult(database.Projects.First(p => p.StudentId == studentId));
        }

        public Task<Project> GetItemAsync(int studentId, int labId)
        {
            return Task.FromResult(database.Projects.First(p => p.StudentId == studentId &&
                                                                p.ProjectTypeId == labId));
        }

        public override Task<Project[]> GetItemsAsync()
        {
            Project[] projects = database.Projects.Include(p => p.ProjectType)
                                                  .Include(p => p.Student)
                                                  .ToArray();
            return Task.FromResult(projects);
        }

        public async void GetItemsAsync(NavigationManager navigationManager)
        {
            Projects = await client.GetFromJsonAsync<List<Project>>
                (navigationManager.BaseUri + "api/data/getprojects");
        }
    }
}