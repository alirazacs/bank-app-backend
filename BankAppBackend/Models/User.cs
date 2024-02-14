using System.ComponentModel.DataAnnotations;

namespace BankAppBackend.Models
{
    public enum UserTypes
    {
        TELLER, CUSTOMER // we dont like all caps names in general; its considered YELLING
    }

    public class User
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email can't be empty")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Password can't be empty")]
        public string Password { get; set; }
        
        public UserTypes UserType { get; set; }
    }
}
