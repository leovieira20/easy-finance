namespace BankAccountModule.Application.ShowBankAccountTransactions;

public record BankAccountTransactionDto
{
    public decimal Amount { get; init; }
}