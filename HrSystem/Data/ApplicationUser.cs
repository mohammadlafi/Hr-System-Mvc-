using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HrSystem.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
