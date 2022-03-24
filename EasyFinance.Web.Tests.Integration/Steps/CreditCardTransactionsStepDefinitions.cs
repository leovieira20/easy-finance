using EasyFinance.Domain;
using EasyFinance.Domain.Accounts;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace EasyFinance.Web.Tests.Integration.Steps;

[Binding]
public class CreditCardTransactionsStepDefinitions
{
    private readonly ICreditCardTransactionRepository _repository;
    private readonly ScenarioContext _scenarioContext;

    public CreditCardTransactionsStepDefinitions(ICreditCardTransactionRepository repository, ScenarioContext scenarioContext)
    {
        _repository = repository;
        _scenarioContext = scenarioContext;
    }
    
    [Given(@"a credit card has transactions")]
    public void GivenACreditCardHasTransactions(Table table)
    {
        var transactions = table.CreateSet<CreditCardTransaction>();

        var creditCard = _scenarioContext.Get<CreditCard>(nameof(CreditCard));

        foreach (var transaction in transactions)
        {
            transaction.CreditCardId = creditCard.Id;
            _repository.RegisterAsync(transaction);
        }
    }
}