using Microsoft.EntityFrameworkCore;

namespace PlagiarismApp.Data.Database
{
    public class GroupService : Service<Group>
    {
        public override Task<Group> GetItemAsync(int id)
        {
            return Task.FromResult(database.Groups.First(g => g.Id == id));
        }

        public override Task<Group[]> GetItemsAsync()
        {
            return Task.FromResult(database.Groups.ToArray());
        }
    }
}