using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAppBackend.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CustomerId {  get; set; }   
        public string UserName { get; set; }
        public string Password { get; set; }

        public long ApplicantId { get; set; }
        public virtual Applicant Applicant { get; set; }

    }
}
