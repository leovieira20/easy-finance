namespace EasyFinance.Application.BankAccountTransaction.RegisterDepositToBankAccount;

public record BankAccountSummaryDto
{
    public decimal Balance { get; init; }
}