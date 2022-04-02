namespace BankAccountModule.Domain;

public class BankAccountTransaction
{
    private BankAccountTransaction()
    {
        Id = BankAccountTransactionId.New();
    }

    public BankAccountTransaction(
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

    public BankAccountId? BankAccountId { get; set; }
}