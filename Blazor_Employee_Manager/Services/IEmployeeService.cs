    using Employee_Manager_Blazor.Models;

namespace Blazor_Employee_Manager.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeInputParams>> GetEmployees();
        Task<EmployeeInputParams> GetEmployee(int id);
        Task<EmployeeInputParams> UpdateEmployee(EmployeeInputParams updateEmp);
        Task<EmployeeInputParams> CreateEmployee(EmployeeInputParams createEmp);
        Task DeleteEmployee(int id);
    }
}
