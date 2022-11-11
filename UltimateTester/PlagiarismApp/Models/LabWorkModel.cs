using System.ComponentModel.DataAnnotations;

namespace PlagiarismApp.Models
{
    public class LabWorkModel
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        public string? Description { get; set; }

        public LabWorkModel()
        {

        }
    }
}
