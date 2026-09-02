using Microsoft.VisualStudio.TestTools.UnitTesting;
using CPW211_UnitTestStarterCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPW211_UnitTestStarterCode.Tests;

[TestClass()]
public class SimpleMathTests
{
    [TestMethod()]
    [DataRow(5, 10)]
    [DataRow(0, 100)]
    [DataRow(-1, -10)]
    [DataRow(0, -0)]
    public void Add_TwoNumbers_ReturnsSum(double num1, double num2)
    {
        double expected = num1 + num2;
        double actual = SimpleMath.Add(num1, num2);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(5, 2, 10)]
    [DataRow(-3, 4, -12)]
    [DataRow(10, 0, 0)]
    public void Multiply_TwoNumbers_ReturnsProduct(double num1, double num2, double expected)
    {
        double actual = SimpleMath.Multiply(num1, num2);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Divide_DenominatorZero_ThrowsArgumentException()
    {
        ArgumentException ex = Assert.ThrowsException<ArgumentException>(() => SimpleMath.Divide(10, 0));
        Assert.AreEqual("Denominator cannot be zero", ex.Message);
    }

    // TODO: Add a new test to test the Divide method with two valid numbers
    [TestMethod]
    [DataRow(10, 2, 5)]
    [DataRow(9, 3, 3)]
    [DataRow(-12, 4, -3)]
    public void Divide_TwoValidNumbers_ReturnsQuotient(double num1, double num2, double expected)
    {
        double actual = SimpleMath.Divide(num1, num2);
        Assert.AreEqual(expected, actual);
    }

    // TODO: Add a new test to test the subtract method with two valid numbers
    [TestMethod]
    [DataRow(10, 4, 6)]
    [DataRow(5, 10, -5)]
    [DataRow(-3, -3, 0)]
    public void Subtract_TwoValidNumbers_ReturnsDifference(double num1, double num2, double expected)
    {
        double actual = SimpleMath.Subtract(num1, num2);
        Assert.AreEqual(expected, actual);
    }
}