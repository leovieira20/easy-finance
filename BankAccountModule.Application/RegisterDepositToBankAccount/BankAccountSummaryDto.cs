namespace BankAccountModule.Application.RegisterDepositToBankAccount;

public record BankAccountSummaryDto
{
    public decimal Balance { get; init; }
}