namespace PlagiarismApp.Data.Database
{
    public class LabWorkService : Service<LabWork>
    {
        public override Task<LabWork> GetItemAsync(int id)
        {
            return Task.FromResult(database.LabWorks.First(l => l.Id == id));
        }

        public override Task<LabWork[]> GetItemsAsync()
        {
            return Task.FromResult(database.LabWorks.ToArray());
        }
    }
}