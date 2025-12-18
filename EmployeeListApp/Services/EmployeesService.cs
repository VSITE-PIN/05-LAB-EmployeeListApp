using EmployeeListApp.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeListApp.Services;

public class EmployeesService
{
    private readonly AppDbContext _db;

    public EmployeesService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Employee>> GetAllAsync()
        => await _db.Employees.AsNoTracking()
            .OrderBy(e => e.FullName)
            .ToListAsync();
}