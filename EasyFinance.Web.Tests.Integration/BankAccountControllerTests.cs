using System;
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

    [Fact]
    public async Task RegisterAccount()
    {
        var accountName = Guid.NewGuid().ToString();
        
        var response = await BankAccountClient.RegisterBankAccountAsync(_client, accountName);

        response?.Name.Should().Be(accountName);
        response?.Id.Should().NotBeEmpty();
    }
    
    [Fact]
    public async Task AddFundsToAccount()
    {
        var accountName = Guid.NewGuid().ToString();
        
        var response = await BankAccountClient.RegisterBankAccountAsync(_client, accountName);

        var summary = await BankAccountClient.RegisterDepositToAccountAsync(_client, response!.Id, 1);

        summary!.Balance.Should().Be(1);
    }
}