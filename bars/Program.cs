class Program {

	static int[]? ToInts(string[] values) {
		var ints = new int[values.Length];
		for (var c = 0; c < values.Length; c++) {
			var success = int.TryParse(values[c], out int converted);
			if (!success || converted < 0) {
				return null;
			};
			ints[c] = converted;
		}
		return ints;
	}

	static string[] ToBars(int[] barSizes) {
		string[] bars = new string[barSizes.Length];
		for (var c = 0; c < barSizes.Length; c++) {
			bars[c] = new String('|', barSizes[c]);
		}
		return bars;
	}

	static void Print(string[] values) {
		foreach (var element in values) {
			Console.WriteLine(element);
		}
	}

	static int ToInt(string value) {
		return Int32.Parse(value);
	}

	static string ToBar(int value) {
		string bar = "";
		for (var c = 0; c < value; c++) {
			bar += "|";
		}
		return bar;
	}

	public static void Main() {
		Console.WriteLine("Write numbers to turn to bars");
		var input = Console.ReadLine()!;
		var numbers = input.Split(" ");

		var intNumbers = Program.ToInts(numbers);
		if (intNumbers is null) {
			Console.WriteLine("only positive numbers allowed");
			return;
		}
		var bars = Program.ToBars(intNumbers);
		Program.Print(bars);

		// foreach (var number in numbers) {
		// 	var intNumber = Program.ToInt(number);
		// 	var bar = Program.ToBar(intNumber);
		// 	Console.WriteLine(bar);
		// }

		// foreach (var elem in numbers) {
		// 	var count = Convert.ToInt32(elem);
		// 	var bar = new String('|', count);
		// 	Console.WriteLine(bar);
		// }
	}
}
