<Query Kind="Program" />

void Main()
{
	var input = new int[][]{
					new int[]{9,9,4},
					new int[]{6,6,8},
					new int[]{2,1,1},
					};
	
	LongestIncreasingPath(input).Dump();
}

public int maxLength;
public int LongestIncreasingPath(int[][] matrix)
{
	if(matrix == null || matrix.Length == 0)
	{
		return 0;
	}
	
	var rowLength = matrix.Length;
	var colLength = matrix[0].Length;
	maxLength = int.MinValue;
	
	for (int i = 0; i < rowLength; i++)
	{
		for (int j = 0; j < colLength; j++)
		{
			Find(matrix, i,j,rowLength,colLength, int.MinValue, 0);
		}
	}
	
	return maxLength;
}

public void Find(int[][] graph, int row, int col, int rowLength, int colLength, int previousValue, int count)
{
	if(row < 0 || row >= rowLength || col < 0 || col >= colLength || graph[row][col] <= previousValue || graph[row][col] == int.MinValue)
	{
		maxLength = count > maxLength ? count : maxLength;
		return;
	}
	
	var temp = graph[row][col];
	graph[row][col] = int.MinValue;
	Find(graph, row + 1, col, rowLength, colLength, temp, count+1);
	Find(graph, row - 1, col, rowLength, colLength, temp, count+1);
	Find(graph, row, col - 1, rowLength, colLength, temp, count+1);
	Find(graph, row, col + 1, rowLength, colLength, temp, count+1);
	graph[row][col] = temp;
}