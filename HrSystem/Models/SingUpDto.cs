using System.ComponentModel.DataAnnotations;

namespace HrSystem.Models
{
    public class SingUpDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string Phone { get; set; }


    }
}
