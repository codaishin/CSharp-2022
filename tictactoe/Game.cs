enum Player { None, One, Two }

class FieldAlreadySet : Exception { }
class InvalidInput : Exception { }

class Game {
	public static Player[,] NewBoard(uint size) {
		var board = new Player[size, size];
		for (int x = 0; x < size; ++x) {
			for (int y = 0; y < size; ++y) {
				board[x, y] = Player.None;
			}
		}
		return board;
	}

	public static string Render(Player[,] board) {
		var (sizeX, sizeY) = (board.GetLength(0), board.GetLength(1));

		string RenderPlayer(Player player) {
			return player switch {
				Player.One => "X",
				Player.Two => "O",
				_ => "_",
			};
		}

		IEnumerable<string> getLines() {
			var letter = 'A';
			var line = "  ";
			for (int x = 0; x < sizeX; ++x) {
				line += $" {x + 1}";
			}
			yield return line;

			for (int x = 0; x < sizeX; ++x) {
				line = $"{letter++}:";
				for (int y = 0; y < sizeY; ++y) {
					line += $" {RenderPlayer(board[x, y])}";
				}
				yield return line;
			}
		}

		return string.Join("\n", getLines());
	}

	public static Player[,] Update(
		Player[,] board,
		Player player,
		uint newX,
		uint newY
	) {
		Player GetFieldValue(uint x, uint y) {
			if ((x, y) != (newX, newY)) {
				return board[x, y];
			}
			if (board[x, y] == Player.None) {
				return player;
			}
			throw new FieldAlreadySet();
		}

		var (sizeX, sizeY) = (board.GetLength(0), board.GetLength(1));
		if (newX >= sizeX || newY >= sizeY) {
			throw new IndexOutOfRangeException();
		}

		var copy = new Player[sizeX, sizeY];
		for (uint x = 0; x < sizeX; ++x) {
			for (uint y = 0; y < sizeY; ++y) {
				copy[x, y] = GetFieldValue(x, y);
			}
		}
		return copy;
	}

	public static (uint, uint) Coords(string input) {
		input = input.ToUpper();
		var (x, y) = (input[0], input[1..]);

		uint yConverted;
		try {
			yConverted = Convert.ToUInt32(y);
		}
		catch (FormatException) {
			throw new InvalidInput();
		}

		if (x < 'A' || x > 'Z' || yConverted == 0) {
			throw new InvalidInput();
		}

		return ((uint)x - 'A', yConverted - 1);
	}

	private static bool VerticalLine(
		Player[,] board,
		Player player,
		int sizeX,
		int sizeY
	) {
		for (int x = 0; x < sizeX; ++x) {
			var line = new Player[sizeY];
			for (int y = 0; y < sizeY; ++y) {
				line[y] = board[x, y];
			}
			if (line.All(f => f == player)) {
				return true;
			}
		}
		return false;
	}

	private static bool HorizontalLine(
		Player[,] board,
		Player player,
		int sizeX,
		int sizeY
	) {
		for (int y = 0; y < sizeY; ++y) {
			var line = new Player[sizeX];
			for (int x = 0; x < sizeX; ++x) {
				line[x] = board[x, y];
			}
			if (line.All(f => f == player)) {
				return true;
			}
		}
		return false;
	}

	private static bool DiagonalLineForward(
		Player[,] board,
		Player player,
		int size
	) {
		var line = new Player[size];
		for (int i = 0; i < size; ++i) {
			line[i] = board[i, i];
		}
		if (line.All(f => f == player)) {
			return true;
		}
		return false;
	}

	private static bool DiagonalLineBackwards(
		Player[,] board,
		Player player,
		int size
	) {
		var line = new Player[size];
		for (int i = 0; i < size; ++i) {
			line[i] = board[i, size - i - 1];
		}
		if (line.All(f => f == player)) {
			return true;
		}
		return false;
	}

	public static bool HasLine(Player[,] board, Player player) {
		var (sizeX, sizeY) = (board.GetLength(0), board.GetLength(1));
		return (
			Game.HorizontalLine(board, player, sizeX, sizeY) ||
			Game.VerticalLine(board, player, sizeX, sizeY) ||
			Game.DiagonalLineForward(board, player, sizeX) ||
			Game.DiagonalLineBackwards(board, player, sizeX)
		);
	}

	public static bool AllFilled(Player[,] board) {
		foreach (var field in board) {
			if (field == Player.None) {
				return false;
			}
		}
		return true;
	}
}
