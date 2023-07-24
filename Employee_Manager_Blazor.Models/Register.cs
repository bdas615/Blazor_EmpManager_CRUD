namespace Employee_Manager_Blazor.Models
{
    public class Register
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Pwd { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
    }
}
