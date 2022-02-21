using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using EasyFinance.Web.Tests.Integration.Helpers.Clients;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace EasyFinance.Web.Tests.Integration;

public class BankAccountControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public BankAccountControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Theory]
    [InlineData(default)]
    [InlineData(" ")]
    public async Task RegisterAccount_InvalidName(string accountName)
    {
        var (_, response) = await BankAccountClient.RegisterBankAccountAsync(_client, accountName);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task RegisterAccount()
    {
        var accountName = Guid.NewGuid().ToString();
        
        var (bankAccount, _) = await BankAccountClient.RegisterBankAccountAsync(_client, accountName);

        bankAccount?.Name.Should().Be(accountName);
        bankAccount?.Id.Should().NotBeEmpty();
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task RegisterDepositToAccount_InvalidAmount(decimal amount)
    {
        var (_, response) = await BankAccountClient.RegisterDepositToAccountAsync(_client, Guid.NewGuid(), amount);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Fact]
    public async Task RegisterDepositToAccount_InvalidBankAccountId()
    {
        var (_, response) = await BankAccountClient.RegisterDepositToAccountAsync(_client, default, 1);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Fact]
    public async Task RegisterDepositToAccount()
    {
        var accountName = Guid.NewGuid().ToString();
        
        var (bankAccount, _) = await BankAccountClient.RegisterBankAccountAsync(_client, accountName);

        var (summary, _) = await BankAccountClient.RegisterDepositToAccountAsync(_client, bankAccount!.Id, 1);

        summary!.Balance.Should().Be(1);
    }
}