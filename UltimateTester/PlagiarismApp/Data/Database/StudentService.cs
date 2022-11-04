using Microsoft.EntityFrameworkCore;

namespace PlagiarismApp.Data.Database
{
    public class StudentService : Service<Student>
    {
        public override Task<Student> GetItemAsync(int id)
        {
            return Task.FromResult(database.Students.First(s => s.Id == id));
        }

        public override Task<Student[]> GetItemsAsync()
        {
            var students = database.Students.Include(s => s.Group).ToArray();
            return Task.FromResult(students);
        }
    }
}