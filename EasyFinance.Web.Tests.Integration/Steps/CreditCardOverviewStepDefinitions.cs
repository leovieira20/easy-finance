using System;
using System.Threading.Tasks;
using EasyFinance.Application.Overview;
using EasyFinance.Web.Tests.Integration.Infrastructure.Clients;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace EasyFinance.Web.Tests.Integration.Steps;

[Binding]
public class CreditCardOverviewStepDefinitions
{
    private readonly CreditCardOverviewClient _client;
    private CreditCardOverviewDto _overview;

    public CreditCardOverviewStepDefinitions(CreditCardOverviewClient client)
    {
        _client = client;
    }
    
    [When(@"credit card overview is set for (.*) and (.*)")]
    public async Task WhenCreditCardOverviewIsSetForDates(DateTime startDate, DateTime endDate)
    {
        var (overview, _) = await _client.Get(startDate, endDate);
        _overview = overview!;
    }

    [Then(@"credit card overview per month shows")]
    public void ThenCreditCardOverviewPerMonthShows(Table table)
    {
        table.CompareToSet(_overview.Breakdowns);
    }
}