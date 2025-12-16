using EmployeeListApp.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeListApp.Services
{
    public class EmployeesService
    {
        private readonly AppDbContext _db;

        public EmployeesService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _db.Employees.OrderBy(e => e.FullName).ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(string id)
        {
            return await _db.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            if (string.IsNullOrWhiteSpace(employee.Id))
                employee.Id = Guid.NewGuid().ToString();

            _db.Employees.Add(employee);
            await _db.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            var existing = await _db.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);
            if (existing is null) return false;

            existing.FullName = employee.FullName;
            existing.Department = employee.Department;
            existing.Salary = employee.Salary;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var existing = await _db.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (existing is null) return false;

            _db.Employees.Remove(existing);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
