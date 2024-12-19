﻿using ConsoleEmployeeAppCRUD.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleEmployeeAppCRUD.Service
{
    public interface IEmployeeService
    {
        // Insert
        Task AddEmployeeAsync(Employee employee);

        // Update
        Task UpdateEmployeeAsync(string employeeCode, Employee updatedEmployee);
        
        // Search By EmpCode
        Task<Employee> GetEmployeeByCodeAsync(string employeeCode);

        // List All Employees
        Task<List<Employee>> GetAllEmployeesAsync();

        // Delete Employee
        Task DeleteEmployeeAsync(string employeeCode);
    }
}
