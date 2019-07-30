<Query Kind="Program" />

void Main()
{
	var edges = new int[,] { { 1, 2 }, { 2, 3 }, { 3, 4 }, { 4, 5 }, {2,4}};
	
	UnionFind(edges, 5).Dump();
}

public bool UnionFind(int[,] edges, int vertices)
{
	var parent = new int[vertices+1];
	
	for (int i = 0; i < parent.Length; i++)
	{
		parent[i] = -1;
	}
	
	for (int i = 0; i < edges.GetLength(0); i++)
	{
		var xParent = Find(parent, edges[i, 0]);
		var yParent = Find(parent, edges[i, 1]);
		
		if(xParent == yParent)
		{
			parent.Dump();
			return false;
		}
		
		Union(parent, edges[i, 0], edges[i, 1]);
	}
	
	parent.Dump();
	return true;
}

public int Find(int[] parent, int vertex)
{
	if(parent[vertex] == -1)
	{
		return vertex;
	}
	
	return Find(parent, parent[vertex]);
}

public void Union(int[] parent, int x, int y)
{
	var xParent = Find(parent, x);
	var yParent = Find(parent, y);
	
	parent[xParent] = yParent;
}