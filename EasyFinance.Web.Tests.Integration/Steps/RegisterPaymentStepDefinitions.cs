using System;
using System.Threading.Tasks;
using EasyFinance.Application.RegisterDepositToBankAccount;
using EasyFinance.Domain.Accounts;
using EasyFinance.Web.Tests.Integration.Infrastructure.Clients;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace EasyFinance.Web.Tests.Integration.Steps;

[Binding]
public class RegisterPaymentStepDefinitions
{
    private readonly ScenarioContext _context;
    private readonly BankAccountTransactionClient _client;
    private BankAccountSummaryDtoPublicModel _summary;

    public RegisterPaymentStepDefinitions(ScenarioContext context, BankAccountTransactionClient client)
    {
        _context = context;
        _client = client;
    }

    [When(@"I make a payment of (.*) euro")]
    public async Task WhenIMakeAPaymentOfEuro(int amount)
    {
        var bankAccountId = _context.Get<Guid>(nameof(BankAccount.Id));

        var response = await _client.RegisterPaymentToAccountAsync(bankAccountId, amount * -1, DateTime.UtcNow);
        _summary = response.summary!;
    }

    [Then(@"my balance is (.*)")]
    public void ThenMyBalanceIs(int expectedAmount)
    {
        _summary.Balance.Should().Be(expectedAmount);
    }
}