namespace EasyFinance.Domain.Accounts;

public class BankAccountTransaction
{
    private BankAccountTransaction()
    {
        Id = BankAccountTransactionId.New();
    }

    public BankAccountTransaction(decimal amount, DateTime date)
        : this()
    {
        Amount = amount;
        Date = date;
    }


    public BankAccountTransactionId Id { get; init; }
    public decimal Amount { get; private set; }
    public DateTime Date { get; }

    public BankAccountId? BankAccountId { get; set; }
}