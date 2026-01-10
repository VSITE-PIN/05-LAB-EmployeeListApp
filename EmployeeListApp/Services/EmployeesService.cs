using EmployeeListApp.Data;
using Microsoft.EntityFrameworkCore;

public class EmployeesService
{
    private readonly AppDbContext _context;

    public EmployeesService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetEmployeesAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee> GetEmployeeByIdAsync(string id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task<Employee> AddEmployeeAsync(Employee employee)
    {
        employee.Id = Guid.NewGuid().ToString();
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee> UpdateEmployeeAsync(string id, Employee employee)
    {
        var existing = await _context.Employees.FindAsync(id);
        if (existing == null) return null;

        existing.FullName = employee.FullName;
        existing.Department = employee.Department;
        existing.Salary = employee.Salary;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteEmployeeAsync(string id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null) return false;

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
        return true;
    }
}