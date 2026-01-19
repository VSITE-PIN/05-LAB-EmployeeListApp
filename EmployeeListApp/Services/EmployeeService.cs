
using EmployeeListApp.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeListApp.Services
{
	public class EmployeesService
	{
		private readonly AppDbContext _db;

		public EmployeesService(AppDbContext db) => _db = db;

		public async Task<List<Employee>> GetAllAsync()
			=> await _db.Employees.AsNoTracking().ToListAsync();

		public async Task<Employee?> GetByIdAsync(string id)
			=> await _db.Employees.FirstOrDefaultAsync(e => e.Id == id);

		public async Task AddAsync(Employee employee)
		{
			if (string.IsNullOrWhiteSpace(employee.Id))
				employee.Id = Guid.NewGuid().ToString();

			_db.Employees.Add(employee);
			await _db.SaveChangesAsync();
		}

		public async Task UpdateAsync(Employee employee)
		{
			var existing = await _db.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);
			if (existing == null) return;

			existing.FullName = employee.FullName;
			existing.Department = employee.Department;
			existing.Salary = employee.Salary;

			await _db.SaveChangesAsync();
		}

		public async Task DeleteAsync(string id)
		{
			var existing = await _db.Employees.FirstOrDefaultAsync(e => e.Id == id);
			if (existing == null) return;

			_db.Employees.Remove(existing);
			await _db.SaveChangesAsync();
		}
	}
}
