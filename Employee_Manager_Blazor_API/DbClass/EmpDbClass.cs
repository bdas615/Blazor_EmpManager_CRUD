using Employee_Manager_Blazor.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Manager_Blazor_API.DbClass
{
    public class EmpDbClass : DbContext
    {
        public EmpDbClass(DbContextOptions<EmpDbClass> options) : base(options) { }

        public DbSet<EmployeeInputParams> EmployeeParams { get; set; }
    }
}
