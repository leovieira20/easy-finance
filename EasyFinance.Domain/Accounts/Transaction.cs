namespace EasyFinance.Domain.Accounts;

public class Transaction
{
    public TransactionId Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
}