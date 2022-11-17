namespace BankAccounts.Application.Models;

public record BankAccountSummaryDto
{
    public decimal Balance { get; init; }
}