using System;
using System.Net;
using System.Threading.Tasks;
using EasyFinance.Web.Tests.Integration.Infrastructure.Clients;
using EasyFinance.Web.Tests.Integration.Infrastructure.Web;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace EasyFinance.Web.Tests.Integration;

public class BankAccountControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly BankAccountClient _bankAccountClient;

    public BankAccountControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _bankAccountClient = new BankAccountClient(factory);
    }

    [Theory]
    [InlineData(default)]
    [InlineData(" ")]
    public async Task RegisterAccount_InvalidName(string accountName)
    {
        var (_, response) = await _bankAccountClient.RegisterBankAccountAsync(accountName);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task RegisterAccount()
    {
        var accountName = Guid.NewGuid().ToString();
        
        var (bankAccount, _) = await _bankAccountClient.RegisterBankAccountAsync(accountName);

        bankAccount?.Name.Should().Be(accountName);
        bankAccount?.Id.Should().NotBeEmpty();
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task RegisterDepositToAccount_InvalidAmount(decimal amount)
    {
        var (_, response) = await _bankAccountClient.RegisterDepositToAccountAsync(Guid.NewGuid(), amount, 1);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Fact]
    public async Task RegisterDepositToAccount_InvalidBankAccountId()
    {
        var (_, response) = await _bankAccountClient.RegisterDepositToAccountAsync(default, 1, 1);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Fact]
    public async Task RegisterDepositToAccount()
    {
        var accountName = Guid.NewGuid().ToString();
        
        var (bankAccount, _) = await _bankAccountClient.RegisterBankAccountAsync(accountName);

        var (summary, _) = await _bankAccountClient.RegisterDepositToAccountAsync(bankAccount!.Id, 1, 1);

        summary!.Balance.Should().Be(1);
    }
}