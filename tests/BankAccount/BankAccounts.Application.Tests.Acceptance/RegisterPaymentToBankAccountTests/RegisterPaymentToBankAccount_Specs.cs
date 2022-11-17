using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;

namespace BankAccounts.Application.Tests.Acceptance.RegisterPaymentToBankAccountTests;

public partial class RegisterPaymentToBankAccountTests
{
    [Scenario]
    public Task NonExistentBankAccount()
    {
        return Runner.RunScenarioAsync(
            _ => GivenNonExistentBankAccount(),
            _ => WhenActionIsExecuted(),
            _ => ThenEmptyBalanceIsReturned()
        );
    }
    
    [Scenario]
    public Task ExistentBankAccount()
    {
        return Runner.RunScenarioAsync(
            _ => GivenExistentBankAccount(),
            _ => AndPaymentOf(1m),
            _ => WhenActionIsExecuted(),
            _ => ThenNewBalanceIsReturned(),
            _ => ThenTransactionIsRegistered()
        );
    }
}