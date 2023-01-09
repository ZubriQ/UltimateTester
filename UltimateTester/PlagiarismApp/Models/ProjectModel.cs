using PlagiarismApp.Data.Database;
using System.ComponentModel.DataAnnotations;

namespace PlagiarismApp.Models
{
    public class ProjectModel
    {
        [MaxLength(50)] // not required yet
        public string? FileName { get; set; }

        [MaxLength(100)] // TODO: not required yet
        public string? GitUrl { get; set; }

        [MaxLength(260)] // TODO: not required yet
        public string? PathOnDisc { get; set; }

        public DateTime? DateOfPassing { get; set; }

        public double? OriginalityPercentage { get; set; }

        [Required]
        public int SelectedStudentId { get; set; }

        [Required]
        public int SelectedProjectTypeId { get; set; }

        public ProjectModel()
        {

        }
    }
}
