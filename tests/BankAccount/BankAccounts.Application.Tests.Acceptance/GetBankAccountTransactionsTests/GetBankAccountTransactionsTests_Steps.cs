using BankAccounts.Application.Models;
using BankAccounts.Domain.Aggregates.BankAccountTransactionAggregate;
using FluentAssertions;
using LightBDD.Framework.Parameters;
using LightBDD.XUnit2;
using NSubstitute;

namespace BankAccounts.Application.Tests.Acceptance.GetBankAccountTransactionsTests;

public partial class GetBankAccountTransactionsTests : FeatureFixture
{
    private readonly GetBankAccountTransactions.Handler _sut;
    private readonly IBankAccountTransactionRepository _repository;
    private List<BankAccountTransactionDto> _result = null!;

    public GetBankAccountTransactionsTests()
    {
        _repository = Substitute.For<IBankAccountTransactionRepository>();
        _sut = new GetBankAccountTransactions.Handler(_repository);
    }

    public Task GivenExistentTransactions(InputTable<BankAccountTransaction> transactions)
    {
        _repository
            .GetForBankAccountAsync(default, default, default)
            .ReturnsForAnyArgs(transactions.ToList());
        
        return Task.CompletedTask;
    }
    
    public async Task WhenActionIsExecuted()
    {
        _result = await _sut.Handle(new(Guid.Empty), CancellationToken.None);
    }
    
    public Task ThenTransactionsAreReturned(InputTable<BankAccountTransactionDto> expected)
    {
        _result.Should().Contain(expected.ToList());
        return Task.CompletedTask;
    }
}