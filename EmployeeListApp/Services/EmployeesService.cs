using EmployeeListApp.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeListApp.Services
{
    public class EmployeesService
    {
        private readonly AppDbContext _context;

        public EmployeesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees
                .OrderBy(e => e.FullName)
                .ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(string id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee> InsertEmployeeAsync(Employee employee)
        {
            if (string.IsNullOrWhiteSpace(employee.Id))
                employee.Id = Guid.NewGuid().ToString();

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> UpdateEmployeeAsync(string id, Employee e)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return null;

            employee.FullName = e.FullName;
            employee.Department = e.Department;
            employee.Salary = e.Salary;

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> DeleteEmployeeAsync(string id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return null;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
    }
}
