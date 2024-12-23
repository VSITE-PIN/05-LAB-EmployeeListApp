using Microsoft.EntityFrameworkCore;

namespace EmployeeListApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Define your DbSets here
        public DbSet<Employee> Employees { get; set; }
    }
}
