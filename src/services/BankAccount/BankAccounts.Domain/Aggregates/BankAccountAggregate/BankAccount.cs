using Ardalis.GuardClauses;
using BankAccounts.Domain.Aggregates.BankAccountTransactionAggregate;
using LanguageExt;

namespace BankAccounts.Domain.Aggregates.BankAccountAggregate;

public class BankAccount
{
    public static BankAccount Create(string bankAccountName)
    {
        Guard.Against.NullOrWhiteSpace(bankAccountName, nameof(bankAccountName));

        return new()
        {
            Status = BankAccountStatus.Enabled,
            Name = bankAccountName
        };
    }

    public static BankAccount Create(BankAccountId id, string bankAccountName)
    {
        Guard.Against.Null(id, nameof(id));
        Guard.Against.NullOrWhiteSpace(bankAccountName, nameof(bankAccountName));
        
        return new()
        {
            Id = id,
            Status = BankAccountStatus.Enabled,
            Name = bankAccountName
        };
    }

    private BankAccount()
    {
        Id = BankAccountId.New();
    }

    public BankAccount RegisterCredit(DateTime date, decimal amount, string description)
    {
        Transactions.Add(BankAccountTransaction.CreateDeposit(date, amount, description));
        return this;
    }

    public Option<BankAccount> RegisterDebit(DateTime date, decimal amount, string description)
    {
        Transactions.Add(BankAccountTransaction.CreateDebit(date, amount, description));
        return this;
    }

    public BankAccountId Id { get; init; }

    public string Status { get; private init; } = null!;

    public string Name { get; private init; } = null!;

    public decimal Balance => Transactions.Sum(x => x.Amount);

    public List<BankAccountTransaction> Transactions { get; } = new();
}