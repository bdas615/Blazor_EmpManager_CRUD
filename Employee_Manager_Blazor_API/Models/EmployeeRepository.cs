using Employee_Manager_Blazor.Models;
using Employee_Manager_Blazor_API.DbClass;
using Microsoft.EntityFrameworkCore;

namespace Employee_Manager_Blazor_API.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmpDbClass dbClass;
        public EmployeeRepository(EmpDbClass dbClass)
        {
            this.dbClass = dbClass;
        }
        public async Task<EmployeeInputParams> AddEmployee(EmployeeInputParams emp)
        {
            emp.CreatedOn = DateTime.UtcNow;
            var result = await dbClass.EmployeeParams.AddAsync(emp);
            await dbClass.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<EmployeeInputParams> DeleteEmployee(int empId)
        {
            var result = await dbClass.EmployeeParams.FirstOrDefaultAsync(e=>e.Id == empId);

            if (result != null)
            {
                dbClass.EmployeeParams.Remove(result);
                await dbClass.SaveChangesAsync();
                return result;
            }
            return null;
            //}
            //else 
            //{
            //    throw new KeyNotFoundException("Employee not found");
            //}
            //return result;
        }

        public async Task<IEnumerable<EmployeeInputParams>> GetAllEmployees()
        {
            //var result = await dbClass.EmployeeParams.ToListAsync();

            //if (result != null)
            //{
            //    return result;
            //}
            //else 
            //{
            //    throw new KeyNotFoundException("No employee found");
            //}

            return await dbClass.EmployeeParams.ToListAsync();
        }

        public async Task<EmployeeInputParams> GetEmployeeByEmail(string email)
        {
            return await dbClass.EmployeeParams.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<EmployeeInputParams> GetEmployeeById(int id)
        {
            //var result = await dbClass.EmployeeParams.FirstOrDefaultAsync( e => e.Id == id );

            //if (result != null) 
            //{
            //    return result;
            //}
            //else 
            //{
            //    throw new KeyNotFoundException("Employee not found");
            //}

            return await dbClass.EmployeeParams.FirstOrDefaultAsync(e => e.Id == id);

        }

        public async Task<EmployeeInputParams> UpdateEmployee(EmployeeInputParams emp)
        {
            var result = await dbClass.EmployeeParams.FirstOrDefaultAsync(e => e.Id == emp.Id);

            if (result != null) 
            {
                result.Id = emp.Id;
                result.FirstName = emp.FirstName;
                result.LastName = emp.LastName;
                result.Email = emp.Email;
                result.DOB = emp.DOB;
                result.Address = emp.Address;
                result.JoiningDate = emp.JoiningDate;
                result.Gender = emp.Gender;
            
                await dbClass.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
