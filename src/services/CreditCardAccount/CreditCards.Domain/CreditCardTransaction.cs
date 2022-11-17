namespace CreditCards.Domain;

public class CreditCardTransaction
{
    private CreditCardTransaction()
    {
        Id = CreditCardTransactionId.New();
    }
    
    public static CreditCardTransaction CreatePayment(
        DateTime date, 
        decimal amount, 
        string description,
        CreditCardId creditCardId)
    {
        return new()
        {
            Date = date,
            Type = CreditCardTransactionType.Payment,
            Amount = amount,
            CalculationAmount = -amount,
            Description = description,
            CreditCardId = creditCardId,
        };
    }

    public static CreditCardTransaction CreateExpense(
        DateTime date, 
        decimal amount, 
        string description,
        CreditCardId creditCardId)
    {
        return new()
        {
            Date = date,
            Type = CreditCardTransactionType.Expense,
            Amount = amount,
            CalculationAmount = amount,
            Description = description,
            CreditCardId = creditCardId,
        };
    }
    
    public CreditCardTransactionId Id { get; set; }
    public DateTime Date { get; set; }
    public CreditCardTransactionType Type { get; set; }
    public decimal Amount { get; set; }
    public decimal CalculationAmount { get; set; }
    public string Description { get; set; } = string.Empty;
    public CreditCardId CreditCardId { get; set; }
}