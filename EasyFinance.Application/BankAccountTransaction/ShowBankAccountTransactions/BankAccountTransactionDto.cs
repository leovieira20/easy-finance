namespace EasyFinance.Application.BankAccountTransaction.ShowBankAccountTransactions;

public record BankAccountTransactionDto
{
    public decimal Amount { get; init; }
}