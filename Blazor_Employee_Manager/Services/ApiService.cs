using Employee_Manager_Blazor.Models;
using Newtonsoft.Json;

namespace Blazor_Employee_Manager.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EmployeeInputParams>> GetEmployees()
        {
            return await _httpClient.GetFromJsonAsync<List<EmployeeInputParams>>("api/employee/GetAll");
        }

        public async Task<List<EmployeeInputParams>> GetEmployeeById(int id) 
        {
            return await _httpClient.GetFromJsonAsync<List<EmployeeInputParams>>($"api/employee/{id}");
        }

        public async Task<EmployeeInputParams> CreateEmp(EmployeeInputParams emp) 
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/employee", emp);
            response.EnsureSuccessStatusCode(); // Ensure the request was successful

            string responseContent = await response.Content.ReadAsStringAsync();
            EmployeeInputParams createdEmployee = JsonConvert.DeserializeObject<EmployeeInputParams>(responseContent);

            return createdEmployee;
        }

        public async Task<EmployeeInputParams> DeleteEmp(int id) 
        {
            HttpResponseMessage res = await _httpClient.DeleteAsync($"api/employee/{id}");

            res.EnsureSuccessStatusCode();

            string responseContent = await res.Content.ReadAsStringAsync();

            EmployeeInputParams deleteEmp = JsonConvert.DeserializeObject<EmployeeInputParams>(responseContent);

            return deleteEmp;
        }
    }
}
