namespace PlagiarismApp.Data.Database
{
    public class ProjectService : Service<Project>
    {
        public override Task<Project[]> GetItemsAsync()
        {
            return Task.FromResult(database.Projects.ToArray());
        }
    }
}