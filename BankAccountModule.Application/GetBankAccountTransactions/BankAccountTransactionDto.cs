namespace BankAccountModule.Application.GetBankAccountTransactions;

public record BankAccountTransactionDto
{
    public DateTime Date { get; init; }
    public decimal Amount { get; init; }
    public string Description { get; init; } = string.Empty;
}