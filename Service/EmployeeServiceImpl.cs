using ConsoleEmployeeAppCRUD.Model;
using ConsoleEmployeeAppCRUD.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleEmployeeAppCRUD.Service 
{
    public class EmployeeServiceImpl : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        // Constructor Injection
        public EmployeeServiceImpl(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // Insert
        public async Task AddEmployeeAsync(Employee employee)
        {
            await _employeeRepository.AddEmployeeAsync(employee);
        }

        // Update
        public async Task UpdateEmployeeAsync(string employeeCode, Employee updatedEmployee)
        {
            await _employeeRepository.UpdateEmployeeAsync(employeeCode, updatedEmployee);
        }

        // Search By Employee Code
        public async Task<Employee> GetEmployeeByCodeAsync(string employeeCode)
        {
            return await _employeeRepository.GetEmployeeByCodeAsync(employeeCode);
        }

        // List All Employees
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }

        // Delete Employee
        public async Task DeleteEmployeeAsync(string employeeCode)
        {
            await _employeeRepository.DeleteEmployeeAsync(employeeCode);
        }
    }
}
