<Query Kind="Program" />

void Main()
{
	
}

public abstract class Piece
{
	public bool IsKilled { get; set; }
	public bool IsWhite { get; set; }
	
	public Piece(bool isWhite)
	{
		this.IsWhite = isWhite;
	}
	
	public abstract bool CanMove(int[][] board, Box x, Box y);
}

public class King : Piece
{
	public King(bool isWhite): base(isWhite)
	{
		
	}
	
	public override bool CanMove(int[][] board, Box x, Box y)
	{
		if(y.Piece.IsWhite == this.IsWhite)
		{
			return false;
		}

		var xMove = Math.Abs(x.X - y.X);
		var yMove = Math.Abs(x.Y - y.Y);
		
		if(xMove + yMove == 1 && y.Piece == null)
		{
			return true;
		}

		if (xMove + yMove == 2 && y.Piece.IsWhite != IsWhite)
		{
			return true;
		}

		return false;
	}
}

public class Queen : Piece
{
	public Queen(bool isWhite) : base(isWhite)
	{

	}

	public override bool CanMove(int[][] board, Box x, Box y)
	{
		throw new NotImplementedException();
	}
}

public class Rook : Piece
{
	public Rook(bool isWhite) : base(isWhite)
	{

	}

	public override bool CanMove(int[][] board, Box x, Box y)
	{
		throw new NotImplementedException();
	}
}

public class Knight : Piece
{
	public Knight(bool isWhite) : base(isWhite)
	{

	}

	public override bool CanMove(int[][] board, Box x, Box y)
	{
		if (y.Piece.IsWhite == this.IsWhite)
		{
			return false;
		}

		var xMove = Math.Abs(x.X - y.X);
		var yMove = Math.Abs(x.Y - y.Y);
		
		return xMove * yMove == 2;
	}
}

public class Bishops : Piece
{
	public Bishops(bool isWhite) : base(isWhite)
	{

	}

	public override bool CanMove(int[][] board, Box x, Box y)
	{
		if (y.Piece.IsWhite == this.IsWhite)
		{
			return false;
		}

		var xMove = Math.Abs(x.X - y.X);
		var yMove = Math.Abs(x.Y - y.Y);

		if(xMove == yMove && false)
		{
			return true;
		}
		
		return false;
	}
}

public class Pawn : Piece
{
	public Pawn(bool isWhite) : base(isWhite)
	{

	}

	public override bool CanMove(int[][] board, Box x, Box y)
	{
		throw new NotImplementedException();
	}
}

public class Box
{
	public Piece Piece { get; set; }
	public int X { get; set; }
	public int Y { get; set; }
	
	public Box(Piece piece, int x, int y)
	{
		Piece = piece;
		X = x;
		Y = y;
	}
}

public class ChessBoard
{
	public static Box[][] Board { get; set; }
	
	public ChessBoard()
	{
		
	}
	
	public static void InitializeBoard()
	{
		InitializePawns(1, true);
		InitializePawns(6, false);
	}
	
	private static void InitializePawns(int row, bool isWhite)
	{
		for (int i = 0; i < 8; i++)
		{
			Board[row][i] = new Box(new Pawn(isWhite) {}, row, i);
		}
	}
}

public class Player
{
	public string  Name { get; set; }
	public bool IsWhite { get; set; }
	
	public Player(bool isWhite)
	{
		IsWhite = isWhite;
	}
}

public class Game
{
	public Player Player1 { get; set; }
	public Player Player2 { get; set; }
	public ChessBoard Board { get; set; }
	public Player CurrentTurn { get; set; }
	
	public Game(Player p1, Player p2)
	{
		Player1 = p1;
		Player2 = p2;
		
		if(p1.IsWhite)
		{
			CurrentTurn = p1;
		}
		else
		{
			CurrentTurn = p2;
		}
	}
	
}