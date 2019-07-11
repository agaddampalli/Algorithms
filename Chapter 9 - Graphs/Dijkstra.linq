<Query Kind="Program" />

void Main()
{
	var input = new int[,] {{0, 4, 0, 0, 0, 0, 0, 8, 0},
					  		{4, 0, 8, 0, 0, 0, 0, 11, 0},
					  		{0, 8, 0, 7, 0, 4, 0, 0, 2},
					  		{0, 0, 7, 0, 9, 14, 0, 0, 0},
					  		{0, 0, 0, 9, 0, 10, 0, 0, 0},
					  		{0, 0, 4, 14, 10, 0, 2, 0, 0},
					  		{0, 0, 0, 0, 0, 2, 0, 1, 6},
					  		{8, 11, 0, 0, 0, 0, 1, 0, 7},
					  		{0, 0, 2, 0, 0, 0, 6, 7, 0}
						 };
					 
	Dijkstra(input);
}

public void Dijkstra(int[,] graph)
{
	var length = graph.GetLength(0);
	int[] dist = new int[length];
	bool[] visited = new bool[length];
	int[] parentVertex = new int[length];
	
	for (int i = 0; i < length; i++)
	{
		dist[i] = int.MaxValue;
	}	
	
	dist[0] = 0;
	parentVertex[0] = 0;
	
	for (int i = 0; i < length; i++)
	{
		var minIndex = FindMinIndex(dist, visited);
		visited[minIndex] = true;
		
		for (int j = 0; j < length; j++)
		{
			if(!visited[j] && dist[minIndex] != int.MaxValue && graph[minIndex,j] != 0 && dist[minIndex] + graph[minIndex,j] < dist[j])
			{
				dist[j] = dist[minIndex] + graph[minIndex,j];
				parentVertex[i] = minIndex;
			}
		}
	}
	
	for (int i = 0; i < length; i++)
	{
		$"Vertex : {i}; Distance : {dist[i]}; Parent : {parentVertex[i]}".Dump();
	}
}

public int FindMinIndex(int[] dist, bool[] visited)
{
	var minDist = int.MaxValue;
	var minIndex = int.MaxValue;
	
	for (int i = 0; i < dist.Length; i++)
	{
		if(!visited[i] && dist[i] <= minDist)
		{
			minDist = dist[i];
			minIndex = i;
		}
	}
	
	return minIndex;
}
