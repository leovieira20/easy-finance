using System;
using CreditCardModule.Domain;
using TechTalk.SpecFlow;

namespace EasyFinance.Web.Tests.Integration.Steps;

[Binding]
public class CreditCardRepositoryStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;
    private readonly ICreditCardRepository _creditCardRepository;

    public CreditCardRepositoryStepDefinitions(ScenarioContext scenarioContext, ICreditCardRepository creditCardRepository)
    {
        _scenarioContext = scenarioContext;
        _creditCardRepository = creditCardRepository;
    }
    
    [Given(@"I haven't registered any credit cards yet")]
    public void GivenIHaventRegisteredAnyCreditCardsYet()
    {
    }
    
    [Given(@"a registered credit card")]
    public void GivenARegisteredCreditCard()
    {
        var creditCard = CreditCard.Create(Guid.NewGuid().ToString());
        
        _creditCardRepository.Create(creditCard);
        
        _scenarioContext.Add(nameof(CreditCard), creditCard);
    }
}