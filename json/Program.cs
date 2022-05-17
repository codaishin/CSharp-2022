using System.Text.Json;

record Question {
	public string Text { get; init; } = "";
	public string[] Answers { get; init; } = new string[0];
	public int CorrectAnswer { get; init; } = -1;
}

class Program {
	public static void Main() {
		var text = File.ReadAllText("data.json");
		var data = JsonSerializer.Deserialize<Question>(text)!;
		Console.WriteLine(data.Text);
		Console.WriteLine(string.Join(", ", data.Answers));
		Console.WriteLine(data.CorrectAnswer);
	}
}
