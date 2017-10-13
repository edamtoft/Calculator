# Calculator

A simple sample project using [Sprache](https://github.com/sprache/Sprache) to parse mathmatical expressions to c# expression trees, based heavily on [This Sample]( https://github.com/sprache/Sprache/blob/master/samples/LinqyCalculator/ExpressionParser.cs). The parser supports basic mathmatical operators, order of operations, and Math.* functions.

## Usage

```csharp
var parser = new ExpressionParser();

var result = parser.Execute("5 + 5");
```

## Sample Expressions

```
5 + 5
5 + 5 + 5
5 + ( 5 * 2)
-5 + -5
-(5 + 5)
1 + 2 / 3
5^2
Pow(2,10)
Pow(2, -10)
Max(  10, 7  )
2*pi
e
(2 × 2) ÷ 3
```