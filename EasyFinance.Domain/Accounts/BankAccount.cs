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

    private BankAccount()
    {
        Id = BankAccountId.New();
    }

    public BankAccountId Id { get; }
    public string Status { get; private init; } = null!;
    public string Name { get; private init; } = null!;
}