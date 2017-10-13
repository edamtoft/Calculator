using System;
using System.Linq;
using System.Linq.Expressions;

namespace Calculator.App
{
  class Program
  {
    static void Main(string[] args)
    {
      var parser = new ExpressionParser();
      while (true)
      {
        Console.WriteLine(parser.Execute(Console.ReadLine()));
      }
    }
  }
}
