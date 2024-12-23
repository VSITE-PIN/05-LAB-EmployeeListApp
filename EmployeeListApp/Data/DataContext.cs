using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeListApp.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) :
		base(options) { }

		public DbSet<Employee> Employees { get; set; }
	}
}
