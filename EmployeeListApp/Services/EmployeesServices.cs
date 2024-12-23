using EmployeeListApp.Data;
using System;
namespace EmployeeListApp.Services
{
    public class EmployeeService
    {
        private readonly DataContext _context;

        public EmployeeService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            var result = _context.Employees;
            return await Task.FromResult(result.ToList());
        }

        public async Task<Employee> GetEmployeeById(string id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee> InsertEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(string id, Employee employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(id);
            if (existingEmployee == null)
                return null;
            existingEmployee.FullName = employee.FullName;
            existingEmployee.Department = employee.Department;
            existingEmployee.Salary = employee.Salary;

            _context.Employees.Update(existingEmployee);
            await _context.SaveChangesAsync();
            return existingEmployee;
        }

        public async Task<Employee> DeleteEmployeeAsync(string id)
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