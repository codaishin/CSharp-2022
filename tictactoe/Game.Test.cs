using NUnit.Framework;

class TestTools {
	public static IEnumerable<Player> Flatten(Player[,] board) {
		foreach (var field in board) {
			yield return field;
		}
	}
}

class TestNewBoard {
	static bool IsPlayerNone(Player field) {
		return field == Player.None;
	}



	[Test]
	public void SizeOne() {
		var board = Game.NewBoard(1);
		Assert.AreEqual(1, board.Length);

		var fields = TestTools.Flatten(board);
		Assert.True(fields.All(TestNewBoard.IsPlayerNone));
	}

	[Test]
	public void SizeThree() {
		var board = Game.NewBoard(3);
		Assert.AreEqual(3, board.GetLength(0));
		Assert.AreEqual(3, board.GetLength(1));

		var fields = TestTools.Flatten(board);
		Assert.True(fields.All(TestNewBoard.IsPlayerNone));
	}
}

class TestRenderBoard {
	[Test]
	public void RenderOneTimesOneNone() {
		var board = new Player[,] {
			{ Player.None }
		};

		var rendered = Game.Render(board);
		var expected = (
			"   1\n" +
			"A: _"
		);
		Assert.AreEqual(expected, rendered);
	}

	[Test]
	public void RenderOneTimesOnePlayerOne() {
		var board = new Player[,] {
			{ Player.One }
		};

		var rendered = Game.Render(board);
		var expected = (
			"   1\n" +
			"A: X"
		);
		Assert.AreEqual(expected, rendered);
	}

	[Test]
	public void RenderOneTimesOnePlayerTwo() {
		var board = new Player[,] {
			{ Player.Two }
		};

		var rendered = Game.Render(board);
		var expected = (
			"   1\n" +
			"A: O"
		);
		Assert.AreEqual(expected, rendered);
	}

	[Test]
	public void RenderThreeTimesThree() {
		var board = new Player[,] {
			{ Player.Two, Player.One, Player.None },
			{ Player.One, Player.None, Player.None },
			{ Player.None, Player.None, Player.Two },
		};

		var rendered = Game.Render(board);
		var expected = (
			"   1 2 3\n" +
			"A: O X _\n" +
			"B: X _ _\n" +
			"C: _ _ O"
		);
		Assert.AreEqual(expected, rendered);
	}
}

class TestUpdate {
	[Test]
	public void NewBoardNotTheSame() {
		var board = new Player[,] {
			{ Player.None },
		};
		Assert.AreNotSame(board, Game.Update(board, Player.One, 0, 0));
	}

	[Test]
	public void UpdatePlayerOne() {
		var board = new Player[,] {
			{ Player.None, Player.None, Player.None, },
			{ Player.None, Player.None, Player.None, },
			{ Player.None, Player.None, Player.None, },
		};
		board = Game.Update(board, Player.One, 1, 2);

		CollectionAssert.AreEqual(
			new Player[] {
				Player.None, Player.None,Player.None,
				Player.None, Player.None,Player.One,
				Player.None, Player.None,Player.None,
			},
			TestTools.Flatten(board)
		);
	}

	[Test]
	public void UpdateInvalidCoords() {
		var board = new Player[,] {
			{ Player.None},
		};
		Assert.Throws<IndexOutOfRangeException>(
			() => Game.Update(board, Player.One, 1, 1)
		);
	}

	[Test]
	public void UpdateFieldAlreadySet() {
		var board = new Player[,] {
			{ Player.One },
		};

		Assert.Throws<FieldAlreadySet>(
			() => Game.Update(board, Player.One, 0, 0)
		);
	}
}

class TestCoords {
	[Test]
	public void GetCoords() {
		Assert.AreEqual((1, 5), Game.Coords("B6"));
	}

	[Test]
	public void GetCoordsR87() {
		Assert.AreEqual((2, 86), Game.Coords("C87"));
	}

	[Test]
	public void GetInvalidInput6B() {
		Assert.Throws<InvalidInput>(() => Game.Coords("6B"));
	}

	[Test]
	public void GetInvalidInputZ0() {
		Assert.Throws<InvalidInput>(() => Game.Coords("Z0"));
	}
}

class TestHasLine {
	[Test]
	public void NoLine() {
		var board = new[,] {
			{ Player.One, Player.None, Player.None },
			{ Player.Two, Player.One, Player.None },
			{ Player.None, Player.None, Player.Two },
		};

		Assert.False(Game.HasLine(board, Player.One));
	}

	[Test]
	public void LineVertical() {
		var board = new[,] {
			{ Player.One, Player.One, Player.One },
			{ Player.Two, Player.One, Player.None },
			{ Player.None, Player.None, Player.Two },
		};

		Assert.True(Game.HasLine(board, Player.One));
	}

	[Test]
	public void LineHorizontal() {
		var board = new[,] {
			{ Player.Two, Player.One, Player.One },
			{ Player.Two, Player.One, Player.None },
			{ Player.Two, Player.None, Player.Two },
		};

		Assert.True(Game.HasLine(board, Player.Two));
	}


	[Test]
	public void LineVerticalForward() {
		var board = new[,] {
			{ Player.Two, Player.None, Player.None },
			{ Player.None, Player.Two, Player.None },
			{ Player.None, Player.None, Player.Two },
		};

		Assert.True(Game.HasLine(board, Player.Two));
	}

	[Test]
	public void LineVerticalBackwards() {
		var board = new[,] {
			{ Player.None, Player.One, Player.One },
			{ Player.One, Player.One, Player.None },
			{ Player.One, Player.None, Player.Two },
		};

		Assert.True(Game.HasLine(board, Player.One));
	}
}

class TestFilled {
	[Test]
	public void False() {
		var board = new Player[,] {
			{ Player.None, Player.Two },
			{ Player.Two, Player.One },
		};
		Assert.False(Game.AllFilled(board));
	}

	[Test]
	public void True() {
		var board = new Player[,] {
			{ Player.Two, Player.Two },
			{ Player.Two, Player.One },
		};
		Assert.True(Game.AllFilled(board));
	}
}
