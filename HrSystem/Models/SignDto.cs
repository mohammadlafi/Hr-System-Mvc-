using System.ComponentModel.DataAnnotations;

namespace HrSystem.Models
{
    public class SignDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string  Password { get; set; }

        public bool Rememberme { get; set; }
    }
}
