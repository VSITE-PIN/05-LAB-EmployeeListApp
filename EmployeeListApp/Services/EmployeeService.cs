using EmployeeListApp.Data;

namespace EmployeeListApp.Services
{
    public class EmployeeService
    {
        AppDbContext _context;
        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Employee>> GetEmployeeAsync()
        {
            var result = _context.Employees;
            return await Task.FromResult(result.ToList());
        }
        public async Task<Employee?> GetEmployeeByIdAsync(string id)
        {
            return await _context.Employees.FindAsync(id);
        }
        public async Task<Employee> InsertEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task<Employee?> UpdateEmployeeAsync(string id, Employee s)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return null;
            employee.Id = s.Id;
            employee.FullName = s.FullName;
            employee.Department = s.Department;
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task<Employee?> DeleteEmployeeAsync(string id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return null;
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        private bool EmployeeExists(string id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
