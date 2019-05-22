<Query Kind="Program" />

void Main()
{
	var board = new char[][]
	{
		new char []{'A','B', 'C', 'E'},
		new char []{'S','F', 'E', 'S'},
		new char []{'A','D', 'E', 'E'}
	};
	
	Exist(board, "ABCESEEEFS").Dump();

	var board1 = new char[][]
	{
		new char []{'o','a','a','n'},
		new char []{'e','t','a','e'},
		new char []{'i','h','k','r'},
		new char []{'i','f','l','v'}
	};

	var board2 = new char[][]
	{
		new char []{'a','a'}
	};

	FindWords(board2, new string[] {"a"}).Dump();

}

public bool Exist(char[][] board, string word)
{
	if(board == null || string.IsNullOrWhiteSpace(word))
	{
		return false;
	}
	
	var visited = new bool[board.Length, board[0].Length];
	for (int i = 0; i < board.Length; i++)
	{
		for (int j = 0; j < board[i].Length; j++)
		{
			if(board[i][j] == word[0])
			{
				visited[i,j] = true;
				if(IsMatch(board, word, i, j, 1, visited))
				{
					return true;
				}
				
				visited = new bool[board.Length, board[0].Length];
			}
		}
	}
	
	return false;
}

public IList<string> FindWords(char[][] board, string[] words)
{
	var output = new List<string>();
	
	if (board == null || words == null)
	{
		return output;
	}

	var visited = new bool[board.Length, board[0].Length];
	var wordSet = new HashSet<string>();
	for (int k = 0; k < words.Length; k++)
	{
		for (int i = 0; i < board.Length; i++)
		{
			for (int j = 0; j < board[i].Length; j++)
			{
				if (board[i][j] == words[k][0])
				{
					visited[i, j] = true;
					if (!wordSet.Contains(words[k]) && IsMatch(board, words[k], i, j, 1, visited))
					{
						output.Add(words[k]);
						wordSet.Add(words[k]);
					}

					visited = new bool[board.Length, board[0].Length];
				}
			}
		}
	}

	return output;
}

public bool IsMatch(char[][] board, string word, int row, int column, int i, bool[,] visited)
{
	if( i == word.Length)
	{
		return true;
	}
	
	if(row+1 < board.Length && board[row+1][column] == word[i] && !visited[row+1,column])
	{
		visited[row+1,column] = true;
		if(IsMatch(board, word, row+1, column, i+1, visited))
		{
			return true;
		}
		else
		{
			visited[row+1,column] = false;
		}
	}

	if (row - 1 >= 0 && board[row - 1][column] == word[i] && !visited[row-1,column])
	{
		visited[row - 1, column] = true;
		if (IsMatch(board, word, row - 1, column, i+1, visited))
		{
			return true;
		}
		else
		{
			visited[row - 1, column]  = false;
		}
	}

	if (column - 1 >= 0 && board[row][column - 1] == word[i] && !visited[row,column-1])
	{
		visited[row, column - 1] = true;
		if (IsMatch(board, word, row, column-1, i+1, visited))
		{
			return true;
		}
		else
		{
			visited[row, column - 1] = false;
		}
	}

	if (column + 1 < board[row].Length && board[row][column + 1] == word[i] && !visited[row,column+1])
	{
		visited[row, column + 1] = true;
		if (IsMatch(board, word, row, column +1, i+1, visited))
		{
			return true;
		}
		else
		{
			visited[row, column + 1] = false;
		}
	}
	
	return false;
}

