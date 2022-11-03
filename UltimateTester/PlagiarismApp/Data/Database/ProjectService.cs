using Microsoft.EntityFrameworkCore;

namespace PlagiarismApp.Data.Database
{
    public class ProjectService : Service<Project>
    {
        public override Task<Project[]> GetItemsAsync()
        {
            Project[] projects = database.Projects.Include(p => p.LabWork)
                                                  .Include(p => p.Student)
                                                  .ToArray();
            return Task.FromResult(projects);
        }
    }
}