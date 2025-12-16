using EmployeeListApp.Data;

namespace EmployeeListApp.Services
{
    public class EmployeesService
    {
        AppDbContext _context;
        public EmployeesService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Employee>> GetSongsAsync()
        {
            var result = _context.Employees;
            return await Task.FromResult(result.ToList());
        }
        public async Task<Employee> GetSongByIdAsync(string id)
        {
            return await _context.Employees.FindAsync(id);
        }
        public async Task<Employee> InsertSongAsync(Employee emp)
        {
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();
            return emp;
        }
        public async Task<Employee> UpdateEmployeeAsync(string id, Employee s)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null)
                return null;
            emp.FullName = s.FullName;
            emp.Department = s.Department;
            emp.Salary = s.Salary;

            _context.Employees.Update(emp);
            await _context.SaveChangesAsync();
            return emp;
        }
        public async Task<Employee> DeleteEmployeeAsync(string id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null)
                return null;
            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
            return emp;
        }
    }
}
