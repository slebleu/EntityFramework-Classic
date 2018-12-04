# C# Eval Expression (Enterprise Feature)

## Description
You can evaluate c# code dynamically, at runtime, using the [Eval Expression.NET](http://eval-expression.net/) library.

This library is a free addon included with your purchase of [EF Classic](https://entityframework-classic.net/pricing).

The library support nearly everything:
- Anonymous Type
- Extension Method
- Lambda Expression
- LINQ Dynamic
- Method Overloads
- Async Method

# Eval.Execute

## Description
The execute function will resolve, compile, execute the expression and return the result either as a strongly type result or a result object. The expression can be a static string or a string with reference toward a objects present in the code.

## Static String expression
The expression to execute can be a single string with no other parameters. With this option the string cannot be composed of dynamic content. This method can be used to process content from an external source, like a webpage or a REST client.

### Example
```csharp
public static void Main()
{
	string mathExpression = "+";	
	string formula = "4 <MathFunction> 2";		
	formula = formula.Replace("<MathFunction>", mathExpression);
	var formulaResult = Eval.Execute(formula);
}
```
[Try it](https://dotnetfiddle.net/E2oeb7)

## Dynamic String Expression with object parameter
The expression to execute can be a string that reference an object from your code. With this option the string can be entirely composed of dynamic content. This can be used to build dynamic filters or execute user-based regular expression. You reference either the properties or the methods of the object.

### Example

```csharp
public static void Main()
{
	Equation equation = new Equation(){Constant1 = 4, Constant2 = 2, Operator = "+"};
	var formulaResult = Eval.Execute("Constant1" + equation.Operator + "Constant2", equation);
	Console.WriteLine(equation.GetFormula() + " = "+ formulaResult);
}
```
[Try it](https://dotnetfiddle.net/nCKYkL)

## Dynamic String Expression with array of object parameters
Is it also possible to use an array of object parameters which enable you to create more complex expressions than with a single object.
### Example

```csharp
public static void Main()
{
	var values = new Dictionary<string, object>() { {"Constant1", 1}, {"Constant2", 2}, {"Operator", "+"}};
	var result = Eval.Execute("Constant1" + values["Operator"] + "Constant2", values);
	Console.WriteLine(result);
}
```

[Try it](https://dotnetfiddle.net/LiY9tT)

### Eval.Execute

###### Methods

* `TResult Execute(string code)`
* `TResult Execute(string code, object parameters)`
* `TResult Execute(string code, params object[] parameters)`

###### Strong Typed Methods

* `TResult Execute<TResult>(string code)`
* `TResult Execute<TResult>(string code, object parameters)`
* `TResult Execute<TResult>(string code, params object[] parameters)` 





