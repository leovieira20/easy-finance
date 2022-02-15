using System;
using EasyFinance.Domain.Accounts;
using Xunit;

namespace EasyFinance.Domain.Tests.Unit.Entities;

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
}