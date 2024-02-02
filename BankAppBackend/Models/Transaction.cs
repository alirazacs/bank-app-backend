using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        public Guid TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        public double Amount
        {
            get { return Amount; }
            set
            {
               
                if (Account.Balance > value) //100 > 10
                {
                    if (TransactionType == TransactionType.CREDIT)
                    {
                        Account.Balance = Account.Balance + value; // balance update : 100+10 = 110 remaining

                    }
                    else if(TransactionType == TransactionType.DEBIT)
                    {
                        Account.Balance = Account.Balance - value; // balance update : 100-10 = 90 remaining
                    }

                    Amount = value; // txn amount = 10
                    
                }
                else
                {
                    throw new InvalidOperationException("Insufficient account balance");
                }

            }
        }
        public DateTime DateTime { get; set; }
        public Guid AccountId { get; set; }
        [JsonIgnore]
        public Account Account { get; set; }


    }
}
