using System;
using System.Linq;
using BankAccountModule.Domain;
using FluentAssertions;
using Xunit;

namespace BankAccountModule.Domain.Tests.Unit.Entities;

public class BankAccountTests
{
    [Fact]
    public void CannotCreateWithNullName()
    {
        Assert.Throws<ArgumentNullException>(() => BankAccount.CreateWithName(null!));
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void CannotCreateWithEmptyName(string name)
    {
        Assert.Throws<ArgumentException>(() => BankAccount.CreateWithName(name));
    }
    
    [Fact]
    public void WhenAccountIsCreatedThenNameIsPopulated()
    {
        var bankAccountName = Guid.NewGuid().ToString();
        
        var bankAccount = BankAccount.CreateWithName(bankAccountName);

        bankAccount.Name.Should().Be(bankAccountName);
    }

    [Fact]
    public void WhenAccountIsCreatedThenBalanceIsZero()
    {
        var bankAccount = BankAccount.CreateWithName(Guid.NewGuid().ToString());

        bankAccount.Balance.Should().Be(0);
    }

    [Fact]
    public void WhenAccountIsCreatedThenThereAreNoTransactions()
    {
        var bankAccount = BankAccount.CreateWithName(Guid.NewGuid().ToString());

        bankAccount.Transactions.Should().BeEmpty();
    }
    
    [Fact]
    public void WhenDepositIsAddedThenBalanceIsIncreased()
    {
        var bankAccount = BankAccount.CreateWithName(Guid.NewGuid().ToString());

        var date = DateTime.UtcNow;
        var amount = 100;
        var description = Guid.NewGuid().ToString();
        
        bankAccount = bankAccount.RegisterDeposit(date, amount, description);

        bankAccount.Balance.Should().Be(amount);
        
        var transaction = bankAccount.Transactions.First();
        transaction.Date.Should().Be(date);
        transaction.Amount.Should().Be(amount);
        transaction.Description.Should().Be(description);
    }
    
    [Fact]
    public void WhenExpenseIsAddedThenBalanceIsDecreased()
    {
        var bankAccount = BankAccount.CreateWithName(Guid.NewGuid().ToString());

        var date = DateTime.UtcNow;
        var amount = 100;
        var description = Guid.NewGuid().ToString();
        
        bankAccount = bankAccount.RegisterExpense(date, amount, description);

        bankAccount.Balance.Should().Be(-amount);
        
        var transaction = bankAccount.Transactions.First();
        transaction.Date.Should().Be(date);
        transaction.Amount.Should().Be(amount);
        transaction.Description.Should().Be(description);
    }
}