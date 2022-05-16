# C#

## Content

- data types, operators
- control structures, loops
- components
- functions
- string class
- debugging, error handling
- Microsoft documentation

## Simple Console App

### Create and run

#### Create
```console
$ dotnet new console
```

#### Run
```console
$ dotnet run
```

#### Build
```console
$ dotnet build
```

### Basic Program Layout

```csharp
namespace MyApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
	}
}
```

#### Only possible since C# 10
```csharp
Console.WriteLine("Hello, World!");
```

### Echo User Input
```csharp
Console.WriteLine("What do you want to say?");
var input = Console.ReadLine();
Console.Write("You said: ");
Console.WriteLine(input);
```



## Variables

### Declaration

- **type**: defines type of the variable
- **name**: must start with a character, `_` or `@`
- **Convention**: `camelCase` with first letter `lowercase`

```csharp
int myValue = 42;  // explicit type
var myValue = 42;  // implicit type (inferred from value)
```

### Compatible Types

```csharp
var a = 2;
var b = 3.3;
var c = a + b;  // 5.3
```

```csharp
var a = "2";
var b = "3.3";
var c = a + b;  // 23.3
```

### Incompatible Types

```csharp
var a = 2;
var b = "3.3";
var c = a + b;  // will not compile
```

### Inbuilt types

[-> Microsoft inbuilt types](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types)

### Array

- can hold a number of items
- fixed size

```csharp
var array = new int[3];
var array = new[3] { 1, 2, 3 };
var array = new[] { 1, 2, 3 };

array[0] = -2                // replace 1st item
Console.WriteLine(array[1]); // print 2nd item
```

### List

- can hold a number of items
- variable size
- defined in `System.Collections.Generic`
- it may be necessary to add on top: `using System.Collections.Generic;`

```csharp
var list = new List<int>();
var list = new List<int> { 1, 2, 3 };

list[1] = 2;                // replace 2nd item
list.Add(233);              // add an item
Console.WriteLine(list[3]); // print 4th item
```

### String

- can hold a number of characters
- fixed size
- offers a large list of manipulation tools

```csharp
var firstName = "Harry";
var lastName = "Haller";

var fullName = firstName + " " + lastName;  //combine with one " " in the middle
var fullName = $"{firstName} {lastName}";   //combine with one " " in the middle
Console.WriteLine(fullName[3]);             //print 2nd character
```

## Loops

### Index Based For Loop

```csharp
var array = new[] { 21, 312, 53, 90, -19 };

for (int i = 0; i < array.Length; ++i) {
	Console.WriteLine($"Number {i + 1} is {array[i]}");
}
```

### Foreach Loop

```csharp
var array = new[] { 21, 312, 53, 90, -19 };

foreach(var number in array) {
	Console.WriteLine($"Number: {number}");
}
```

### While Loop

```csharp
var list = new List<int> { 21, 312, 53, 90, -19, 42 };

while (list.Count > 0) {
	Console.WriteLine(list[0]);
	list.RemoveAt(0);
}
```

### Do-While Loop

```csharp
do {
	Console.Write("\rCurrent time is ");
	Console.Write(DateTime.Now.TimeOfDay);
	Console.WriteLine(" (press any key to update or ESC to quit)");
} while (Console.ReadKey().Key != ConsoleKey.Escape);
```

## Branching

### If

```csharp
var value = 42;

if (value > 42) {
	Console.WriteLine("Very big")
}
```

### If else-if

```csharp
var value = 42;

if (value > 42) {
	Console.WriteLine("Very big");
} else if(value == 42) {
	Console.WriteLine("Perfect");
}
```

### If else-if else

```csharp
var value = 42;

if (value > 42) {
	Console.WriteLine("Very big");
} else if(value == 42) {
	Console.WriteLine("Perfect");
} else {
	Console.WriteLine("so tiny, so very very tiny");
}
```

### Switch statement

```csharp
var value = 42;

switch (value) {
	case 42:
		Console.WriteLine("Perfect 42");
		break;
	case 11:
		Console.WriteLine("Perfect 11");
		break;
	case 5:
		Console.WriteLine("Perfect 5");
		break;
	default:
		Console.WriteLine("Wring");
		break;
}
```

### Switch expression

```csharp
var value = 42;

var msg = value switch {
	42 => "Perfect";
	> 42 => "So very large";
	_ => "So very tiny";
}

Console.WriteLine(msg);
```
