using System.Threading.Tasks;
using CreditCards.Api.Tests.Infrastructure.Clients;
using CreditCards.Domain;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace CreditCards.Api.Tests.Steps;

[Binding]
public class CreditCardSettingsStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;
    private readonly CreditCardSettingsClient _client;
    private readonly ICreditCardRepository _creditCardRepository;
    private ClientResponse<CreditCardSettings> _response = null!;

    public CreditCardSettingsStepDefinitions(ScenarioContext scenarioContext, 
        CreditCardSettingsClient client, 
        ICreditCardRepository creditCardRepository)
    {
        _scenarioContext = scenarioContext;
        _client = client;
        _creditCardRepository = creditCardRepository;
    }
    
    [Given(@"the credit card has a default payment amount of (.*) euros")]
    public void GivenTheCreditCardHasADefaultPaymentAmountOfEuros(int amount)
    {
        var creditCard = _scenarioContext.Get<CreditCard>(nameof(CreditCard));

        creditCard.SetDefaultPaymentAmount(amount);
        _creditCardRepository.Update(creditCard);
    }

    [When(@"I set the limit to (.*) euros")]
    public async Task WhenISetTheLimitToEuros(int limitAmount)
    {
        var creditCard = _scenarioContext.Get<CreditCard>(nameof(CreditCard));
        _response = await _client.SetLimitAsync(creditCard.Id.Value, limitAmount);
    }
    
    [When(@"I set the threshold to (.*) euros")]
    public async Task WhenISetTheThresholdToEuros(int amount)
    {
        var creditCard = _scenarioContext.Get<CreditCard>(nameof(CreditCard));
        _response = await _client.SetThresholdAsync(creditCard.Id.Value, amount);
    }
    
    [When(@"I set the default payment amount to (.*) euros")]
    public async Task WhenISetTheDefaultPaymentAmountToEuros(int amount)
    {
        var creditCard = _scenarioContext.Get<CreditCard>(nameof(CreditCard));
        _response = await _client.SetDefaultPaymentAmountAsync(creditCard.Id.Value, amount);
    }

    [Then(@"limit on my card is (.*) euros")]
    public void ThenLimitOnMyCardIsEuros(int limitAmount)
    {
        _response.ParsedPayload!.Limit.Should().Be(limitAmount);
    }

    [Then(@"threshold on my card is (.*) euros")]
    public void ThenThresholdOnMyCardIsEuros(int amount)
    {
        _response.ParsedPayload!.Threshold.Should().Be(amount);
    }

    [Then(@"default payment amount on my card is (.*) euros")]
    public void ThenDefaultPaymentAmountOnMyCardIsEuros(int amount)
    {
        _response.ParsedPayload!.DefaultPaymentAmount.Should().Be(amount);
    }
}