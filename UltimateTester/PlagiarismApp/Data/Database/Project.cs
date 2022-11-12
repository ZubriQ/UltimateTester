using System;
using System.Collections.Generic;

namespace PlagiarismApp.Data.Database
{
    public partial class Project
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? GitUrl { get; set; }
        public string? PathOnDisc { get; set; }
        public int StudentId { get; set; }
        public int ProjectTypeId { get; set; }
        public double OriginalityPercentage { get; set; }
        public DateTime DateOfPassing { get; set; }

        public virtual ProjectType? ProjectType { get; set; } = null;
        public virtual Student? Student { get; set; } = null;
    }
}
