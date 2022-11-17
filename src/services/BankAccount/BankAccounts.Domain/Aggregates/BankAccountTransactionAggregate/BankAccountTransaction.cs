namespace BankAccounts.Domain.Aggregates.BankAccountTransactionAggregate;

public class BankAccountTransaction
{
    public static BankAccountTransaction CreateDeposit(DateTime date, decimal amount, string description)
    {
        return new(date,
            BankAccountTransactionType.Credit,
            amount,
            amount,
            description);
    }
    
    public static BankAccountTransaction CreateDebit(DateTime date, decimal amount, string description)
    {
        return new(date,
            BankAccountTransactionType.Debit,
            amount,
            -amount,
            description);
    }
    
    private BankAccountTransaction()
    {
        Id = BankAccountTransactionId.New();
    }

    private BankAccountTransaction(
        DateTime date,
        BankAccountTransactionType type,
        decimal amount,
        decimal calculationAmount,
        string description)
        : this()
    {
        Date = date;
        Type = type;
        Amount = amount;
        CalculationAmount = calculationAmount;
        Description = description;
    }


    public BankAccountTransactionId Id { get; init; }
    public DateTime Date { get; }
    public BankAccountTransactionType Type { get; set; }
    public decimal Amount { get; private set; }
    public string Description { get; set; } = string.Empty;
    public decimal CalculationAmount { get; set; }

    public BankAccountAggregate.BankAccountId? BankAccountId { get; set; }
}