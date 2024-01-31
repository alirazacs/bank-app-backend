using System.ComponentModel.DataAnnotations;

namespace BankAppBackend.Models
{
    public class Account
    {
        [Key]
        public Guid AccountId {  get; set; }
        public AccountType AccountType { get; set; }
        public double Balance { get; set; } = 0.00;
    }
}
