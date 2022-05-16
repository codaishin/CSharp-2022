var randoms = new Random();
var random = randoms.Next(0, 100);
var won = false;
var answers = new List<string>();
var input = "";
var couldParse = false;

Console.WriteLine("Guess a number between 0 and 100");

do {
	input = Console.ReadLine();
	answers.Add(input!);  // ! assumes that input is not null
	couldParse = int.TryParse(input, out int guess);

	if (couldParse is false) {
		Console.WriteLine("Not a number");
	} else if (guess < 0 || guess > 99) {
		Console.WriteLine("Outside of allowed range");
	} else if (guess == random) {
		Console.WriteLine("Correct, yeah");
		won = true;
	} else if (guess < random) {
		Console.WriteLine("Too low... LOL");
	} else if (guess > random) {
		Console.WriteLine("Too high... rofl");
	}
} while (won is false);

Console.WriteLine($"Your tries: {answers.Count}");
Console.Write($"Your guesses where: ");
foreach (var answer in answers) {
	Console.Write($"{answer} ");
}
Console.WriteLine();
