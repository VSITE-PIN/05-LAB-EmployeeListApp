namespace EmployeeListApp.Data
{
    public class Employee
    {
        public int Id { get; set; } // Automatski broj
        public string FullName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}
