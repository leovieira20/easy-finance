using System;
using System.Threading.Tasks;
using CreditCards.Api.Tests.Infrastructure.Clients;
using CreditCards.Application.Models;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace CreditCards.Api.Tests.Steps;

[Binding]
public class RegisterCreditCardStepDefinitions
{
    private readonly CreditCardClient _client;
    private CreditCardDto _bankAccount = null!;
    private string _cardName = null!;

    public RegisterCreditCardStepDefinitions(CreditCardClient client)
    {
        _client = client;
    }

    [When(@"I register a valid credit card")]
    public async Task WhenIRegisterAValidCreditCard()
    {
        _cardName = Guid.NewGuid().ToString();
        var (bankAccount, _) = await _client.Register(_cardName);
        _bankAccount = bankAccount!;
    }

    [Then(@"credit card is created")]
    public void ThenCreditCardIsCreated()
    {
        _bankAccount.Id.Should().NotBeEmpty();
        _bankAccount.Name.Should().Be(_cardName);
    }
}