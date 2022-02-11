using Microsoft.EntityFrameworkCore;

namespace TechnicalTestApi.Models
{
    public class RegistrationContext : DbContext
    {
        public RegistrationContext(DbContextOptions<RegistrationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
        }
        public DbSet<Registration> Registrations { get; set; }
    }
}
