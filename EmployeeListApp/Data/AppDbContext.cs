using Microsoft.EntityFrameworkCore;

namespace EmployeeListApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet za tablicu zaposlenika
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definiraj preciznost za polje Salary
            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasColumnType("decimal(18,2)");
        }
    }
    
    
}
