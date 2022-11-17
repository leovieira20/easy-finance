using System.Threading.Tasks;
using CreditCards.Domain;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CreditCards.Api.Tests.Steps;

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
    public async Task GivenACreditCardHasTransactions(Table table)
    {
        var creditCard = _scenarioContext.Get<CreditCard>(nameof(CreditCard));
        
        var transactions = table.CreateSet<CreditCardTransaction>(x =>
        {
            var date = x.GetDateTime("Date");
            var amount = x.GetDecimal("Amount");
            var description = x.GetString("Description");
            var creditCardId = creditCard.Id;
            
            return CreditCardTransaction.CreateExpense(
                date, 
                amount, 
                description, 
                creditCardId);
        });

        foreach (var transaction in transactions)
        {
            await _repository.RegisterAsync(transaction);
        }
    }
}