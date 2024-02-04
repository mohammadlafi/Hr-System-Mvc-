using System.ComponentModel.DataAnnotations;

namespace HrSystem.Models
{
    public class RoleDto
    {
        [Required]
        public string Name { get; set; }
        public string id { get; set; }

        public bool IsSelcted { get; set; }


    }
}
