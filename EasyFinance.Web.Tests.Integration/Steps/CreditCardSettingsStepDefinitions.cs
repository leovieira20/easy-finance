using System.Threading.Tasks;
using EasyFinance.Domain.Accounts;
using EasyFinance.Web.Tests.Integration.Infrastructure.Clients;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace EasyFinance.Web.Tests.Integration.Steps;

[Binding]
public class CreditCardSettingsStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;
    private readonly CreditCardSettingsClient _client;
    private ClientResponse<CreditCardSettingsPublicModel> _response = null!;

    public CreditCardSettingsStepDefinitions(ScenarioContext scenarioContext, CreditCardSettingsClient client)
    {
        _scenarioContext = scenarioContext;
        _client = client;
    }
    
    [Given(@"the credit card has a default payment amount of (.*) euros")]
    public void GivenTheCreditCardHasADefaultPaymentAmountOfEuros(int amount)
    {
        var creditCard = _scenarioContext.Get<CreditCard>(nameof(CreditCard));

        creditCard.SetDefaultPaymentAmount(amount);
    }

    [When(@"I set the limit to (.*) euros")]
    public async Task WhenISetTheLimitToEuros(int limitAmount)
    {
        var creditCard = _scenarioContext.Get<CreditCard>(nameof(CreditCard));
        _response = await _client.SetLimitAsync(creditCard.Id.Value, limitAmount);
    }

    [Then(@"limit on my card is (.*) euros")]
    public void ThenLimitOnMyCardIsEuros(int limitAmount)
    {
        _response.ParsedPayload!.Limit.Should().Be(limitAmount);
    }
}