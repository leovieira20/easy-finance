using BankAccountModule.Domain;

namespace EasyFinance.Application.Tests.Acceptance.Helpers.Factories;

public class TestBankAccountFactory
{
    public static BankAccount Make()
    {
        return BankAccount.Create(Guid.NewGuid().ToString());
    }
}