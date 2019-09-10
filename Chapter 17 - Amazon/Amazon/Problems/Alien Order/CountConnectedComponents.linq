<Query Kind="Program" />

void Main()
{
	var edges = new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 3, 4}};
	
	CountComponents(5, edges).Dump();
}

public int CountComponents(int n, int[][] edges)
{
	var parent = new int[n];

	for (int i = 0; i < n; i++)
	{
		parent[i] = i;
	}
	
	var count = n;
	for (int i = 0; i < edges.Length; i++)
	{
		var x = FindParent(parent, edges[i][0]);
		var y = FindParent(parent, edges[i][1]);

		if (x != y)
		{
			count--;
			parent[x] = y;
		}
	}
	
	return count;
}


public int FindParent(int[] parent, int vertex)
{
	if (parent[vertex] != vertex)
	{
		return FindParent(parent, parent[vertex]);
	}

	return vertex;
}

public void Union(int[] parent, int x, int y)
{
	var xParent = FindParent(parent, x);
	var yParent = FindParent(parent, y);

	
}