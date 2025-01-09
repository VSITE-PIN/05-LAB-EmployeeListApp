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

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Employee ID cannot be null or empty.", nameof(id));
            }

            return await _context.Employees.FindAsync(id);
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "Employee cannot be null.");
            }

            try
            {
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new ApplicationException("An error occurred while adding the employee.", ex);
            }
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "Employee cannot be null.");
            }

            try
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ApplicationException("A concurrency issue occurred while updating the employee.", ex);
            }
        }

        public async Task DeleteEmployeeAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Employee ID cannot be null or empty.", nameof(id));
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new KeyNotFoundException($"No employee found with ID {id}.");
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
