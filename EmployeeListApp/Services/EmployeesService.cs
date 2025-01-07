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

        // Dohvati sve zaposlenike
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        // Dohvati jednog zaposlenika po Id-u
        public async Task<Employee?> GetEmployeeByIdAsync(string id)
        {
            return await _context.Employees.FindAsync(id);
        }

        // Dodaj novog zaposlenika
        public async Task AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        // Ažuriraj postojeći zapis zaposlenika
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        // Obriši zaposlenika po Id-u
        public async Task DeleteEmployeeAsync(string id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
