class Program {
	struct Question {
		public string text;
		public string[] answers;
		public int correctAnswer;
	}

	enum Status { CORRECT, INCORRECT, ERROR }

	static string Letter(int index) {
		return $"{(char)('a' + index)}";
	}

	static string[] AllLetters(Question question) {
		var letters = new string[question.answers.Length];
		for (int i = 0; i < question.answers.Length; ++i) {
			letters[i] = Program.Letter(i);
		};
		return letters;
	}

	static string ToString(Question question) {
		var answers = new string[question.answers.Length];
		for (int i = 0; i < question.answers.Length; ++i) {
			answers[i] = $"{Program.Letter(i)}: {question.answers[i]}";
		}

		return $"{question.text}\n{string.Join(", ", answers)}";
	}

	static string ToString(Question question, Status status) {
		return status switch {
			Status.CORRECT => "Correct!",
			Status.INCORRECT => string.Format(
				"Wong! The correct answer is {0}: {1}",
				Program.Letter(question.correctAnswer),
				question.answers[question.correctAnswer]
			),
			_ => "Invalid Answer, Try again",
		};
	}

	static Status Evaluate(Question question, string input) {
		input = input.ToLower();
		if (input == Program.Letter(question.correctAnswer)) {
			return Status.CORRECT;
		}
		if (Program.AllLetters(question).Contains(input)) {
			return Status.INCORRECT;
		}
		return Status.ERROR;
	}

	static bool ShouldRepeat(Status status) {
		return status == Status.ERROR;
	}

	public static void Main() {

		Status status;
		var question = new Question {
			text = "What color is green grass?",
			answers = new[] { "blue", "green", "pink" },
			correctAnswer = 2
		};

		Console.WriteLine(Program.ToString(question));

		do {
			var input = Console.ReadLine()!;
			status = Program.Evaluate(question, input);
			Console.WriteLine(Program.ToString(question, status));
		} while (Program.ShouldRepeat(status));
	}
}
