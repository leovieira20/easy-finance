using BankAccountModule.Application.RegisterBankAccount;
using BankAccountModule.Domain;
using BankAccountModule.Domain.Repositories;
using FluentAssertions;
using NSubstitute;

namespace BankAccountModule.Application.Tests.Acceptance.Steps;

[Binding]
public class RegisterAccountStepDefinitions
{
    private readonly IBankAccountRepository _bankAccountRepository;
    private readonly RegisterBankAccountCommandHandler _sut;
    private BankAccountDto _account = null!;

    public RegisterAccountStepDefinitions(ScenarioContext context)
    {
        _bankAccountRepository = context.Get<IBankAccountRepository>(nameof(IBankAccountRepository));
        _sut = new RegisterBankAccountCommandHandler(_bankAccountRepository);
    }

    [Given(@"I want to keep track of my finances")]
    public void GivenIWantToKeepTrackOfMyFinances()
    {
        
    }

    [When(@"I register an account")]
    public async Task WhenIRegisterAnAccount()
    {
        _account = await _sut.Handle(new RegisterBankAccountCommand(Guid.NewGuid().ToString()), CancellationToken.None);
    }

    [Then(@"the account should be available")]
    public void ThenTheAccountShouldBeAvailable()
    {
        _account.Status.Should().Be(BankAccountStatus.Enabled);

        _bankAccountRepository.Received(1)
            .CreateAsync(Arg.Any<BankAccount>());
    }
}