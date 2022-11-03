namespace PlagiarismApp.Data.Database
{
    public class GroupService : Service<Group>
    {
        public override void Add(Group item)
        {
            database.Groups.Add(item);
        }

        public override Task<Group[]> GetItemsAsync()
        {
            return Task.FromResult(database.Groups.ToArray());
        }
    }
}