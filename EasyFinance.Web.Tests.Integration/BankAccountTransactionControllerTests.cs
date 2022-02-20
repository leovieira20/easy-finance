using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EasyFinance.Web.Tests.Integration.Helpers.Clients;
using EasyFinance.Web.Tests.Integration.Infrastructure.Web;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Xunit;

namespace EasyFinance.Web.Tests.Integration;

public class BankAccountTransactionControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public BankAccountTransactionControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }
    
    [Fact]
    public async Task NoTransactions()
    {
        var accountName = Guid.NewGuid().ToString();
        var bankAccount = await BankAccountClient.RegisterBankAccountAsync(_client, accountName);
        
        var transactions = await BankAccountTransactionClient.ShowBankAccountTransactionsAsync(_client, bankAccount!.Id);

        transactions.Should().BeEmpty();
    }
    
    [Fact]
    public async Task OneDeposit()
    {
        var accountName = Guid.NewGuid().ToString();
        var bankAccount = await BankAccountClient.RegisterBankAccountAsync(_client, accountName);

        await BankAccountClient.RegisterDepositToAccountAsync(_client, bankAccount!.Id, 1);
        
        var transactions = await BankAccountTransactionClient.ShowBankAccountTransactionsAsync(_client, bankAccount!.Id);

        var deposit = transactions!.First();

        deposit.Amount.Should().Be(1);
    }
}