using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace BankAppBackend.Models
{
    public enum TransactionType
    {
        CREDIT,DEBIT
    }
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public Guid TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        public double Amount{ get; set; }
        public DateTime DateTime { get; set; }
        public long AccountId { get; set; }
        [JsonIgnore]
        public Account? Account { get; set; }


    }
}
