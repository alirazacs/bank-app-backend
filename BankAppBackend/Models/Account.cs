using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAppBackend.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AccountId {  get; set; }
        public AccountType AccountType { get; set; }
        public double Balance { get; set; } = 0.00;
        public Customer Customer { get; set; }
        public long CustomerId {  get; set; }   
    }
}
