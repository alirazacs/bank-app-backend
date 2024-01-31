using System.ComponentModel.DataAnnotations;

namespace BankAppBackend.Models
{
    public class Customer
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public long ApplicantId { get; set; }
        public virtual Applicant Applicant { get; set; }

    }
}
