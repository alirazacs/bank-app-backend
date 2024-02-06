using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BankAppBackend.Models
{
    public class Teller
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; } = "DummyTeller";
        [JsonIgnore]
        public ICollection<Applicant>? Applicants { get; set; }
    }
}
