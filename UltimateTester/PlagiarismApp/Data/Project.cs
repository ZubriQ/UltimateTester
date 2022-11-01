using System;
using System.Collections.Generic;

namespace PlagiarismApp.Data
{
    public partial class Project
    {
        public string? Name { get; set; }
        public string? GitUrl { get; set; }
        public string? PathOnDisc { get; set; }
        public int StudentId { get; set; }
        public int LabWorkId { get; set; }

        public virtual LabWork LabWork { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
