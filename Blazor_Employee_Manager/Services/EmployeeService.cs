using Employee_Manager_Blazor.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

namespace Blazor_Employee_Manager.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;
        public EmployeeService(HttpClient httpClient) 
        {
            this.httpClient = httpClient;
        }
        public async Task<EmployeeInputParams> CreateEmployee(EmployeeInputParams createEmp)
        {
            var x = await httpClient.PostAsJsonAsync<EmployeeInputParams>("api/Employee",createEmp);
            return JsonConvert.DeserializeObject<EmployeeInputParams>(await x.Content.ReadAsStringAsync());
        }

        public Task DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeInputParams> GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmployeeInputParams>> GetEmployees()
        {
            return await httpClient.GetFromJsonAsync<EmployeeInputParams[]>("api/Employee/GetAll");
        }

        public Task<EmployeeInputParams> UpdateEmployee(EmployeeInputParams updateEmp)
        {
            throw new NotImplementedException();
        }
    }
}