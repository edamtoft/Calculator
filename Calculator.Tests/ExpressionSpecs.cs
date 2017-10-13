using System;
using Xunit;

namespace Calculator.Tests
{
  public class ExpressionSpecs
  {
    [Fact]
    public void PerformsBasicCalculations()
    {
      var parser = new ExpressionParser();

      Assert.Equal(5 + 5, parser.Execute("5 + 5"));
      Assert.Equal(5 + 5 + 5, parser.Execute("5 + 5 + 5"));
      Assert.Equal(5 + (5 * 2), parser.Execute("5 + ( 5 * 2)"));
      Assert.Equal(-5 + -5, parser.Execute("-5 + -5"));
      Assert.Equal(-(5 + 5), parser.Execute("-(5 + 5)"));
      Assert.Equal(1 + 2 / 3, parser.Execute("1 + 2 / 3"));
      Assert.Equal(Math.Pow(5,2), parser.Execute("5^2"));
    }

    [Fact]
    public void CallsMathFunctions()
    {
      var parser = new ExpressionParser();

      Assert.Equal(Math.Pow(2,10), parser.Execute("Pow(2,10)"));
      Assert.Equal(Math.Pow(2, -10), parser.Execute("Pow(2, -10)"));
      Assert.Equal(Math.Max(10, 7), parser.Execute("Max(  10, 7  )"));
    }

    [Fact]
    public void FailsOnInvalidSyntax()
    {
      var parser = new ExpressionParser();

      Assert.Throws<Exception>(() => parser.Execute("5 + Foo"));
    }

    [Fact]
    public void SupportsMathConstants()
    {
      var parser = new ExpressionParser();

      Assert.Equal(2 * Math.PI, parser.Execute("2*pi"));
      Assert.Equal(Math.E, parser.Execute("e"));
    }

    [Fact]
    public void SupportsMathSymbols()
    {
      var parser = new ExpressionParser();

      Assert.Equal((2 * 2) / 3.0, parser.Execute("(2 × 2) ÷ 3"));
    }
  }
}
