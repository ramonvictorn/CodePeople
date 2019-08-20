using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace CodePeople.Model{  
    public class PersonContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasIndex(p => new { p.Cpf, p.Email })
                .IsUnique(true);
        }
    }
}