using System;
using System.Threading.Tasks;
using BankAccountModule.Api.Tests.Infrastructure.Clients;
using BankAccountModule.Application.Models;
using BankAccountModule.Domain;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BankAccountModule.Api.Tests.Steps;

[Binding]
public class RegisterPaymentStepDefinitions
{
    private readonly ScenarioContext _context;
    private readonly BankAccountTransactionClient _client;
    private BankAccountSummaryDto _summary = null!;

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