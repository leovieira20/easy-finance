namespace EasyFinance.Application.Account.ShowBankAccountTransactions;

public record BankAccountTransactionDto
{
    public decimal Amount { get; init; }
}