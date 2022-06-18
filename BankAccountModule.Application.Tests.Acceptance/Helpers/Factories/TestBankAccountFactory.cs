using BankAccountModule.Domain;

namespace BankAccountModule.Application.Tests.Acceptance.Helpers.Factories;

public class TestBankAccountFactory
{
    public static BankAccount Make()
    {
        return BankAccount.CreateWithName(Guid.NewGuid().ToString());
    }
}