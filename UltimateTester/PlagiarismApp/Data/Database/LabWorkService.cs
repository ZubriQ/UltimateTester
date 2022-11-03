namespace PlagiarismApp.Data.Database
{
    public class LabWorkService : Service<LabWork>
    {
        public override void Add(LabWork item)
        {
            database.LabWorks.Add(item);
        }

        public override Task<LabWork[]> GetItemsAsync()
        {
            return Task.FromResult(database.LabWorks.ToArray());
        }
    }
}