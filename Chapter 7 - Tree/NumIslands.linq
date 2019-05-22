<Query Kind="Program" />

void Main()
{
	char[][] input = new char[][] { new char[]{'1', '1', '1'},
							   		new char[]{'0', '1', '0'},
							   		new char[]{'1', '1', '1'}};
//							   		new char[]{'0', '0', '0', '0', '0'},
//							   		new char[]{'1', '0', '1', '0', '1'}};

	NumIslands(input).Dump();
}

public int NumIslands(char[][] grid)
{
	if (grid == null)
	{
		return 0;
	}

	int count = 0;
	for (int i = 0; i < grid.Length; i++)
	{
		for (int j = 0; j < grid[i].Length; j++)
		{
			if (grid[i][j] == '1')
			{
				ProcessIslands(i, j, grid);
				count++;
			}
		}
	}

	return count;
}

public void ProcessIslands(int row, int col, char[][] grid)
{
	grid[row][col] = '*';

	if (row + 1 < grid.Length && grid[row + 1][col] == '1')
	{
		ProcessIslands(row + 1, col, grid);
	}

	if (row - 1 >= 0 && grid[row - 1][col] == '1')
	{
		ProcessIslands(row - 1, col, grid);
	}

	if (col - 1 >= 0 && grid[row][col - 1] == '1')
	{
		ProcessIslands(row, col - 1, grid);
	}

	if (col + 1 < grid[row].Length && grid[row][col + 1] == '1')
	{
		ProcessIslands(row, col + 1, grid);
	}
}
