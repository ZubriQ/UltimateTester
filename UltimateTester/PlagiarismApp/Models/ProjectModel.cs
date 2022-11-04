using PlagiarismApp.Data.Database;
using System.ComponentModel.DataAnnotations;

namespace PlagiarismApp.Models
{
    public class ProjectModel
    {
        [MaxLength(50)] // not required yet
        public string Name { get; set; }

        [MaxLength(100)] // TODO: not required yet
        public string GitUrl { get; set; }

        [MaxLength(260)] // TODO: not required yet
        public string PathOnDisc { get; set; }

        [Required]
        public Student Student { get; set; }

        [Required]
        public LabWork LabWork { get; set; }

        public ProjectModel()
        {

        }
    }
}
