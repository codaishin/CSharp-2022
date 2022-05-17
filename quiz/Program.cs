class Program {

	struct Question {
		public string text;
		public string answerA;
		public string answerB;
		public string answerC;
		public string correctAnswer;
	}

	enum Status { CORRECT, INCORRECT, ERROR }

	static string ToString(Question question) {
		return $"{question.text}\na: {question.answerA}, b: {question.answerB}, c: {question.answerC}";
	}

	static string ToString(Question question, Status status) {
		switch (status) {
			case Status.CORRECT:
				return "Correct!";
			case Status.INCORRECT:
				return $"Wong! The correct answer is {question.correctAnswer}";
			default:
				return "Invalid Answer, Try again";
		}
	}

	static Status Evaluate(Question question, string input) {
		input = input.ToLower();
		if (input == question.correctAnswer.ToLower()) {
			return Status.CORRECT;
		}
		if (input == "a" || input == "b" || input == "c") {
			return Status.INCORRECT;
		}
		return Status.ERROR;
	}

	static bool ShouldRepeat(Status status) {
		return status == Status.ERROR;
	}


	static void Foo(string value) {

	}

	public static void Main() {

		Status status;
		var question = new Question {
			text = "What color is green grass?",
			answerA = "blue",
			answerB = "green",
			answerC = "pink",
			correctAnswer = "c",
		};

		Console.WriteLine(Program.ToString(question));

		do {
			var input = Console.ReadLine()!;
			status = Program.Evaluate(question, input);
			Console.WriteLine(Program.ToString(question, status));
		} while (Program.ShouldRepeat(status));
	}
}
