# C# Eval Function (Enterprise Feature)

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

The execute function will resolve, compile, execute the expression and return the result either as a simple type or a result object.

## String expression
The expression to execute can be a single string with no other parameters. With this option the string cannot be composed of dynamic content. This method can be used to process content from an external source, like a webpage or a REST client.

### Example
```csharp
string isEvenFunction = "<Number> % 2 == 0";
isEvenFunction = isEvenFunction.Replace("<Number>", "4");
Console.WriteLine(isEvenFunction);
bool IsEvenNumber = Eval.Execute<bool>(isEvenFunction);
```
[Try it]()

## String Expression with object parameter
The expression to execute can be a string that reference an object from your code. With this option the string can be entirely composed of dynamic content. This can be used to build dynamic filters or execute user-based regular expression.

### Example

```csharp
// Parameter: Anonymous Type
int result = Eval.Execute<int>("X + Y", new { X = 1, Y = 2} );

// Parameter: Argument Position
int result = Eval.Execute<int>("{0} + {1}", 1, 2);

// Parameter: Class Member
dynamic expandoObject = new ExpandoObject();
expandoObject.X = 1;
expandoObject.Y = 2;
int result = Eval.Execute<int>("X + Y", expandoObject);

// Parameter: Dictionary Key
var values = new Dictionary<string, object>() { {"X", 1}, {"Y", 2} };
int result = Eval.Execute<int>("X + Y", values);
```

[Try it](https://dotnetfiddle.net/W9TwcP)

## String Expression with array of object parameters
Is it also possible to use an array of object parameters which enable you to create more complex expressions than with a single object.
### Example

```csharp
// Parameter: Dictionary Key
var values = new Dictionary<string, object>() { {"X", 1}, {"Y", 2} };
int result = Eval.Execute<int>("X + Y", values);
```

[Try it]()

# Eval.Compile
Eval.Compile work like Eval.Execute except that it returns a [delegate object](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/)
If you are going to execute the same expression multiple times, in a loop for instance, using compile instead to get better performance and optimize your code.

### Example
```csharp
// Delegate Func
var compiled = Eval.Compile<Func<int, int, int>>("{0} + {1}");
int result = compiled(1, 2);

// Delegate Action
var compiled = Eval.Compile<Action<int, int>>("{0} + {1}");
compiled(1, 2);

// Named Parameter
var compiled = Eval.Compile<Func<int, int, int>>("X + Y", "X", "Y");
int result = compiled(1, 2);
```

[Try it](https://dotnetfiddle.net/MBHlX8)


### Eval.Execute

###### Methods

| Name | Description | Example |
| :--- | :---------- | :------ |
| `TResult Execute(string code)` | Resolve, compile, execute the expression and return the result. | [Try it](https://dotnetfiddle.net/lqfF8b) |
| `TResult Execute<TResult>(string code)` | Resolve, compile, execute the expression and return the result. | [Try it](https://dotnetfiddle.net/lqfF8b) |
| `TResult Execute(string code, object parameters)` | Resolve, compile, execute the expression and return the result. | [Try it](https://dotnetfiddle.net/lqfF8b) |
| `TResult Execute<TResult>(string code, object parameters)` | Resolve, compile, execute the expression and return the result. | [Try it](https://dotnetfiddle.net/lqfF8b) |
| `TResult Execute(string code, params object[] parameters)` | Resolve, compile, execute the expression and return the result. | [Try it](https://dotnetfiddle.net/lqfF8b) |
| `TResult Execute<TResult>(string code, params object[] parameters)` | Resolve, compile, execute the expression and return the result. | [Try it](https://dotnetfiddle.net/lqfF8b) |





