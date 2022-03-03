using System;
using System.Threading.Tasks;
using EasyFinance.Application.Register;
using EasyFinance.Web.Tests.Integration.Infrastructure.Clients;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace EasyFinance.Web.Tests.Integration.Steps;

[Binding]
public class RegisterCreditCardStepDefinitions
{
    private readonly CreditCardClient _client;
    private CreditCardDtoPublicModel _bankAccount;
    private string _cardName;

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