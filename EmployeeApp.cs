using ConsoleEmployeeAppCRUD.Service;
using System;
using System.Threading.Tasks;
using ConsoleEmployeeAppCRUD.Repository;
using ConsoleEmployeeAppCRUD.Model;

namespace ConsoleEmployeeAppCRUD
{
    internal class EmployeeApp
    {
        // Correctly defined Main method as static
        public static async Task Main(string[] args)
        {
            //Create an instance of Service
            IEmployeeService employeeService = new EmployeeServiceImpl(new EmployeeRepositoryImpl());

            // Menu Driven
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Employee Management System");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Update Employee");
                Console.WriteLine("3. Get Employee by Code");
                Console.WriteLine("4. Get All Employees");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await AddEmployee(employeeService);
                        break;
                    case "2":
                        await UpdateEmployee(employeeService);
                        break;
                    case "3":
                        await SearchEmployee(employeeService);
                        break;
                    case "4":
                        await ListEmployees(employeeService);
                        break;
                    case "5":
                        await DeleteEmployee(employeeService);
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }

            Console.ReadKey();
        }

        //AddEmployee Method
        private static async Task AddEmployee(IEmployeeService employeeService)
        {
            var employee = new Employee();
            var department = new Department();

            // EmpCode
            Console.Write("Enter Employee Code: ");
            employee.EmployeeCode = Console.ReadLine();

            // EmpName
            Console.Write("Enter Employee Name: ");
            employee.EmployeeName = Console.ReadLine();

            // DeptCode
            Console.Write("Enter Department Code: ");
            department.DeptCode = Console.ReadLine();

            // Find the DeptId for the given DeptCode (Assuming you have a method to get the department by code)
            department = await GetDepartmentByCode(department.DeptCode);

            // Check if department was found
            if (department == null)
            {
                Console.WriteLine("Department not found. Please enter a valid Department Code.");
                return;
            }

            // Assign DeptId to employee
            employee.DeptId = department.DeptId;

            // LocCode
            Console.Write("Enter Location Code: ");
            employee.LocationCode = Console.ReadLine();

            // Salary
            Console.Write("Enter Salary: ");
            employee.Salary = Convert.ToInt32(Console.ReadLine());

            // Assign Department to employee
            employee.Department = department;

            // Call Insert from EmployeeService
            await employeeService.AddEmployeeAsync(employee);
            Console.WriteLine("Employee added successfully.");
        }

        //UpdateEmployee Method
        private static async Task UpdateEmployee(IEmployeeService employeeService)
        {
            var employee = new Employee();
            var department = new Department();

            // EmpCode
            Console.Write("Enter Employee Code: ");
            string employeeCode = Console.ReadLine();

            // EmpName
            Console.Write("Enter Employee Name: ");
            employee.EmployeeName = Console.ReadLine();

            // DeptCode
            Console.Write("Enter Department Code: ");
            department.DeptCode = Console.ReadLine();

            // Find the DeptId for the given DeptCode (Assuming you have a method to get the department by code)
            department = await GetDepartmentByCode(department.DeptCode);

            // Check if department was found
            if (department == null)
            {
                Console.WriteLine("Department not found. Please enter a valid Department Code.");
                return;
            }

            // Assign DeptId to employee
            employee.DeptId = department.DeptId;

            // LocCode
            Console.Write("Enter Location Code: ");
            employee.LocationCode = Console.ReadLine();

            // Salary
            Console.Write("Enter Salary: ");
            employee.Salary = Convert.ToInt32(Console.ReadLine());

            // Call Update from EmployeeService
            await employeeService.UpdateEmployeeAsync(employeeCode, employee);
            Console.WriteLine("Employee updated successfully.");
        }

        //SearchEmployee Method
        private static async Task SearchEmployee(IEmployeeService employeeService)
        {
            Console.Write("Enter Employee Code: ");
            string employeeCode = Console.ReadLine();

            var employee = await employeeService.GetEmployeeByCodeAsync(employeeCode);

            if (employee != null)
            {
                Console.WriteLine($"Employee Code: {employee.EmployeeCode}");
                Console.WriteLine($"Employee Name: {employee.EmployeeName}");
                Console.WriteLine($"Department: {employee.Department.DepartmentName}");
                Console.WriteLine($"Location Code: {employee.LocationCode}");
                Console.WriteLine($"Salary: {employee.Salary}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        //ListEmployees Method
        private static async Task ListEmployees(IEmployeeService employeeService)
        {
            var employees = await employeeService.GetAllEmployeesAsync();

            foreach (var employee in employees)
            {
                Console.WriteLine($"Employee Code: {employee.EmployeeCode}");
                Console.WriteLine($"Employee Name: {employee.EmployeeName}");
                Console.WriteLine($"Department: {employee.Department.DepartmentName}");
                Console.WriteLine($"Location Code: {employee.LocationCode}");
                Console.WriteLine($"Salary: {employee.Salary}");
                Console.WriteLine("----------------------------");
            }
        }

        //DeleteEmployee Method
        private static async Task DeleteEmployee(IEmployeeService employeeService)
        {
            Console.Write("Enter Employee Code: ");
            string employeeCode = Console.ReadLine();

            await employeeService.DeleteEmployeeAsync(employeeCode);
            Console.WriteLine("Employee deleted successfully.");
        }

        // Mock method to simulate retrieving Department by code
        private static async Task<Department> GetDepartmentByCode(string deptCode)
        {
            // Simulating asynchronous database call
            await Task.Delay(100);
            return new Department { DeptId = 1, DeptCode = deptCode, DepartmentName = "Example Department" };
        }
    }
}
