<Query Kind="Program" />

void Main()
{
	var tictactoe = new TicTacToe(3);
	tictactoe.Move(1, 2, 2).Dump();
	tictactoe.Move(0, 2, 1).Dump();
	tictactoe.Move(0, 0, 2).Dump();
	tictactoe.Move(2, 0, 1).Dump();
	tictactoe.Move(0, 1, 2).Dump();
	tictactoe.Move(1, 1, 1).Dump();
	

	tictactoe.board.Dump();
}

public class TicTacToe
{
	public char[,] board;
	private int length;
	private int count;
	public TicTacToe(int n)
	{
		board = new char[n, n];
		length = n;
	}

	/** Player {player} makes a move at ({row}, {col}).
        @param row The row of the board.
        @param col The column of the board.
        @param player The player, can be either 1 or 2.
        @return The current winning condition, can be either:
                0: No one wins.
                1: Player 1 wins.
                2: Player 2 wins. */
	public int Move(int row, int col, int player)
	{
		var palyerchar = player == 1 ? 'X' : 'O';

		board[row, col] = palyerchar;
		count = 0;
		
		if (CheckRow(row, col, palyerchar, true))
		{
			return player;
		}

		if (CheckColumn(row, col, palyerchar, true))
		{
			return player;
		}

		if (row == col)
		{
			if(CheckDiagonal1(row, col, palyerchar, true))
				return player;

			if (CheckDiagonal2(row, col, palyerchar, true) && count == length)
				return player;
		}
		else 
		{
			if (CheckDiagonal2(row, col, palyerchar, true) && count == length)
				return player;
		}
		
		return 0;
	}


	public bool CheckRow(int row, int col, char player, bool positive)
	{
		if (row > length - 1 || row < 0)
		{
			return true;
		}

		if (board[row, col] != player)
		{
			return false;
		}

		if (positive)
		{
			var forward = CheckRow(row + 1, col, player, positive);

			if (!forward)
			{
				return false;
			}
		}

		positive = false;

		var backward = CheckRow(row - 1, col, player, positive);

		return backward;
	}

	public bool CheckColumn(int row, int col, char player, bool positive)
	{
		if (col < 0 || col > length - 1)
		{
			return true;
		}

		if (board[row, col] != player)
		{
			return false;
		}
		

		if (positive)
		{
			var forward = CheckColumn(row, col + 1, player, positive);

			if (!forward)
			{
				return false;
			}
		}

		positive = false;

		var backward = CheckColumn(row, col - 1, player, positive);

		return backward;
	}

	public bool CheckDiagonal1(int row, int col, char player, bool positive)
	{
		if (row > length - 1 || row < 0 || col < 0 || col > length - 1)
		{
			return true;
		}

		if (board[row, col] != player)
		{
			return false;
		}

		if (positive)
		{
			var forward = CheckDiagonal1(row + 1, col + 1, player, positive);

			if (!forward)
			{
				return false;
			}

		}

		positive = false;

		var backward = CheckDiagonal1(row - 1, col - 1, player, positive);

		return backward;

	}

	public bool CheckDiagonal2(int row, int col, char player, bool positive)
	{
		if (row > length - 1 || row < 0 || col < 0 || col > length - 1 || board[row, col] == '0')
		{
			return true;
		}

		if (board[row, col] != player)
		{
			return false;
		}
		else
		{
			board[row, col] = '0';
			count++;
		}

		if (positive)
		{
			var forward = CheckDiagonal2(row + 1, col - 1, player, positive);

			if (!forward)
			{
				board[row, col] = player;
				return false;
			}
		}

		positive = false;
		var backward = CheckDiagonal2(row - 1, col + 1, player, positive);
		
		board[row, col] = player;
		return backward;
	}
}

