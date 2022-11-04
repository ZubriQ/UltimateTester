using Microsoft.EntityFrameworkCore;

namespace PlagiarismApp.Data.Database
{
    public class ProjectService : Service<Project>
    {
        public override Task<Project> GetItemAsync(int studentId)
        {
            return Task.FromResult(database.Projects.First(p => p.StudentId == studentId));
        }

        public Task<Project> GetItemAsync(int studentId, int labId)
        {
            return Task.FromResult(database.Projects.First(p => p.StudentId == studentId &&
                                                                p.LabWorkId == labId));
        }

        public override Task<Project[]> GetItemsAsync()
        {
            Project[] projects = database.Projects.Include(p => p.LabWork)
                                                  .Include(p => p.Student)
                                                  .ToArray();
            return Task.FromResult(projects);
        }
    }
}