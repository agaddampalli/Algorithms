<Query Kind="Program" />

void Main()
{
	var graph = new int[,] { {1, 1, 1, 1},
							 {1, 0, 1, 1},
							 {2, 1, 1, 1}};
							 
	MinRouteToTreasure(graph).Dump();		
}

public int MinRouteToTreasure(int[,] graph)
{
	if (graph == null)
	{
		return -1;
	}

	var rowLength = graph.GetLength(0);
	var colLength = graph.GetLength(1);
	var dist = 0;
	var previousParent = new List<int[]>();
	var queue = new Queue<Tuple<int,int>>();

	queue.Enqueue(Tuple.Create(0,0));

	while(queue.Count != 0)
	{
		var index = queue.Dequeue();
		previousParent.Add(new int[] {index.Item1, index.Item2});
		
		if(graph[index.Item1, index.Item2] == 2)
		{
			graph.Dump();
			previousParent.Dump();
			return dist;
		}
		
		dist = dist + 1;
		graph[index.Item1, index.Item2] = 0;

		if (index.Item2 + 1 < colLength && graph[index.Item1, index.Item2 + 1] != 0)
		{
			queue.Enqueue(Tuple.Create(index.Item1, index.Item2 + 1));
		}

		if (index.Item2 - 1 > 0 && graph[index.Item1, index.Item2 - 1] != 0)
		{
			queue.Enqueue(Tuple.Create(index.Item1, index.Item2 - 1));
		}

		if (index.Item1+1 < rowLength && graph[index.Item1+1, index.Item2] != 0)
		{
			queue.Enqueue(Tuple.Create(index.Item1+1, index.Item2));
		}

		if(index.Item1 -1 > 0 && graph[index.Item1-1, index.Item2] != 0)
		{
			queue.Enqueue(Tuple.Create(index.Item1 - 1, index.Item2));
		}
	}

	return -1;
}

public int MinIndex(int[] dist, bool[] visited)
{
	int minIndex = 0, minDist = int.MaxValue;

	for (int i = 0; i < dist.Length; i++)
	{
		if (!visited[i] && dist[i] < minDist)
		{
			minDist = dist[i];
			minIndex = i;
		}
	}

	return minIndex;
}
