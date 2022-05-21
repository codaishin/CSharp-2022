# C#

## Content

- [Simple Console App](#simple-console-app)
- [Variables and Types](#variables-and-types)
- [Value vs. Reference Type](#value-vs-reference-type)
- [Nullables](#nullables)
- [Loops](#loops)
- [Branching](#branching)
- [Functions/Methods](#functionsmethods)
- [Lambda Functions](#lambda-functions)
- [File IO](#file-io)
- [Error Handling](#error-handling)
- [Namespaces](#namespaces);
- [Generators](#generators);
- [Memory Management](#memory-management);
- [Components/Dlls](#componentsdlls);
- [OOP](#oop);

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

[back to top](#content)

## Variables and Types

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

### Builtin types

- [-> numerical types](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types)
- [-> char](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/char)
- [-> bool](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)
- [-> struct](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct)
- [-> tuple](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples)

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
public record Person {
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

		Console.WriteLine(value);       // prints B
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

[back to top](#content)

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

[back to top](#content)

## Nullables

### Must be enabled

- with `dotnet new console` per default enabled

```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
		...
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

### Value can be null or the Given Type

```csharp
var value = "my value";      // implicitly string?
var value = null as string;  // implicitly string?
string? value = "my value";
string? value = null;
```

### Useful to communicate functions success

```csharp
class Program {
	public static void Main() {
		var subscribers = GetValueFromApi("https://example.com/subscribers");
		if (subscribers is null) {
			Console.WriteLine("Failed to read subscribers");
			return;
		}
		...
	}
}
```

### Nullability can be ignored with `!`

```csharp
class Program {
	public static void Main() {
		var subscribers = GetValueFromApi("https://example.com/subscribers");
		foreach (var subscriber in subscribers!) {
			...
		}
	}
}
```

### Nullability: Value Type vs Reference Type

#### Value Type
```csharp
int? count = GetValueFromApi("https://example.com/subscribers/count");
if (count.HasValue) {  // count is not null; count != null
	Console.WriteLine(count.Value);
}
```

#### Reference Type
```csharp
Subscriber[]? subscribers = GetValueFromApi("https://example.com/subscribers");
if (subscribers is not null) {   // subscribers != null
	Console.WriteLine(string.Join(", ", subscribers));
}
```

[back to top](#content)

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

[back to top](#content)

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

[back to top](#content)

## Functions/Methods

- **accessors**: defines how function can be accessed
- **return type**: type returned by the function
- **name**: name of the function
- **parameters**: parameters injected into function
- Convention: `camelCase` with first character `UPPERCASE`

### Accessors

- **no static**: Can only be run on an instance (special meaning for local methods)
- **static**: Can only be run on the type (special meaning for local methods)
- **public**: Can be run from anywhere
- **private**: Can only be run from within the same type or an instance of that type

See examples in [Usage - Wrong access](#usage---wrong-access)

### Local Method

- no static
- can access containing scope

```csharp
var text = "Hello, World";

void localFunc() {
	Console.WriteLine(text);
}

localFunc();
```

### Local Static Method

- with static
- isolated from containing scope

```csharp
static int Sum(int a, int b) {
	return a + b;
}

var sum = Sum(2, 4);
Console.WriteLine(sum);
```

### Static Method in Class
```csharp
class Program {
	static int Sum(int a, int b) {
		return a + b;
	}

	static void Main(string[] args) {
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

	static void Main() {
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

	static void Main() {
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

	static void Main() {
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

	static void Main() {
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

	static void Main() {
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

	static void Main() {
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

	static void Main() {
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

	static void Main() {
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
	static void Main() {
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

	static void Main() {
		Program.Print(2.2, 3);      // prints 2.2, 2.2, 2.2
		Program.Print(4, 2);        // prints 4 4
		Program.Print("hello", 3);  // prints hello hello hello
	}
}
```

### Extensions

- must be in a static class
- method must be public

```csharp
static class IntExtensions {
	public static bool IsIn(this int elem, int[] elems) {
		return elems.Contains(elem);
	}
}

class Program {
	static void Main() {
		var item = 5;
		var items = new[] { 1, 2, 3, 4 };
		Console.WriteLine(item.IsIn(items));
		Console.WriteLine(IntExtensions.IsIn(item, items));
	}
}
```

[back to top](#content)

## Lambda Functions

### Lambda Function - Func

- returns non-void

```csharp
Func<int, float, bool> areEqual = (a, b) => a == b;

Console.WriteLine(areEqual(2, 2.0f));
```

```csharp
var areEqual = (int a, float b) => a == b;

Console.WriteLine(areEqual(2, 2.0f));
```

### Lambda Function - Action

- return void

```csharp
Action<int, float> print = (a, b) => Console.WriteLine($"{a}, {b}");

print(2, 2.0f);
```

```csharp
var print = (int a, float b) => Console.WriteLine($"{a}, {b}");

print(2, 2.0f);
```

### Lambda Function - Multiline

```csharp
var sum = (int a, int b) => {
	var result = a + b;
	return result;
};

Console.WriteLine(sum(4, 1));
```

### Methods with Lambda Syntax

```csharp
static int Sum(int a, int b) => a + b;

Console.WriteLine(Sum(2, 3));
```

[back to top](#content)

## File IO

### Read File

```csharp
var lines = File.ReadAllLines("text.txt");
foreach (var line in lines) {
	Console.WriteLine(line);
}
```
```csharp
using var file = File.Open("text.txt", FileMode.Open);
using var read = new StreamReader(file);

string? line;
while ((line = read.ReadLine()) is not null) {
	Console.WriteLine(line);
}
```

### Write File

```csharp
var lines = new string[] { "line a", "line a" };
File.AppendAllLines("text.txt", lines);
```
```csharp
using var file = File.Open("text.txt", FileMode.Append);
using var write = new StreamWriter(file);

write.WriteLine("line a");
write.WriteLine("line b");
```

### Json Example File

data.json
```json
[
	{
		"Name": "Harry",
		"Age": 11
	},
	{
		"Name": "Rudi",
		"Age": 44
	}
]
```

### Read Json Example File

```csharp
using System.Text.Json;

record Person {
	public string Name { get; init; } = "";
	public int Age { get; init; } = 0;
}

class Program {
	public static void Main() {
		var text = File.ReadAllText("data.json");
		var persons = JsonSerializer.Deserialize<Person[]>(text)!;
		foreach (var person in persons) {
			Console.WriteLine(person);
		}
	}
}
```

[back to top](#content)

## Error Handling

### Try catch finally

```csharp
try {
	var value = 10 / 0;
	Console.WriteLine(value);
} catch (DivideByZeroException) {  // catch division error
	Console.WriteLine("Cannot divide by zero");
} catch (IOException error) {      // catch IO error
	MyServer.Log(error.Message);
} finally {                        // always happens
	Console.WriteLine("We are done");
}
```

### Throw own error

```csharp
class MyException : Exception {
	public MyException(string msg) : base(msg) { }
}

class Program {
	static string MySecretHashFunc(int source) {
		if (source < 0) {
			throw new MyException("source must no be negative");
		}
		...
	}

	...
}
```

[back to top](#content)

## Namespaces

### Group Code

#### Foo.cs
```csharp
namespace MyNamespace {
	struct MyFoo {
		...
	}
}
```

#### Bar.cs
```csharp
namespace MyNamespace {
	namespace MyNestedNamespace {
		struct MyBar {
			...
		}
	}
}
```

### Individual namespace access

```csharp
var bar = new MyNamespace.MyFoo{ ... };
var foo = new MyNamespace.MyNestedNamespace.MyBar{ ... };
```

### Local using statement

```csharp
using MyNamespace;

var bar = new MyFoo{ ... };
var foo = new MyNamespace.MyNestedNamespace.MyBar{ ... };
```

```csharp
using MyNamespace;
using MyNamespace.MyNestedNamespace;

var bar = new MyFoo{ ... };
var foo = new MyBar{ ... };
```

### Global using statement

#### MyFileA.cs
```csharp
global using MyNamespace;
global using MyNamespace.MyNestedNamespace;
```

#### MyFileB.cs
```csharp
var bar = new MyFoo{ ... };
var foo = new MyBar{ ... };
```

[back to top](#content)

## Generators

- allows iteration at least once
- enable lazy iteration

### IEnumerable

```csharp
IEnumerable<int> Elements() {
	yield return 1;
	yield return 2;
	yield return 3;
}

var elements = Elements();
foreach (var element in elements) {
	Console.WriteLine(element);
}
```

### IEnumerator

```csharp
IEnumerator<int> Elements() {
	yield return 1;
	yield return 2;
	yield return 3;
}

var enumerator = Elements();
while (enumerator.MoveNext()) {
	Console.WriteLine(enumerator.Current);
}
```

### No Generator Eager - Example

```csharp
int[] Elements() {
	var elements = new int[3];
	Console.WriteLine("add 1");
	elements[0] = 1;
	Console.WriteLine("add 2");
	elements[1] = 2;
	Console.WriteLine("add 3");
	elements[2] = 3;
	return elements;
}

var elements = Elements();
Console.WriteLine("after call before loop");
foreach (var element in elements) {
	Console.WriteLine($"read {element}");
}
```

### No Generator Eager - Output

```console
add 1
add 2
add 3
after call before loop
read 1
read 2
read 3
```

### Generator Lazy - Example

```csharp
IEnumerable<int> Elements() {
	Console.WriteLine("yield 1");
	yield return 1;
	Console.WriteLine("yield 2");
	yield return 2;
	Console.WriteLine("yield 3");
	yield return 3;
}

var elements = Elements();
Console.WriteLine("after call before loop");
foreach (var element in elements) {
	Console.WriteLine($"read {element}");
}

```

### Lazy - Example - Output

```console
after call before loop
yield 1
read 1
yield 2
read 2
yield 3
read 3
```


[back to top](#content)

## Memory Management

### Garbage Collection

- Garbage Collection (GC) handles memory
- Stops program execution at its onw convenience to check and free memory
- GC can be invoked manually (which is rarely actually useful)

### Unsafe

- unsafe code can be used for manual memory management

```csharp
using System.Runtime.InteropServices;

unsafe {
	var array = (int*)NativeMemory.Alloc(sizeof(int) * 5);
	for (var i = 0; i < 5; ++i) {
		array[i] = i;
	}
	for (var i = 0; i < 5; ++i) {
		Console.WriteLine(array[i]);
	}
	NativeMemory.Free(array);
}
```

[back to top](#content)

## Components/Dlls

- A **ddl** is a shared library that can be used by many client programs

### Build

#### In bin\Debug\net6.0 (assumes .Net 6)
```console
dotnet build
```

#### In bin\Release\net6.0 (assumes .Net 6)
```console
dotnet build --configuration Release
```

### Usage - manual

- add to `.csproj` file

```
<ItemGroup>
	<Reference Include="MyNamespace">
		<HintPath>/path/to/MyNamespace.dll</HintPath>
	</Reference>
</ItemGroup>
```

### Usage - package manager

- example for NUnit dlls
- will install the dlls, if not already installed
- will modify `.csproj` with `<PackageReference>` entries

```
$ dotnet add package Microsoft.NET.Test.Sdk
$ dotnet add package NUnit
$ dotnet add package Nunit3TestAdapter
```

[back to top](#content)

## OOP

### Definition - Properties

```csharp
class Circle {
	private double radius;

	public double Radius {
		get => this.radius;
		set => this.radius = value;
	}

	public double Diameter {
		get => this.radius * 2;
		set => this.radius = value / 2;
	}

	...
}
```

### Definition - Methods

```csharp
class Circle {
	...

	public double Area() {
		return Math.PI * Math.Pow(this.radius, 2);
	}

	public override string ToString() {
		return $"Circle: radius = {this.radius}";
	}

	public static Circle Merge(Circle a, Circle b) {
		return new Circle { Radius = a.radius + b.radius };
	}
}
```

### Usage

```csharp
var circleA = new Circle { Radius = 4 };
var circleB = new Circle { Radius = 3 };
Console.WriteLine(circleA);
Console.WriteLine(circleA.Area());
Console.WriteLine(Circle.Merge(circleA, circleB));
```

### Usage - Wrong access

#### Can't access `private` variable

```csharp
Console.WriteLine(circleA.radius);  // will not compile
```

#### Can't access `static` Method on an instance

```csharp
Console.WriteLine(circleA.Merge(circleA, circleB));  // will not compile
```

#### Can't access `non static` Method on the type

```csharp
Console.WriteLine(Circle.Area());  // will not compile
```

### Interface - Definition

```csharp
interface IShape2D {
	double Area();
}

class Circle : IShape2D {
	...
}

class Square : IShape2D {
	...
}
```

### Interface - Usage

```csharp
static double SumAreas(IEnumerable<IShape2D> shapes) {
	return shapes.Select(s => s.Area()).Sum();
}

var shapes = new IShape2D[] {
	new Circle { Radius = 10 },
	new Square { Side = 4 },
};
Console.WriteLine(SumAreas(shapes));
```

[back to top](#content)
