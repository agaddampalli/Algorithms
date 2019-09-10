<Query Kind="Program" />

void Main()
{
	var prerequisites = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { 1, 2 }};
	FindOrder(3, prerequisites).Dump();
}

public int[] FindOrder(int numCourses, int[][] prerequisites)
{
	var degree = new Dictionary<int, int>();
	var output = new int[numCourses];
	for (int i = 0; i < numCourses; i++)
	{
		degree.Add(i,0);
	}
	
	var graph = new Dictionary<int, HashSet<int>>();
	
	for (int i = 0; i < prerequisites.Length; i++)
	{
		if(!graph.ContainsKey(prerequisites[i][1]))
		{
			graph[prerequisites[i][1]] = new HashSet<int>();
		}
		
		graph[prerequisites[i][1]].Add(prerequisites[i][0]);
		degree[prerequisites[i][0]]++;
	}
	
	graph.Dump();
	
	var queue = new Queue<int>();
	var visited = new bool[numCourses];
	
	foreach (var vertex in degree)
	{
		if(vertex.Value == 0)
		{
			queue.Enqueue(vertex.Key);
		}
	}
	
	var index = 0;
	while(queue.Any())
	{
		var node = queue.Dequeue();
		if (visited[node])
		{
			return new int[] {};
		}
		
		output[index++] = node;
		visited[node] = true;
		
		if(graph.ContainsKey(node))
		{
			var children = graph[node];
			foreach (var child in children)
			{
				degree[child]--;
				if (degree[child] == 0)
				{
					queue.Enqueue(child);
				}
			}
		}
	}
	
	return output;
}
