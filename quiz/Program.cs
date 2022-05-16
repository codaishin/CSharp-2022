Console.WriteLine("Welche Farbe hat grünes Grassssss?");
Console.WriteLine("a: blua, b: grün, c: gelb, d: pink");

var repeat = true;

do
{
	var input = Console.ReadLine();
	switch (input)
	{
		case "a":
		case "c":
		case "d":
			Console.WriteLine("Falsch, u fool");
			repeat = false;
			break;
		case "b":
			Console.WriteLine("Richtig, u rock");
			repeat = false;
			break;
		default:
			Console.WriteLine("U SUCK, U CAN DO NOTHING RIGHT!!!!");
			break;
	}
} while (repeat);
