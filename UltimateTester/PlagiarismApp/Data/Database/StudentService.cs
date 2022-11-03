using Microsoft.EntityFrameworkCore;

namespace PlagiarismApp.Data.Database
{
    public class StudentService : Service<Student>
    {
        public override void Add(Student item)
        {
            database.Students.Add(item);
        }

        public override Task<Student[]> GetItemsAsync()
        {
            var students = database.Students.Include(s => s.Group).ToArray();
            return Task.FromResult(students);
        }
    }
}