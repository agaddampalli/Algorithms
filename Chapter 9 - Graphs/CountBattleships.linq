<Query Kind="Program" />

void Main()
{
	23/10
}

public int CountBattleships(char[][] board)
{
	int count = 0;
	for (int r = 0; r < board.Length; r++)
	{
		bool found = false;
		for (int c = 0; c < board[r].Length; c++)
		{
			if (board[r][c] == 'X' && !found && (r == 0 || board[r - 1][c] != 'X'))
			{
				found = true;
				count++;
			}
			else if (board[r][c] == '.' && found)
				found = false;
		}
	}
	return count;
}
