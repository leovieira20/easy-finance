using BankAccounts.Application.Models;
using BankAccounts.Domain.Aggregates.BankAccountAggregate;
using BankAccounts.Domain.Aggregates.BankAccountTransactionAggregate;
using FluentAssertions;
using LightBDD.XUnit2;
using NSubstitute;

namespace BankAccounts.Application.Tests.Acceptance.RegisterPaymentToBankAccountTests;

public partial class RegisterPaymentToBankAccountTests : FeatureFixture
{
    private readonly IBankAccountRepository _repository;
    private readonly RegisterPaymentToBankAccount.Handler _sut;
    private BankAccountSummaryDto _response = null!;
    private decimal _depositValue;
    private BankAccount _bankAccount = null!;
    private readonly DateTime _depositDate = DateTime.UtcNow;

    public RegisterPaymentToBankAccountTests()
    {
        _repository = Substitute.For<IBankAccountRepository>();
        _sut = new(_repository);
    }

    private Task GivenNonExistentBankAccount()
    {
        return Task.CompletedTask;
    }

    private Task GivenExistentBankAccount()
    {
        _bankAccount = BankAccount.Create(Guid.Empty.ToString());
        _repository
            .GetAsync(default)
            .ReturnsForAnyArgs(_bankAccount);
        
        _repository
            .Update(default)
            .ReturnsForAnyArgs(x => x.Arg<BankAccount>());
        
        _repository
            .SaveChangesAsync(default)
            .ReturnsForAnyArgs(x => x.Arg<BankAccount>());
        
        return Task.CompletedTask;
    }

    private Task AndPaymentOf(decimal depositValue)
    {
        _depositValue = depositValue;
        
        return Task.CompletedTask;
    }

    private async Task WhenActionIsExecuted()
    {
        _response = await _sut.Handle(new(
                default, 
                _depositValue, 
                _depositDate), 
            CancellationToken.None);
    }

    private Task ThenEmptyBalanceIsReturned()
    {
        _response.Balance.Should().Be(0);

        return Task.CompletedTask;
    }

    private Task ThenTransactionIsRegistered()
    {
        var expectedTransaction = BankAccountTransaction.CreateDebit(_depositDate, _depositValue, string.Empty);
        
        _bankAccount.Transactions.Should().ContainEquivalentOf(
            expectedTransaction, 
            config => config.Excluding(x => x.Id));
        
        return Task.CompletedTask;
    }

    private Task ThenNewBalanceIsReturned()
    {
        _response.Balance.Should().Be(_depositValue);
        
        return Task.CompletedTask;
    }
}