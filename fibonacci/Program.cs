var first = 1;
var second = 1;
var third = 0;
var pattern = "{0} ";

Console.Write(pattern, first);
Console.Write(pattern, second);

for (int i = 2; i < 20; ++i) {
	third = first + second;
	Console.Write(pattern, third);
	first = second;
	second = third;
}
