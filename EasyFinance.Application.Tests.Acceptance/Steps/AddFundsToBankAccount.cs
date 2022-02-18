using EasyFinance.Application.Account.AddFundsToBankAccount;
using EasyFinance.Application.Tests.Acceptance.Helpers.Factories;
using EasyFinance.Domain.Accounts;
using FluentAssertions;
using NSubstitute;

namespace EasyFinance.Application.Tests.Acceptance.Steps;

[Binding]
public class AddFundsToBankAccount
{
    private IBankAccountRepository _bankAccountRepository = null!;
    private AddFundsToBankAccountCommandHandler _sut = null!;
    private BankAccountSummaryDTO _bankAccountSummary = null!;
    private BankAccount _bankAccount = null!;

    [BeforeScenario]
    public void Setup()
    {
        _bankAccountRepository = Substitute.For<IBankAccountRepository>();
        _sut = new AddFundsToBankAccountCommandHandler(_bankAccountRepository);
    }
    
    [Given(@"existing bank account with no balance")]
    public void GivenExistingBankAccountWithNoBalance()
    {
        _bankAccount = TestBankAccountFactory.Make();
        _bankAccountRepository.GetAsync(default)
            .ReturnsForAnyArgs(_bankAccount);
    }

    [When(@"I add (.*) to the bank account")]
    public async Task WhenIAddToTheBankAccount(int amount)
    {
        _bankAccountSummary = await _sut.Handle(new AddFundsToBankAccountCommand(_bankAccount.Id.Value, amount), CancellationToken.None);
    }

    [Then(@"the new balance should be (.*)")]
    public void ThenTheNewBalanceShouldBe(int expectedBalance)
    {
        _bankAccountSummary.Balance.Should().Be(expectedBalance);
    }
}