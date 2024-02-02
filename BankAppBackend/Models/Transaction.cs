namespace BankAppBackend.Models
{
    public enum TransactionType
    {
        CREDIT,DEBIT,TRANSFER
    }
    public class Transaction
    {
        public long Id { get; set; }

        public long TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        public double Amount { get; set; }
        public DateTime DateTime { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } 
        public int AccountId { get; set; }
        public Account Account { get; set; }


    }
}
