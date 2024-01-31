using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAppBackend.Models
{
    public enum AccountType
    {
        CURRENT, SAVING, BUSINESS
    }
    public enum AccountStatus
    {
        APPROVED, DENIED, PENDING
    }

    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        [Required (ErrorMessage ="User name can't be empty")]
        [StringLength(25, MinimumLength = 2,ErrorMessage = "Name length should be between 2-25 characters")]
        public string name { get; set; }
        [Required(ErrorMessage = "User address can't be empty")]
        public string address { get; set; }
        [Required(ErrorMessage = "User phone number can't be empty")]
        public string phoneNumber { get; set; }
        [Required(ErrorMessage = "User dob can't be empty")]
        public DateTime dob { get; set; }
        [Required(ErrorMessage = "User account type can't be null")]
        public AccountType accountType { get; set; }
        public AccountStatus accountStatus { get; set; } = AccountStatus.PENDING;
    }
}
