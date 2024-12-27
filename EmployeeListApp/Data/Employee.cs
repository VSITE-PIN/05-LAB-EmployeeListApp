using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeListApp.Data
{
    public class Employee
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }

        [Column(TypeName = "decimal(18,2)")] // Alternativa Fluent API-ju
        public decimal Salary { get; set; }
    }

}
