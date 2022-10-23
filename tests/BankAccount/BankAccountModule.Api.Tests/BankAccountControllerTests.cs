using System;
using System.Net;
using System.Threading.Tasks;
using BankAccountModule.Api.Tests.Infrastructure.Clients;
using BankAccountModule.Api.Tests.Infrastructure.Web;
using FluentAssertions;
using Xunit;

namespace BankAccountModule.Api.Tests;

public class BankAccountControllerTests : IClassFixture<CustomWebApplicationFactory<BankAccountModuleProgram>>
{
    private readonly BankAccountClient _bankAccountClient;

    public BankAccountControllerTests(CustomWebApplicationFactory<BankAccountModuleProgram> factory)
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
}