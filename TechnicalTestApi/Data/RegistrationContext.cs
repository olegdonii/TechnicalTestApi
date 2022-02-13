using Microsoft.EntityFrameworkCore;
using TechnicalTestApi.Data.Models;

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
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
