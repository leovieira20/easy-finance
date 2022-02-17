using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EasyFinance.Web.Controllers;
using EasyFinance.Web.Models.Input;
using EasyFinance.Web.Models.Output;
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
    public async Task RegistersAccount()
    {
        var client = _factory.CreateClient();

        var accountName = Guid.NewGuid().ToString();
        
        var response = await client.PostAsJsonAsync("/BankAccount/Register", new RegisterBankAccountRequest
        {
            Name = accountName
        });

        var dto = await response.Content.ReadFromJsonAsync<BankAccountPublicModel>();

        dto?.Name.Should().Be(accountName);
        dto?.Id.Should().NotBeEmpty();
    }
}