using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAccounts.Api.Tests.Infrastructure.Clients;
using BankAccounts.Application.Models;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BankAccounts.Api.Tests.Steps;

[Binding]
public class ShowBankAccountBalanceOverTimeStepDefinitions
{
    private readonly BankAccountClient _bankAccountClient;
    private readonly BankAccountOverviewClient _bankAccountOverviewClient;
    private readonly BankAccountTransactionClient _bankAccountTransactionClient;
    private BankAccountDto? _bankAccount;
    private List<MonthlyBreakdownDto>? _bankAccountOverview;

    public ShowBankAccountBalanceOverTimeStepDefinitions(BankAccountClient bankAccountClient, BankAccountOverviewClient bankAccountOverviewClient, BankAccountTransactionClient bankAccountTransactionClient)
    {
        _bankAccountClient = bankAccountClient;
        _bankAccountOverviewClient = bankAccountOverviewClient;
        _bankAccountTransactionClient = bankAccountTransactionClient;
    }

    [Given(@"my bank account has some transactions")]
    public async Task GivenMyBankAccountHasSomeTransactions(Table table)
    {
        var transactions = table.CreateSet(x =>
            new Tuple<int, decimal>(x.GetInt32("Month"), x.GetDecimal("Amount")));

        var (bankAccount, _) = await _bankAccountClient.RegisterBankAccountAsync(Guid.NewGuid().ToString());
        _bankAccount = bankAccount;

        foreach (var (month, amount) in transactions)
        {
            await _bankAccountTransactionClient.RegisterDepositToAccountAsync(bankAccount!.Id, amount, month);
        }
    }

    [When(@"I request the account overview for (.*) months")]
    public async Task WhenIRequestTheAccountOverviewForMonths(int months)
    {
        var (bankAccountOverview, _) = await _bankAccountOverviewClient
            .GetOverviewAsync(_bankAccount!.Id, months);
        _bankAccountOverview = bankAccountOverview;
    }

    [Then(@"I see a monthly overview")]
    public void ThenISeeAMonthlyOverview(Table table)
    {
        var monthlyBreakdown = table.CreateSet(x => new Tuple<int, decimal>(
            x.GetInt32("Month"),
            x.GetDecimal("Balance")
        ));

        var today = DateTime.UtcNow;
        foreach (var (month, balance) in monthlyBreakdown)
        {
            var aMonthBreakdown = _bankAccountOverview!.Single(x => x.Month == today.AddMonths(month).Month);
            aMonthBreakdown.Should().Be(balance);
        }
    }
}