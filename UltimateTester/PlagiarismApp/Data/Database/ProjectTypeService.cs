namespace PlagiarismApp.Data.Database
{
    public class ProjectTypeService : Service<ProjectType>
    {
        public override Task<ProjectType> GetItemAsync(int id)
        {
            return Task.FromResult(database.ProjectTypes.First(l => l.Id == id));
        }

        public override Task<ProjectType[]> GetItemsAsync()
        {
            return Task.FromResult(database.ProjectTypes.ToArray());
        }
    }
}