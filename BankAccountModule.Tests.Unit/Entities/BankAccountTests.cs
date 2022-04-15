using System;
using BankAccountModule.Domain;
using FluentAssertions;
using Xunit;

namespace BankAccountModule.Tests.Unit.Entities;

public class BankAccountTests
{
    [Fact]
    public void CannotCreateWithNullName()
    {
        Assert.Throws<ArgumentNullException>(() => BankAccount.Create(null!));
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void CannotCreateWithEmptyName(string name)
    {
        Assert.Throws<ArgumentException>(() => BankAccount.Create(name));
    }

    [Fact]
    public void WhenAccountIsCreatedThenBalanceIsZero()
    {
        var bankAccount = BankAccount.Create(Guid.NewGuid().ToString());

        bankAccount.Balance.Should().Be(0);
    }

    [Fact]
    public void WhenAccountIsCreatedThenThereAreNoTransactions()
    {
        var bankAccount = BankAccount.Create(Guid.NewGuid().ToString());

        bankAccount.Transactions.Should().BeEmpty();
    }
}