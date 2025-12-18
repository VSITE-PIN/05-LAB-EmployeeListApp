using Microsoft.EntityFrameworkCore;
using EmployeeListApp.Data;

namespace EmployeeListApp.Services
{
    public class EmployeesService
    {
        private readonly AppDbContext _context;

        public EmployeesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(string id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var employee = await GetByIdAsync(id);
            if (employee == null) return;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task SeedDataAsync()
        {
            if (!_context.Employees.Any())
            {
                _context.Employees.AddRange(
                    new Employee { Id = "1", FullName = "Ana Horvat", Department = "IT", Salary = 1500 },
                    new Employee { Id = "2", FullName = "Marko Marić", Department = "HR", Salary = 1200 },
                    new Employee { Id = "3", FullName = "Ivana Kovač", Department = "Finance", Salary = 1800 }
                );
                await _context.SaveChangesAsync();
            }
        }

    }
}
