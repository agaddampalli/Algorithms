<Query Kind="Program" />

void Main()
{
	var input =  new int[1][];
	
	for (int i = 0; i < input.Length; i++)
	{
		input[i] = new int[1];
	}
	
//	input[0][1] = 1;
	
	input.Dump();
	
	UniquePathsWithObstacles(input).Dump();
}

public int UniquePathsWithObstacles(int[][] obstacleGrid)
{	
	var m = obstacleGrid.Length;
	var n = obstacleGrid[0].Length;

	if(obstacleGrid[0][0] == 1)
	{
		return 0;
	}
	
	obstacleGrid[0][0] = 1;
	
	for (int i = 1; i < n; i++)
	{
		if (obstacleGrid[0][i] == 1)
		{
			obstacleGrid[0][i] = 0;
			continue;
		}
		obstacleGrid[0][i] = obstacleGrid[0][i-1];
	}
	
	for (int i = 1; i < m; i++)
	{
		if (obstacleGrid[i][0] == 1)
		{
			obstacleGrid[i][0] = 0;
			continue;
		}
		
		obstacleGrid[i][0] = obstacleGrid[i-1][0];
	}
	
	for (int row = 1; row < m; row++)
	{
		for (int col = 1; col < n; col++)
		{
			if(obstacleGrid[row][col] == 1)
			{
				obstacleGrid[row][col] = 0;
				continue;
			}
			
			obstacleGrid[row][col] = obstacleGrid[row][col - 1] + obstacleGrid[row - 1][col];
		}
	}


	return obstacleGrid[m - 1][n - 1];
}