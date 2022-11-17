using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;

namespace BankAccounts.Application.Tests.Acceptance.RegisterBankAccountTests;

public partial class RegisterBankAccountTests
{
    [Scenario]
    public Task Success()
    {
        return Runner.RunScenarioAsync(
            _ => GivenAValidBankAccountName(),
            _ => WhenActionIsExecuted(),
            _ => ThenBankAccountIsRegistered()
        );
    }
}