using System.ComponentModel.DataAnnotations;

namespace MediaManagement.Projects
{
    public class CreateUpdateProjectDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}