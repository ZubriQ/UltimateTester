using System;
using System.Collections.Generic;

namespace PlagiarismApp.Data
{
    public partial class LabWork
    {
        public LabWork()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
