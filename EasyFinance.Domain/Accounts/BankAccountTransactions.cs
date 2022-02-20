namespace EasyFinance.Domain.Accounts;

public class BankAccountTransactions
{
    private BankAccountTransactions()
    {
        Id = BankAccountTransactionId.New();
    }

    public BankAccountTransactions(decimal amount)
        : this()
    {
        Amount = amount;
    }


    public BankAccountTransactionId Id { get; init; }
    public decimal Amount { get; private set; }
    
    public BankAccountId? BankAccountId { get; set; }
}