namespace BankAccountModule.Application.Models;

public record BankAccountTransactionDto
{
    public DateTime Date { get; init; }
    public decimal Amount { get; init; }
    public string Description { get; init; } = string.Empty;
}