namespace EasyFinance.Application.BankAccountTransactionCommands.ShowBankAccountTransactions;

public record BankAccountTransactionDto
{
    public decimal Amount { get; init; }
}