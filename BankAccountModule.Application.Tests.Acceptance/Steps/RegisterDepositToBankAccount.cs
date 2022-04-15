using BankAccountModule.Application.RegisterDepositToBankAccount;
using BankAccountModule.Domain;
using FluentAssertions;

namespace BankAccountModule.Application.Tests.Acceptance.Steps;

[Binding]
public class RegisterDepositToBankAccount
{
    private readonly RegisterDepositToBankAccountCommandHandler _sut;
    private BankAccountSummaryDto _bankAccountSummary = null!;

    public RegisterDepositToBankAccount(ScenarioContext context)
    {
        var bankAccountRepository = context.Get<IBankAccountRepository>(nameof(IBankAccountRepository));
        _sut = new RegisterDepositToBankAccountCommandHandler(bankAccountRepository);
    }

    [When(@"I register a deposit of (.*) to the bank account")]
    public async Task WhenIRegisterADepositToTheBankAccount(int amount)
    {
        _bankAccountSummary = await _sut
            .Handle(new RegisterDepositToBankAccountCommand(Guid.Empty, amount, default), CancellationToken.None);
    }

    [Then(@"the new balance should be (.*)")]
    public void ThenTheNewBalanceShouldBe(int expectedBalance)
    {
        _bankAccountSummary.Balance.Should().Be(expectedBalance);
    }

    [Then(@"deposit is not registered")]
    public void ThenDepositIsNotRegistered()
    {
        _bankAccountSummary.Balance.Should().Be(0);
    }
}