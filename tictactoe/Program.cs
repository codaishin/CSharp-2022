var player = Player.One;
var board = Game.NewBoard(3);
var newBoard = null as Player[,];
var (hasLine, filled) = (false, false);
var prefix = "";

do {
	(board, player, prefix, hasLine, filled) = RenderFrame(board, player, prefix);
} while (hasLine is false && filled is false);

EndScreen(board, player, hasLine, filled);

static void EndScreen(
	Player[,] board,
	Player player,
	bool hasLine,
	bool filled
) {
	Console.Clear();
	Console.WriteLine(Game.Render(board));
	if (hasLine) {
		Console.WriteLine($"Player {player} is victorious");
	}
	if (filled) {
		Console.WriteLine($"No one is victorious");
	}
}

static (Player[,], Player, string, bool, bool) RenderFrame(
	Player[,] board,
	Player player,
	string prefix
) {
	var (x, y) = (0u, 0u);
	var newBoard = null as Player[,];

	Render(board, player, prefix);
	try {
		(x, y) = Game.Coords(Console.ReadLine()!);
		newBoard = Game.Update(board, player, x, y);
	}
	catch (Exception error) {
		return (board, player, Error(error), false, false);
	}
	var hasLine = Game.HasLine(newBoard, player);
	var filled = Game.AllFilled(newBoard);
	return (newBoard, NextPlayer(player, hasLine), "", hasLine, filled);
}

static Player NextPlayer(Player player, bool hasLine) {
	if (hasLine is false) {
		return player == Player.One ? Player.Two : Player.One;
	}
	return player;
}

static void Render(Player[,] board, Player player, string prefix) {
	Console.Clear();
	Console.WriteLine(Game.Render(board));
	Console.Write($"{prefix}Move Player {player}: ");
}

static string Error(Exception error) {
	if (error is IndexOutOfRangeException) {
		return "Out of range, try again!\n";
	}
	if (error is InvalidInput) {
		return "Invalid, try again!\n";
	}
	if (error is FieldAlreadySet) {
		return "Out of range, try again!\n";
	}
	return "";
}
