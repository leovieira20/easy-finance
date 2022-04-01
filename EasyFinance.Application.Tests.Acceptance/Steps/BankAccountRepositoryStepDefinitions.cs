using EasyFinance.Application.Tests.Acceptance.Helpers.Factories;
using EasyFinance.Domain.Accounts;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using TechTalk.SpecFlow.Assist;

namespace EasyFinance.Application.Tests.Acceptance.Steps;

[Binding, Scope(Tag = "bankAccount")]
public class BankAccountRepositoryStepDefinitions
{
    private readonly IBankAccountRepository _repository;

    public BankAccountRepositoryStepDefinitions(ScenarioContext context)
    {
        _repository = context.Get<IBankAccountRepository>(nameof(IBankAccountRepository));
    }

    [Given(@"inexistent bank account")]
    public void GivenInexistentBankAccount()
    {
        _repository.GetAsync(default)
            .ReturnsNullForAnyArgs();
    }
    
    [Given(@"existing bank account with no balance")]
    public void GivenExistingBankAccountWithNoBalance()
    {
        _repository.GetAsync(default)
            .ReturnsForAnyArgs(TestBankAccountFactory.Make());
    }
    
    [Given(@"existing bank account with one deposit")]
    public void GivenExistingBankAccountWithOneDeposit(Table transactions)
    {
        var transaction = transactions.CreateInstance<BankAccountTransaction>();
        
        var bankAccount = TestBankAccountFactory.Make();
        
        bankAccount.RegisterCredit(DateTime.UtcNow, transaction.Amount, string.Empty);

        _repository.GetWithTransactionsAsync(default)
            .ReturnsForAnyArgs(bankAccount);
    }
}