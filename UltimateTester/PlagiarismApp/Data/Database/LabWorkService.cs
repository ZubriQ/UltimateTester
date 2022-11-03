namespace PlagiarismApp.Data.Database
{
    public class LabWorkService : Service<LabWork>
    {
        public override Task<LabWork[]> GetItemsAsync()
        {
            return Task.FromResult(database.LabWorks.ToArray());
        }
    }
}