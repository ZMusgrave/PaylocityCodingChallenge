using Microsoft.EntityFrameworkCore;
namespace Api.Models;

public class CompanyContext : DbContext
{
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(c => c.Dependents)
                .WithOne(a => a.Employee)
                .HasForeignKey(a => a.EmployeeId);

            modelBuilder.Seed();
        }

        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<Employee> Employees { get; set; }
}
