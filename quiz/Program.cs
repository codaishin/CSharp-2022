Console.WriteLine("What color is green grass?");
Console.WriteLine("a: blue, b: green, c: yellow, d: pink");

var repeat = true;

do {
	var input = Console.ReadLine();
	switch (input) {
		case "a":
		case "c":
		case "d":
			Console.WriteLine("Wrong. (really? you got that wrong?)");
			Console.WriteLine("The correct answer is: green");
			repeat = false;
			break;
		case "b":
			Console.WriteLine("Correct, u rock");
			repeat = false;
			break;
		default:
			Console.WriteLine("Choose a valid answer... (what a fool)");
			break;
	}
} while (repeat);
