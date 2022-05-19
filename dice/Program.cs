Console.WriteLine("gimme some dice");

var random = new Random();
var input = Console.ReadLine()!;
var dice = null as DiceGroup[];
try {
	dice = ToDiceGroups(input.Split(" "));
}
catch (Exception error) {
	if (IsExpectedError(error)) {
		Console.WriteLine("use input like: 2d4");
		return;
	}
	throw error;
}
var results = Roll(dice, random);
var sum = Sum(results);

Print(results);
Console.WriteLine(sum);

static bool IsExpectedError(Exception error) {
	return
		error is IndexOutOfRangeException ||
		error is FormatException ||
		error is ArgumentException;
}

static DiceGroup[] ToDiceGroups(string[] groups) {
	var diceGroups = new DiceGroup[groups.Length];
	for (var i = 0; i < groups.Length; ++i) {
		diceGroups[i] = ToDiceGroup(groups[i]);
	}
	return diceGroups;
}

static DiceGroup ToDiceGroup(string group) {
	var diceData = group.Split("d");
	var count = Convert.ToInt32(diceData[0]);
	var sides = Convert.ToInt32(diceData[1]);
	if (diceData.Length > 2 || count < 1 || sides < 1) {
		throw new ArgumentException();
	}
	return new DiceGroup { count = count, sides = sides };
}

static List<List<int>> Roll(DiceGroup[] dice, Random random) {
	var allRolls = new List<List<int>>();
	foreach (var diceGroup in dice) {
		int i = 0;
		var rolls = new List<int>();
		while (i < diceGroup.count) {
			rolls.Add(random.Next(1, diceGroup.sides + 1));
			++i;
		}
		allRolls.Add(rolls);
	}
	return allRolls;
}

static int Sum(List<List<int>> rolls) {
	int sum = 0;
	foreach (var group in rolls) {
		foreach (var roll in group) {
			sum += roll;
		}
	}
	return sum;
}

static void Print(List<List<int>> rolls) {
	foreach (var group in rolls) {
		Console.Write($"[{string.Join(", ", group)}] ");
	}
	Console.WriteLine();
}
