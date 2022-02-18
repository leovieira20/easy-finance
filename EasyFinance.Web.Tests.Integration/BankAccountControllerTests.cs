using System;
using System.Threading.Tasks;
using EasyFinance.Web.Tests.Integration.Helpers.Clients;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace EasyFinance.Web.Tests.Integration;

public class BankAccountControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public BankAccountControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task RegisterAccount()
    {
        var client = _factory.CreateClient();

        var accountName = Guid.NewGuid().ToString();
        
        var response = await BankAccountClient.RegisterBankAccountAsync(client, accountName);

        response?.Name.Should().Be(accountName);
        response?.Id.Should().NotBeEmpty();
    }
    
    [Fact]
    public async Task AddFundsToAccount()
    {
        var client = _factory.CreateClient();

        var accountName = Guid.NewGuid().ToString();
        
        var response = await BankAccountClient.RegisterBankAccountAsync(client, accountName);

        var summary = await BankAccountClient.AddFundsToAccountAsync(client, response!.Id, 1);

        summary.Balance.Should().Be(1);
    }
}