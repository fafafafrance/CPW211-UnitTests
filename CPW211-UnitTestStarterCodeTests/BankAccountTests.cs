using Microsoft.VisualStudio.TestTools.UnitTesting;
using CPW211_UnitTestStarterCode;
using System;

namespace CPW211_UnitTestStarterCode.Tests;

[TestClass]
public class BankAccountTests
{
    [TestMethod]
    public void Constructor_ValidOwnerAndBalance_SetsPropertiesCorrectly()
    {
        var account = new BankAccount("Alice", 100.0);
        Assert.AreEqual("Alice", account.Owner);
        Assert.AreEqual(100.0, account.Balance);
    }

    [TestMethod]
    public void Constructor_EmptyOwner_ThrowsArgumentException()
    {
        Assert.ThrowsException<ArgumentException>(() => new BankAccount("", 100.0));
    }

    [TestMethod]
    public void Constructor_NegativeInitialBalance_ThrowsArgumentOutOfRangeException()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new BankAccount("Bob", -25.0));
    }

    [TestMethod]
    public void Deposit_PositiveAmount_IncreasesBalance()
    {
        var account = new BankAccount("Charlie", 50.0);
        account.Deposit(25.0);
        Assert.AreEqual(75.0, account.Balance);
    }

    [TestMethod]
    public void Deposit_ZeroOrNegativeAmount_ThrowsArgumentOutOfRangeException()
    {
        var account = new BankAccount("Charlie", 50.0);
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Deposit(0.0));
    }

    [TestMethod]
    public void Withdraw_ValidAmount_DecreasesBalance()
    {
        var account = new BankAccount("David", 100.0);
        account.Withdraw(40.0);
        Assert.AreEqual(60.0, account.Balance);
    }

    [TestMethod]
    public void Withdraw_ExactTotalBalance_BalanceBecomesZero()
    {
        var account = new BankAccount("Eve", 100.0);
        account.Withdraw(100.0);
        Assert.AreEqual(0.0, account.Balance);
    }

    [TestMethod]
    public void Withdraw_MoreThanBalance_ThrowsInvalidOperationException()
    {
        var account = new BankAccount("Frank", 50.0);
        Assert.ThrowsException<InvalidOperationException>(() => account.Withdraw(100.0));
    }
}