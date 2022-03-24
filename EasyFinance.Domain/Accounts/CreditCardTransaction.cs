namespace EasyFinance.Domain.Accounts;

public class CreditCardTransaction
{
    public CreditCardTransactionId Id { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal TransactionAmount { get; set; }
    public CreditCardId CreditCardId { get; set; }
}