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

    public class Applicant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required (ErrorMessage ="Applicant name can't be empty")]
        [StringLength(25, MinimumLength = 2,ErrorMessage = "Name length should be between 2-25 characters")]
        public string name { get; set; }
        [Required(ErrorMessage = "Applicant address can't be empty")]
        public string address { get; set; }
        [Required(ErrorMessage = "Applicant phone number can't be empty")]
        public string phoneNumber { get; set; }
        [Required(ErrorMessage = "Applicant dob can't be empty")]
        public DateOnly dob { get; set; }
        [Required(ErrorMessage = "Applicant account type can't be null")]
        public AccountType accountType { get; set; }
        public AccountStatus accountStatus { get; set; } = AccountStatus.PENDING;
        public long? TellerId { get; set; } //teller foreign key
        public Teller? Teller { get; set; } // navigation property 
    }
}
