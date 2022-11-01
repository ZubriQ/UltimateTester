using System;
using System.Collections.Generic;

namespace PlagiarismApp.Data
{
    public partial class Student
    {
        public Student()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Patronymic { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; } = null!;
        public virtual ICollection<Project> Projects { get; set; }
    }
}
