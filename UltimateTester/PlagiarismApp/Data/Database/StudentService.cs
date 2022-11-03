namespace PlagiarismApp.Data.Database
{
    public class StudentService : Service<Student>
    {
        public override Task<Student[]> GetItemsAsync()
        {
            return Task.FromResult(database.Students.ToArray());
        }
    }
}