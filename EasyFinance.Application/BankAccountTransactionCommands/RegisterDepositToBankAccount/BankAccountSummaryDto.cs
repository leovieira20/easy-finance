namespace EasyFinance.Application.BankAccountTransactionCommands.RegisterDepositToBankAccount;

public record BankAccountSummaryDto
{
    public decimal Balance { get; init; }
}