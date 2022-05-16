var seed = new Random();

var random = seed.Next(0, 100);

Console.WriteLine("Guess a number between 0 and 100");

var tryCount = 0;
var repeat = true;
var answers = new List<string>();

do
{
	var parse = 0;
	var input = Console.ReadLine();
	answers.Add(input!);  // ! assumes that input is not null

	if (int.TryParse(input, out parse) == false)
	{
		Console.WriteLine("Not a number");
		repeat = true;
	}
	else if (parse < 0 || parse > 99)
	{
		Console.WriteLine("Outside of allowed range");
		repeat = true;
	}
	else if (parse == random)
	{
		Console.WriteLine("Correct, yeah");
		repeat = false;
	}
	else if (parse < random)
	{
		Console.WriteLine("Too low... LOL");
		repeat = true;
	}
	else if (parse > random)
	{
		Console.WriteLine("Too high... rofl");
		repeat = true;
	}
	++tryCount;
} while (repeat);

Console.WriteLine($"Your tries: {tryCount}");
Console.Write($"Your guesses where: ");
foreach (var answer in answers)
{
	Console.Write($"{answer} ");
}
Console.WriteLine();
