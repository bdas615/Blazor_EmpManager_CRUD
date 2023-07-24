using Employee_Manager_Blazor.Models;

namespace Employee_Manager_Blazor_API.Models
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeInputParams>> GetAllEmployees();
        Task<EmployeeInputParams> GetEmployeeById(int id);
        Task<EmployeeInputParams> GetEmployeeByEmail(string email);
        Task<EmployeeInputParams> AddEmployee(EmployeeInputParams emp);
        Task<EmployeeInputParams> UpdateEmployee(EmployeeInputParams emp);
        Task<EmployeeInputParams> DeleteEmployee(int empId);
    }
}
