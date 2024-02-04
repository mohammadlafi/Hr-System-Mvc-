using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace HrSystem.Data
{
    public class HrContext:IdentityDbContext<ApplicationUser>
    {
        public DbSet<Employee>  employee { get; set; }

        public DbSet<Department> department { get; set; }

        public DbSet<Country> country { get; set; }

        public DbSet<City> city { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=localhost;initial Catalog=HrSystem;integrated security=true");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
