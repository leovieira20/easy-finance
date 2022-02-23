using EasyFinance.Application.AccountOverview.GetBankAccountOverview;
using EasyFinance.Domain.Accounts;
using FluentAssertions;
using NSubstitute;
using TechTalk.SpecFlow.Assist;

namespace EasyFinance.Application.Tests.Acceptance.Steps;

[Binding]
public class GetBankAccountOverviewSteps
{
    private readonly IBankAccountTransactionRepository _bankAccountTransactionRepository;
    private readonly GetBankAccountOverviewCommandHandler _sut;
    private BankAccountOverviewDto _result = null!;

    public GetBankAccountOverviewSteps(ScenarioContext scenarioContext)
    {
        _bankAccountTransactionRepository = Substitute.For<IBankAccountTransactionRepository>();

        _sut = new GetBankAccountOverviewCommandHandler(_bankAccountTransactionRepository);
    }
    
    [Given(@"my bank account has some transactions")]
    public void GivenMyBankAccountHasSomeTransactions(Table table)
    {
        var transactions = table
            .CreateSet(x => new BankAccountTransaction(x.GetDecimal("Amount"), DateTime.UtcNow.AddMonths(x.GetInt32("Month"))));

        _bankAccountTransactionRepository
            .GetForBankAccountAsync(default, default, default)
            .ReturnsForAnyArgs(transactions.ToList());
    }

    [When(@"I request the account overview for (.*) months")]
    public async Task WhenIRequestTheAccountOverviewForMonths(int months)
    {
        var startDate = DateTime.UtcNow;
        var endDate = DateTime.UtcNow.AddMonths(months);
        
        _result = await _sut.Handle(new GetBankAccountOverviewCommand(new BankAccountId(Guid.NewGuid()), 
                startDate, 
                endDate), 
            CancellationToken.None);
    }

    [Then(@"I see a monthly overview breakdown")]
    public void ThenISeeAMonthlyOverviewBreakdown(Table table)
    {
        var today = DateTime.UtcNow;
        foreach (var row in table.Rows)
        {
            var expectedMonth = today.AddMonths(row.GetInt32("Month")).Month;
            var breakdown = _result.Breakdowns.Single(x => x.Month == expectedMonth);
            breakdown.Balance.Should().Be(row.GetDecimal("Balance"));
        }
    }
}