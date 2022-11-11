using Microsoft.AspNetCore.Mvc;
using PlagiarismApp.Data.Database;

namespace PlagiarismApp.Controllers
{
    public static class ControllerHelper
    {
        public static void UpdateProjectValues(Project destination, Project source)
        {
            destination.Name = source.Name;
            destination.GitUrl = source.GitUrl;
            destination.PathOnDisc = source.PathOnDisc;
        }

        public static async Task<Project> UpdateAndSaveProject(IdentityDataContext context, Project project)
        {
            context.Projects.Update(project);
            await context.SaveChangesAsync();
            return project;
        }
    }
}
