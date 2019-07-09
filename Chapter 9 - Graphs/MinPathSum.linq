<Query Kind="Program" />

void Main()
{
	var input = new int[][] { new int[] {1, 3, 1},
							  new int[] {1, 5, 1},
							  new int[] {4, 2, 1}};
							  
							  
	// 1 4 5
	// 2 7 6
	// 6 8 7
	
	MinPathSum(input).Dump();
	
}

public int MinPathSum(int[][] grid)
{
	var m = grid.Length;
	var n = grid[0].Length;
	
	for (int i = 1; i < n; i++)
	{
		grid[0][i] += grid[0][i-1];
	}
	for (int i = 1; i < m; i++)
	{
		grid[i][ 0] += grid[i-1][0];
	}
	for (int row = 1; row < m; row++)
	{
		for (int col = 1; col < n; col++)
		{
			grid[row][ col] += Math.Min(grid[row][ col - 1] , grid[row - 1][ col]);
		}
	}

	return grid[m - 1][ n - 1];
}