namespace ConsoleEmployeeAppCRUD.Model
{
    public class Employee
    {
        // Properties
        public int Id { get; set; } // Auto-generated field, made accessible
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public int DeptId { get; set; }  // Changed to DeptId to match foreign key
        public string LocationCode { get; set; }
        public int Salary { get; set; }

        // Removed Department property to avoid redundancy
        // Optional: If needed, you can add navigation property
        public Department Department { get; set; }

        // Default constructor
        public Employee() { }

        // Parameterized constructor
        public Employee(string employeeCode, string employeeName, int deptId, string locationCode, int salary)
        {
            this.EmployeeCode = employeeCode;
            this.EmployeeName = employeeName;
            this.DeptId = deptId;  // Changed to DeptId
            this.LocationCode = locationCode;
            this.Salary = salary;
        }

        // Parameterized constructor with Department
        public Employee(string employeeCode, string employeeName, int deptId, string locationCode, int salary, Department department)
        {
            this.EmployeeCode = employeeCode;
            this.EmployeeName = employeeName;
            this.DeptId = deptId;  // Changed to DeptId
            this.LocationCode = locationCode;
            this.Salary = salary;
            this.Department = department;
        }
    }

    public class Department
    {
        // Properties
        public int DeptId { get; set; }
        public string DeptCode { get; set; }
        public string DepartmentName { get; set; }

        // Default constructor
        public Department() { }

        // Parameterized constructor
        public Department(string deptCode, string departmentName)
        {
            this.DeptCode = deptCode;
            this.DepartmentName = departmentName;
        }
    }
}
