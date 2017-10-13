using System;
using Xunit;

namespace Calculator.Tests
{
  public class ExpressionSpecs
  {
    [Theory]
    [InlineData(5 + 5, "5 + 5")]
    [InlineData(5 + 5 + 5, "5 + 5 + 5")]
    [InlineData(5 + (5 * 2), "5 + ( 5 * 2)")]
    [InlineData(-5 + -5, "-5 + -5")]
    [InlineData(-(5 + 5), "-(5 + 5)")]
    [InlineData(1 + 2 / 3, "1 + 2 / 3")]
    [InlineData(25, "5^2")]
    public void PerformsBasicCalculations(double expectedResult, string expression)
    {
      var parser = new ExpressionParser();
      Assert.Equal(expectedResult, parser.Execute(expression));
    }

    [Theory]
    [InlineData(1024, "Pow(2,10)")]
    [InlineData(12, "Max(10,12)")]
    public void CallsMathFunctions(double expectedResult, string expression)
    {
      var parser = new ExpressionParser();
      Assert.Equal(expectedResult, parser.Execute(expression));
    }

    [Theory]
    [InlineData("5 + Foo")]
    [InlineData("(5 + 5")]
    public void FailsOnInvalidSyntax(string badExpression)
    {
      var parser = new ExpressionParser();
      Assert.Throws<Exception>(() => parser.Execute(badExpression));
    }

    [Theory]
    [InlineData(Math.PI, "pi")]
    [InlineData(Math.E, "e")]
    public void SupportsMathConstants(double expectedResult, string expression)
    {
      var parser = new ExpressionParser();
      Assert.Equal(expectedResult, parser.Execute(expression));
    }

    [Theory]
    [InlineData((2 * 2) / 3.0, "(2 × 2) ÷ 3")]
    [InlineData(2 * 2 * 3, "2 × 2 * 3")]
    public void SupportsMathSymbols(double expectedResult, string expression)
    {
      var parser = new ExpressionParser();
      Assert.Equal(expectedResult, parser.Execute(expression));
    }
  }
}
