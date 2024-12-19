using System.Security.Claims;
using System.Xml.Linq;

namespace ConsoleEmployeeAppCRUD.Model
{
    public class Employee  //Class Definition
    {
        // Properties
        public int Id { get; set; } // Auto-generated field, made accessible
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public int DeptId { get; set; } // Department ID where the employee belongs (foreign key to Department).
        public string LocationCode { get; set; }
        public int Salary { get; set; }

        // Removed Department property to avoid redundancy
        // Optional: If needed, you can add navigation property
        public Department Department { get; set; } //navigation property//Reference to the Department the employee belongs to (optional for navigation).

        // Default constructor
        public Employee() { }//Initializes an Employee object without setting properties.
        //WHY?Flexibility: Allows the creation of an object and setting its properties later.

        // Parameterized constructor  //Initializes an Employee object and sets properties except for the department.

        public Employee(string employeeCode, string employeeName, int deptId, string locationCode, int salary)
        {
            this.EmployeeCode = employeeCode;//this-local variable:for current instance
            this.EmployeeName = employeeName;
            this.DeptId = deptId;  // Changed to DeptId
            this.LocationCode = locationCode;
            this.Salary = salary;
        }

        // Parameterized constructor with Department//Initializes an Employee object and sets all properties including the department.

        //Why? when The department information is not available when the Employee object is created.
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


/*


public class Employee { ... }

This defines a new class named Employee.

Properties:

These are characteristics of the Employee class.

public int Id { get; set; }: Unique identifier for each employee.

public string EmployeeCode { get; set; }: Code for identifying an employee.

public string EmployeeName { get; set; }: Name of the employee.

public int DeptId { get; set; }:.

public string LocationCode { get; set; }: Code for the employee's location.

public int Salary { get; set; }: Employee's salary.

public Department Department { get; set; }: Reference to the Department the employee belongs to (optional for navigation).

Constructors:

Used to create instances (objects) of the Employee class.

Default Constructor:

public Employee() { }

Initializes an Employee object without setting properties.

Parameterized Constructor (Without Department):

public Employee(string employeeCode, string employeeName, int deptId, string locationCode, int salary) { ... }

Initializes an Employee object and sets properties except for the department.

Parameterized Constructor (With Department):

public Employee(string employeeCode, string employeeName, int deptId, string locationCode, int salary, Department department) { ... }

Initializes an Employee object and sets all properties including the department.

Step-by-Step Explanation of the Department Class
Class Definition:

public class Department { ... }

This defines a new class named Department.

Properties:

These are characteristics of the Department class.

public int DeptId { get; set; }: Unique identifier for each department.

public string DeptCode { get; set; }: Code for identifying a department.

public string DepartmentName { get; set; }: Name of the department.

Constructors:

Used to create instances (objects) of the Department class.

Default Constructor:

public Department() { }

Initializes a Department object without setting properties.

Parameterized Constructor:

public Department(string deptCode, string departmentName) { ... }

Initializes a Department object and sets properties.

Summary
Encapsulation: The classes encapsulate the properties and methods related to Employee and Department.

Constructors: Allow creation of instances with or without initial property values.

Relationships: Employee has a reference to Department to show the relationship.
*/