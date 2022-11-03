namespace PlagiarismApp.Data.Database
{
    public class GroupService : Service<Group>
    {
        public override Task<Group[]> GetItemsAsync()
        {
            return Task.FromResult(database.Groups.ToArray());
        }
    }
}