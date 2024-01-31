using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankAppBackend.Models
{
    public class Teller
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; } = "DummyTeller";

        //public List<Applicant> applicants{ get; set; }   
    }
}
