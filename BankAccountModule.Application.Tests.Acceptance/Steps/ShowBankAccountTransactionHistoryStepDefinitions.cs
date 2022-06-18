using BankAccountModule.Application.GetBankAccountTransactions;
using BankAccountModule.Domain;
using BankAccountModule.Domain.Repositories;
using FluentAssertions;
using TechTalk.SpecFlow.Assist;

namespace BankAccountModule.Application.Tests.Acceptance.Steps;

[Binding]
public class ShowBankAccountTransactionHistoryStepDefinitions
{
    private ICollection<BankAccountTransactionDto> _transactions = null!;
    private readonly GetBankAccountTransactionsCommandHandler _sut;

    public ShowBankAccountTransactionHistoryStepDefinitions(ScenarioContext context)
    {
        var repository = context.Get<IBankAccountRepository>(nameof(IBankAccountRepository));
        _sut = new GetBankAccountTransactionsCommandHandler(repository);
    }

    [When(@"bank account transactions are listed")]
    public async Task WhenBankAccountTransactionsAreListed()
    {
        var command = new GetBankAccountTransactionsCommand(Guid.NewGuid());

        _transactions = await _sut.Handle(command, CancellationToken.None);
    }

    [Then(@"one deposit is shown")]
    public void ThenOneDepositIsShown(Table transactions)
    {
        var expectedTransactions = transactions.CreateInstance<BankAccountTransaction>();

        var actualTransaction = _transactions.First();
        
        actualTransaction.Amount.Should().Be(expectedTransactions.Amount);
    }

    [Then(@"no transactions are shown")]
    public void ThenNoTransactionsAreShown()
    {
        _transactions.Should().BeEmpty();
    }
}