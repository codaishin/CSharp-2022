var value = "aikiokiiikalii";
var count = value.Count(c => c == 'i');
Console.WriteLine($"count: {count}");

var numbers = new[] { 1, 2, 3, 4 };
var filtered = numbers.Where(n => n % 2 == 0);

foreach (var number in filtered) {
	Console.WriteLine(number);
}
