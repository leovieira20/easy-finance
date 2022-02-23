using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using EasyFinance.Web.Tests.Integration.Infrastructure.Clients;
using EasyFinance.Web.Tests.Integration.Infrastructure.Web;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Xunit;

namespace EasyFinance.Web.Tests.Integration;

public class BankAccountTransactionControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly BankAccountClient _bankAccountClient;
    private readonly BankAccountTransactionClient _bankAccountTransactionClient;

    public BankAccountTransactionControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _bankAccountClient = new BankAccountClient(factory);
        _bankAccountTransactionClient = new BankAccountTransactionClient(factory);
    }
    
    [Fact]
    public async Task InvalidBankAccountId()
    {
        var (_, response) = await _bankAccountTransactionClient.ShowBankAccountTransactionsAsync(Guid.Empty);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Fact]
    public async Task NoTransactions()
    {
        var accountName = Guid.NewGuid().ToString();
        var result = await _bankAccountClient.RegisterBankAccountAsync(accountName);
        
        var (transactions, _) = await _bankAccountTransactionClient.ShowBankAccountTransactionsAsync(result.bankAccount!.Id);

        transactions.Should().BeEmpty();
    }
    
    [Fact]
    public async Task OneDeposit()
    {
        var accountName = Guid.NewGuid().ToString();
        var result = await _bankAccountClient.RegisterBankAccountAsync(accountName);

        var bankAccountId = result.bankAccount!.Id;
        
        await _bankAccountClient.RegisterDepositToAccountAsync(bankAccountId, 1, 1);
        
        var (transactions, _) = await _bankAccountTransactionClient.ShowBankAccountTransactionsAsync(bankAccountId);

        var deposit = transactions!.First();

        deposit.Amount.Should().Be(1);
    }
}