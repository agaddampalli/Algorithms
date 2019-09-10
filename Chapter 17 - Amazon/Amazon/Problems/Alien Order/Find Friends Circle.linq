<Query Kind="Program" />

void Main()
{
	
}

public int FindCircleNum(int[][] M)
{
	var length = M.Length;
	
	var visited = new bool[length];
	
	int count = 0;
	for (int i = 0; i < length; i++)
	{
		if(!visited[i])
		{
			DFS(M, i, visited);
			count++;
		}
	}
	
	return count;
}

public void DFS(int[][] M, int row, bool[] visited)
{
	for (int j = 0; j < M.Length; j++)
	{
		if(M[row][j] == 1 && !visited[j])
		{
			visited[j] = true;
			DFS(M, j, visited);
		}
	}
}