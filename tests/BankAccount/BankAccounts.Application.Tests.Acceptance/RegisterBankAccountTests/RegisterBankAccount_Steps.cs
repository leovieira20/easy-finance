using BankAccounts.Application.Models;
using BankAccounts.Domain.Aggregates.BankAccountAggregate;
using FluentAssertions;
using LightBDD.XUnit2;
using NSubstitute;

namespace BankAccounts.Application.Tests.Acceptance.RegisterBankAccountTests;

public partial class RegisterBankAccountTests : FeatureFixture
{
    private readonly RegisterBankAccount.Handler _sut;
    private BankAccountDto _response = null!;
    private string _bankAccountName = null!;

    public RegisterBankAccountTests()
    {
        var repository = Substitute.For<IBankAccountRepository>();
        _sut = new(repository);
    }

    private Task GivenAValidBankAccountName()
    {
        _bankAccountName = Guid.NewGuid().ToString();
        return Task.CompletedTask;
    }

    private async Task WhenActionIsExecuted()
    {
        _response = await _sut.Handle(new(_bankAccountName), CancellationToken.None);
    }

    private Task ThenBankAccountIsRegistered()
    {
        _response.Id.Should().NotBeEmpty();
        _response.Name.Should().Be(_bankAccountName);
        _response.Status.Should().Be(BankAccountStatus.Enabled);

        return Task.CompletedTask;
    }
}