using Ardalis.GuardClauses;

namespace EasyFinance.Domain.Accounts;

public class BankAccount
{
    public static BankAccount Create(string bankAccountName)
    {
        Guard.Against.NullOrWhiteSpace(bankAccountName, nameof(bankAccountName));

        return new BankAccount
        {
            Status = BankAccountStatus.Enabled,
            Name = bankAccountName
        };
    }

    public static BankAccount Create(BankAccountId id, string bankAccountName)
    {
        Guard.Against.Null(id, nameof(id));
        Guard.Against.NullOrWhiteSpace(bankAccountName, nameof(bankAccountName));
        
        return new BankAccount
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

    public void RegisterDeposit(decimal amount, DateTime date)
    {
        Transactions.Add(new BankAccountTransaction(amount, date));
    }

    public void RegisterPayment(decimal amount, DateTime date)
    {
        Transactions.Add(new BankAccountTransaction(amount, date));
    }

    public BankAccountId Id { get; init; }

    public string Status { get; private init; } = null!;

    public string Name { get; private init; } = null!;

    public decimal Balance => Transactions.Sum(x => x.Amount);

    public List<BankAccountTransaction> Transactions { get; } = new List<BankAccountTransaction>();
}