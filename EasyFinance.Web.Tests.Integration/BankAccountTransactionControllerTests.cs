using System;
using System.Linq;
using System.Net;
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
    public async Task InvalidBankAccountId()
    {
        var (_, response) = await BankAccountTransactionClient.ShowBankAccountTransactionsAsync(_client, Guid.Empty);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Fact]
    public async Task NoTransactions()
    {
        var accountName = Guid.NewGuid().ToString();
        var result = await BankAccountClient.RegisterBankAccountAsync(_client, accountName);
        
        var (transactions, _) = await BankAccountTransactionClient.ShowBankAccountTransactionsAsync(_client, result.bankAccount!.Id);

        transactions.Should().BeEmpty();
    }
    
    [Fact]
    public async Task OneDeposit()
    {
        var accountName = Guid.NewGuid().ToString();
        var result = await BankAccountClient.RegisterBankAccountAsync(_client, accountName);

        var bankAccountId = result.bankAccount!.Id;
        
        await BankAccountClient.RegisterDepositToAccountAsync(_client, bankAccountId, 1);
        
        var (transactions, _) = await BankAccountTransactionClient.ShowBankAccountTransactionsAsync(_client, bankAccountId);

        var deposit = transactions!.First();

        deposit.Amount.Should().Be(1);
    }
}