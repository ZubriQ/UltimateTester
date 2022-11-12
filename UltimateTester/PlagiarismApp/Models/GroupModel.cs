using System.ComponentModel.DataAnnotations;

namespace PlagiarismApp.Models
{
    public class GroupModel
    {
        [Required, MaxLength(10)]
        public string Name { get; set; }

        [Required, Range(2000, 2100)]
        public int Year { get; set; }

        public GroupModel()
        {

        }
    }
}
