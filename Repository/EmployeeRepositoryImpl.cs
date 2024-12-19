using ConsoleEmployeeAppCRUD.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ConsoleEmployeeAppCRUD.Repository
{
    public class EmployeeRepositoryImpl : IEmployeeRepository
    {
        private readonly string winConnString = ConfigurationManager.ConnectionStrings["CsWin"].ConnectionString;

        public async Task AddEmployeeAsync(Employee employee)
        {
            using (SqlConnection conn = new SqlConnection(winConnString))
            {
                await conn.OpenAsync();
                string query = "INSERT INTO Employee (EmployeeCode, EmployeeName, DeptId, LocationCode, Salary) " +
                               "VALUES(@EmpCode, @EmpName, @DeptId, @LocCode, @Sal)";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@EmpCode", employee.EmployeeCode);
                    command.Parameters.AddWithValue("@EmpName", employee.EmployeeName);
                    command.Parameters.AddWithValue("@DeptId", employee.DeptId); // Use DeptId
                    command.Parameters.AddWithValue("@LocCode", employee.LocationCode);
                    command.Parameters.AddWithValue("@Sal", employee.Salary);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateEmployeeAsync(string employeeCode, Employee updatedEmployee)
        {
            using (SqlConnection conn = new SqlConnection(winConnString))
            {
                await conn.OpenAsync();
                string query = "UPDATE Employee SET EmployeeName = @EmpName, DeptId = @DeptId, " +
                               "LocationCode = @LocCode, Salary = @Sal WHERE EmployeeCode = @EmpCode";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@EmpCode", employeeCode);
                    command.Parameters.AddWithValue("@EmpName", updatedEmployee.EmployeeName);
                    command.Parameters.AddWithValue("@DeptId", updatedEmployee.DeptId); // Use DeptId
                    command.Parameters.AddWithValue("@LocCode", updatedEmployee.LocationCode);
                    command.Parameters.AddWithValue("@Sal", updatedEmployee.Salary);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<Employee> GetEmployeeByCodeAsync(string employeeCode)
        {
            using (SqlConnection conn = new SqlConnection(winConnString))
            {
                await conn.OpenAsync();
                string query = @"
                SELECT e.EmployeeCode, e.EmployeeName, e.DeptId, e.LocationCode, e.Salary,
                       d.DeptId, d.DeptCode, d.DepartmentName
                FROM Employee e
                INNER JOIN Department d ON e.DeptId = d.DeptId
                WHERE e.EmployeeCode = @EmpCode";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@EmpCode", employeeCode);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            var department = new Department
                            {
                                DeptId = Convert.ToInt32(reader["DeptId"]),
                                DeptCode = reader["DeptCode"].ToString(),
                                DepartmentName = reader["DepartmentName"].ToString()
                            };

                            return new Employee
                            {
                                EmployeeCode = reader["EmployeeCode"].ToString(),
                                EmployeeName = reader["EmployeeName"].ToString(),
                                DeptId = Convert.ToInt32(reader["DeptId"]), // Use DeptId
                                LocationCode = reader["LocationCode"].ToString(),
                                Salary = Convert.ToInt32(reader["Salary"]),
                                Department = department
                            };
                        }
                    }
                }
            }
            return null;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            var employees = new List<Employee>();

            using (SqlConnection conn = new SqlConnection(winConnString))
            {
                await conn.OpenAsync();
                string query = @"
                SELECT e.EmployeeCode, e.EmployeeName, e.DeptId, e.LocationCode, e.Salary,
                       d.DeptId, d.DeptCode, d.DepartmentName
                FROM Employee e
                INNER JOIN Department d ON e.DeptId = d.DeptId";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var department = new Department
                            {
                                DeptId = Convert.ToInt32(reader["DeptId"]),
                                DeptCode = reader["DeptCode"].ToString(),
                                DepartmentName = reader["DepartmentName"].ToString()
                            };

                            var employee = new Employee
                            {
                                EmployeeCode = reader["EmployeeCode"].ToString(),
                                EmployeeName = reader["EmployeeName"].ToString(),
                                DeptId = Convert.ToInt32(reader["DeptId"]), // Use DeptId
                                LocationCode = reader["LocationCode"].ToString(),
                                Salary = Convert.ToInt32(reader["Salary"]),
                                Department = department
                            };

                            employees.Add(employee);
                        }
                    }
                }
            }
            return employees;
        }

        public async Task DeleteEmployeeAsync(string employeeCode)
        {
            using (SqlConnection conn = new SqlConnection(winConnString))
            {
                await conn.OpenAsync();
                string query = "DELETE FROM Employee WHERE EmployeeCode = @EmpCode";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@EmpCode", employeeCode);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
