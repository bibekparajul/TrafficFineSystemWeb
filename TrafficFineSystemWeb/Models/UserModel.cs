using System.ComponentModel.DataAnnotations;

namespace TrafficFineSystemWeb.Models
{
    public class UserModel
    {
        [Key]
        public string Id { get; set; }
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password doesnot match")]

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public string Role { get; set; }
    }
}
