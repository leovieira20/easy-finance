using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CreditCardModule.Api.Tests.Infrastructure.Clients;
using CreditCardModule.Application.Models;
using CreditCardModule.Domain;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CreditCardModule.Api.Tests.Steps;

[Binding]
public class CreditCardOverviewStepDefinitions
{
    private readonly ScenarioContext _context;
    private readonly CreditCardOverviewClient _client;
    private IEnumerable<CreditCardMonthlyBreakdownDto> _overview = null!;

    public CreditCardOverviewStepDefinitions(ScenarioContext context, CreditCardOverviewClient client)
    {
        _context = context;
        _client = client;
    }
    
    [When(@"credit card overview is set for (.*) and (.*)")]
    public async Task WhenCreditCardOverviewIsSetForDates(DateTime startDate, DateTime endDate)
    {
        var creditCard = _context.Get<CreditCard>(nameof(CreditCard));
        var (overview, _) = await _client.Get(creditCard.Id, startDate, endDate);
        _overview = overview!;
    }

    [Then(@"credit card overview per month shows")]
    public void ThenCreditCardOverviewPerMonthShows(Table table)
    {
        table.CompareToSet(_overview);
    }
}