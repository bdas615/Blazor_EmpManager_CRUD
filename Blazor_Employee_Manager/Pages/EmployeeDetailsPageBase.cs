using Blazor_Employee_Manager.Services;
using Employee_Manager_Blazor.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
//using HttpClient http;

namespace Blazor_Employee_Manager.Pages
{
    public class EmployeeDetailsPageBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public List<EmployeeInputParams> Employees { get; set; } = new List<EmployeeInputParams>();


        protected override async Task OnInitializedAsync()
        {
            await Get();
        }

        public async Task Get() 
        {
            var http = new HttpClient();

            Employees = await http.GetFromJsonAsync<List<EmployeeInputParams>>("api/employee/GetAll");
            //Employees = JsonConvert.DeserializeObject<EmployeeInputParams>(Employees.ToString());

        }





    }
}
