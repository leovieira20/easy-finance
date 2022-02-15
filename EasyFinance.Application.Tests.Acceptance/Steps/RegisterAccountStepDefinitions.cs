using EasyFinance.Application.Account.RegisterBankAccount;
using EasyFinance.Domain.Accounts;
using FluentAssertions;
using NSubstitute;

namespace EasyFinance.Application.Tests.Acceptance.Steps;

[Binding]
public class RegisterAccountStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;
    private IBankAccountRepository _bankAccountRepository = null!;
    private RegisterBankAccountCommandHandler _sut = null!;

    public RegisterAccountStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeScenario]
    public void Setup()
    {
        _bankAccountRepository = Substitute.For<IBankAccountRepository>();
        _sut = new RegisterBankAccountCommandHandler(_bankAccountRepository);
    }
    
    [Given(@"I want to keep track of my finances")]
    public void GivenIWantToKeepTrackOfMyFinances()
    {
        
    }

    [When(@"I register an account")]
    public async Task WhenIRegisterAnAccount()
    {
        var account = await _sut.Handle(new RegisterBankAccountCommand(Guid.NewGuid().ToString()), CancellationToken.None);
        
        _scenarioContext.Add(nameof(account), account);
    }

    [Then(@"the account should be available")]
    public void ThenTheAccountShouldBeAvailable()
    {
        var account = _scenarioContext.Get<BankAccount>("account");
        account.Status.Should().Be(BankAccountStatus.Enabled);

        _bankAccountRepository.Received(1).CreateAsync(account);
    }
}