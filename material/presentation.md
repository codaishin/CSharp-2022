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

### Struct

```csharp
struct Person {
	public string name;
	public int age;
}

class Program {
	public static void Main() {
		var personA = new Person {
			name = "Mouse",
			age = 42,
		};
		var personB = new Person {
			name = "Mouse",
			age = 42,
		};

		Console.WriteLine(personA == personB);  // will not compile, no == method
		Console.WriteLine(personA.name);
		Console.WriteLine(personA.age);
		personA.age = 33;
	}
}

```

### Record

```csharp
public record struct Person {
	public string Name { get; init; } = "Anonymous";
	public int Age { get; init; } = 0;
};

class Program {
	public static void Main() {
		var personA = new Person {
			Name = "Mouse",
			Age = 42,
		};
		var personB = new Person {
			Name = "Mouse",
			Age = 42,
		};

		Console.WriteLine(personA == personB);  // true, because properties are equal
		Console.WriteLine(person.Name);
		Console.WriteLine(person.Age);
		person.Age = 33;                        // will not compile, init only
	}
}
```

### Tuple

```csharp
var myTuple = (1, "hello", name: "Picard");
Console.WriteLine(myTuple);  // prints: (1, hello, Picard)
Console.WriteLine(myTuple.Item1);
Console.WriteLine(myTuple.Item2);
Console.WriteLine(myTuple.name);

var (num, greeting, _) = myTuple;
Console.WriteLine(num);
Console.WriteLine(greeting);
```

### Enum

```csharp
enum MyEnum {
	A = 0,
	B = 1,
	C = 2,
}

class Program {
	public static void Main() {
		var value = MyEnum.B;

		Console.WriteLine(value);       // prints A
		Console.WriteLine((int)value);  // prints 1
	}
}
```

### Flag

```csharp
[Flags]
enum MyFlag {
	A = 0b0001,  // could also write 1
	B = 0b0010,  // could also write 2
	C = 0b0100,  // could also wrote 4
}

class Program {
	public static void Main() {
		var value = MyFlag.B | MyFlag.C;

		Console.WriteLine(value);                    // prints B, C
		Console.WriteLine((int)value);               // prints 6
		Console.WriteLine(value.HasFlag(MyFlag.A));  // prints false
		Console.WriteLine(value.HasFlag(MyFlag.B));  // prints true
		Console.WriteLine(value.HasFlag(MyFlag.C));  // prints true
	}
}
```

## Value vs. Reference Type

- **value type**: copy by value (primitive types and structs)
- **reference type**: copy by reference (classes)

### Integer code example
```csharp
int a = 42;
int b = a;
b = 66;
Console.WriteLine(a);
```

### Integer code example output

- first we set the value `a` to `42`
- then we copy the value of `a` into `b`
- then we copy the value `66` into `b`
- thus, we soo no changes in `a`
```console
$ 42
```

### Array code example 1
```csharp
var arrayA = new[] { 4, 2 };
var arrayB = arrayA;
arrayB[0] = 6;
arrayB[1] = 6;
Console.WriteLine(string.Join(", ", arrayA));
```

### Array code example 1 output

- first we create an array and point `arrayA` towards it
- then we point `arrayB` towards the same array
- then we modify that array through `arrayB`
- thus, reading that array through `arrayA` will show the changes
```csharp
$ 6, 6
```

### Array code example 2
```csharp
var arrayC = new[] { 4, 2 };
var arrayD = arrayC;
arrayD = new[] { 4, 2 };
arrayD[0] = 6;
arrayD[1] = 6;
Console.WriteLine(string.Join(", ", arrayC));
```

### Array code example 2 output

- first we create an array and point `arrayC` towards it
- then we point `arrayD` towards the same array
- then we point `arrayD` to another array
- then we modify the other array through `arrayD`
- thus, reading the first array through `arrayC` will show no changes
```csharp
$ 4, 2
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


## Functions/Methods

- **accessors**: defines how function can be accessed
- **return type**: type returned by the function
- **name**: name of the function
- **parameters**: parameters injected into function
- Convention: `camelCase` with first character `UPPERCASE`

### Local Function

- no accessors

```csharp
int Sum(int a, int b) {
	return a + b;
}

var sum = Sum(2, 4);
Console.WriteLine(sum);
```

### Static Method
```csharp
class Program {
	static int Sum(int a, int b) {
		return a + b;
	}

	public static void Main(string[] args) {
		var sum = Program.Sum(2, 4);
		Console.WriteLine(sum);
	}
}
```

### Without Return Value and no Parameters

```csharp
class Program {
	static void Print100() {
		Console.WriteLine(100);
	}

	public static void Main() {
		Program.Print100();  // prints 100
	}
}
```

### Without Return Value and with Parameters

```csharp
class Program {
	static void Print(string value, bool uppercase) {
		if (uppercase) {
			value = value.ToUpper();
		}
		Console.WriteLine(value);
	}

	public static void Main() {
		Program.Print("hello", true);  // prints HELLO
	}
}
```

### With Return Value and no Parameters

```csharp
class Program {
	static int GetPerfectNumber() {
		return 42;
	}

	public static void Main() {
		Console.WriteLine(Program.GetPerfectNumber());  // prints 42
	}
}
```

### With Return Value and with Parameters

```csharp
class Program {
	static int Sum(int a, int b) {
		return a + b;
	}

	public static void Main() {
		Console.WriteLine(Program.Sum(1, 2));  // prints 3
	}
}
```

### Default Parameters

```csharp
class Program {
	static void Print(int[] values, bool delim = ", ") {
		Console.WriteLine(string.Join(delim, values));
	}

	public static void Main() {
		var array = new[] { 1, 2, 3 };
		Program.Print(array);       // prints 1, 2, 3
		Program.Print(array, "|");  // prints 1|2|3
	}
}
```

### Overloading

- only with Methods in class, not possible with local functions

```csharp
class Program {
	static int Sum(int a, int b, int c) {
		return a + b + c;
	}

	static int Sum(int a, int b) {
		return a + b;
	}

	public static void Main() {
		Console.WriteLine(Sum(1, 2, 4));
		Console.WriteLine(Sum(4, 2));
	}
}
```

### Params keyword

```csharp
class Program {
	static int Sum(params int[] numbers) {
		var sum = 0;
		foreach (var number in numbers) {
			sum += number;
		}
		return sum;
	}

	public static void Main() {
		var array = new[] { 2, 9, 3 };
		Console.WriteLine(Sum(array));  // prints 14
		Console.WriteLine(Sum(2, 3, 1, 3));  // prints 9
		Console.WriteLine(Sum(4, 2));  // prints 6
	}
}
```

### Out keyword

```csharp
class Program {
	static bool Div(float a, float b, out float result) {
		if (b == 0) {
			result = float.NaN;
			return false;
		}
		result = a / b;
		return true;
	}

	public static void Main() {
		var success = Program.Div(10, 0, out float result);
		var msg = success ? $"result: {result}" : "null division error";
		Console.WriteLine(msg);
	}
}
```

### Ref keyword

```csharp
class Program {
	static void Swap(ref int a, ref int b) {
		if (a == b) {
			return;
		}
		var tmp = a;
		a = b;
		b = tmp;
	}
	public static void Main() {
		var first = 1;
		var second = 2;

		Program.Swap(ref first, ref second);
		Console.WriteLine($"{first}, {second}");  // prints 2, 1
	}
}
```

### Generic functions

```csharp
class Program {
	static void Print<T>(T value, int times) {
		for (int i = 0; i < times; ++i) {
			Console.Write($"{value} ");
		}
		Console.WriteLine();
	}

	public static void Main() {
		Program.Print(2.2, 3);      // prints 2.2, 2.2, 2.2
		Program.Print(4, 2);        // prints 4 4
		Program.Print("hello", 3);  // prints hello hello hello
	}
}
```

### Extensions

- must be in a static class

```csharp
static class IntExtensions {
	public static bool IsIn(this int elem, int[] elems) {
		return elems.Contains(elem);
	}
}

class Program {
	public static void Main() {
		var item = 5;
		var items = new[] { 1, 2, 3, 4 };
		Console.WriteLine(item.IsIn(items));
		Console.WriteLine(IntExtensions.IsIn(item, items));
	}
}

```
