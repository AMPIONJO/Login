using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class LoginData
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Category Category { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
    }
    public enum Category
    {
        Corporate, Personal
    }
}
