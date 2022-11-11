using System.ComponentModel.DataAnnotations;

namespace PlagiarismApp.Models
{
    public class GroupModel
    {
        [Required, MaxLength(10)]
        public string Name { get; set; }

        public GroupModel()
        {

        }
    }
}
