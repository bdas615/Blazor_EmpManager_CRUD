using Employee_Manager_Blazor.Models;
using Employee_Manager_Blazor_API.DbClass;
using Employee_Manager_Blazor_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace Employee_Manager_Blazor_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [EnableCors("AllowOrigin")]
    public class EmployeeController : ControllerBase
    {
        public readonly IConfiguration config;
        public readonly EmpDbClass dbContext;
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeController(IConfiguration config, 
                                  EmpDbClass dbContext, 
                                  IEmployeeRepository employeeRepository)
        {
            this.config = config;
            this.dbContext = dbContext;
            this.employeeRepository = employeeRepository;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<EmployeeInputParams>>> GetAllEmployees() 
        {
            try
            {
                return (await employeeRepository.GetAllEmployees()).ToList();
               
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmployeeInputParams>> GetEmployeeWithId(int id) 
        {

            try
            {
                var result = await employeeRepository.GetEmployeeById(id);

                if (result == null)
                    return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            } 
        }

        //new employee create
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<EmployeeInputParams>> CreateEmployee([FromBody] EmployeeInputParams emp) 
        {
            try
            {
                if (emp == null) 
                    return BadRequest();
                
                var createdEmp = await employeeRepository.AddEmployee(emp);

                return CreatedAtAction(nameof(GetEmployeeWithId), new { id = createdEmp.Id },
                    createdEmp); 

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeInputParams>> UpdateEmployee(EmployeeInputParams emp, int id) 
        {
            try
            {
                if (id != emp.Id)
                        return BadRequest("Employee ID mismatch");

                var empToUpdate = await employeeRepository.GetEmployeeById(id);

                if (empToUpdate == null)
                    return NotFound($"Employee with id = {id} not found");

                return await employeeRepository.UpdateEmployee(emp);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }

        [AllowAnonymous]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EmployeeInputParams>> DeleteEmployee(int id) 
        {
            try
            {
                var employeeToDelete = await employeeRepository.GetEmployeeById(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with id = {id} not found");
                }

                return await employeeRepository.DeleteEmployee(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                         "Error retrieving data from the database");
            }

             
        }
    }
}
