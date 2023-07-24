using System.ComponentModel.DataAnnotations;

namespace Employee_Manager_Blazor.Models
{
    public class EmployeeInputParams
    {
        [Key]
        public int Id { get; set; }
        public String FirstName { get; set; } = String.Empty;
        public String LastName { get; set; } = String.Empty;
        public String Email { get; set; } = String.Empty;
        public String Gender { get; set; } = String.Empty;
        public DateTime DOB { get; set; } = DateTime.Now;
        public String Address { get; set; } = String.Empty;
        //public String PhotoUpload { get; set; }
        public DateTime JoiningDate { get; set; } = DateTime.Now;
        public DateTime CreatedOn { get; set; }

        public static implicit operator List<object>(EmployeeInputParams? v)
        {
            throw new NotImplementedException();
        }
    }
}
