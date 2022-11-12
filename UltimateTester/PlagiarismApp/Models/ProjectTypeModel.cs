using System.ComponentModel.DataAnnotations;

namespace PlagiarismApp.Models
{
    public class ProjectTypeModel
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        public string? Description { get; set; }

        public ProjectTypeModel()
        {

        }
    }
}
