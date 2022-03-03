using EasyFinance.Domain.Accounts;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace EasyFinance.Web.Tests.Integration.Steps;

[Binding]
public class CreditCardTransactionsStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;

    public CreditCardTransactionsStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    
    [Given(@"a credit card has transactions")]
    public void GivenACreditCardHasTransactions(Table table)
    {
        var transactions = table.CreateSet<Transaction>();

        var creditCard = _scenarioContext.Get<CreditCard>(nameof(CreditCard));

        foreach (var transaction in transactions)
        {
            creditCard.RegisterTransaction(transaction);
        }
    }
}