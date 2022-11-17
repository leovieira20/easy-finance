using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;

namespace BankAccounts.Application.Tests.Acceptance.RegisterDepositToBankAccountTests;

public partial class RegisterDepositToBankAccountTests
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
            _ => AndDepositOf(1m),
            _ => WhenActionIsExecuted(),
            _ => ThenNewBalanceIsReturned(),
            _ => ThenTransactionIsRegistered()
        );
    }
}