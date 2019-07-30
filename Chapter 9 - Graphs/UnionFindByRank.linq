<Query Kind="Program" />

void Main()
{
	var edges = new int[,] { { 1, 2 }, { 2, 3 }, { 3, 4 }, {4,5}, {2,4}};
	
	UnionFindByRank(edges, 5).Dump();
}

public bool UnionFindByRank(int[,] edges, int vertices)
{
	var subsets = new List<Subset>();
	subsets.Add(new Subset(-1, 0));
	for (int i = 1; i <= vertices; i++)
	{
		subsets.Add(new Subset(i,0));
	}
	
	for (int i = 0; i < edges.GetLength(0); i++)
	{
		var x = Find(subsets, edges[i, 0]);
		var y = Find(subsets, edges[i, 1]);

		if (x == y)
		{
			subsets.Dump();
			return false;
		}
		
		Union(subsets, edges[i, 0], edges[i, 1]);
	}
	
	subsets.Dump();
	return true;
}

public int Find(List<Subset> subsets, int vertex)
{
	if(subsets[vertex].Parent != vertex)
	{
		subsets[vertex].Parent = Find(subsets, subsets[vertex].Parent);
	}
	
	return subsets[vertex].Parent;
}

public void Union(List<Subset> subsets, int x, int y)
{
	var xParent = Find(subsets, x);
	var yParent = Find(subsets, y);
	
	if(subsets[xParent].Rank < subsets[yParent].Rank)
	{
		subsets[xParent].Parent = yParent;
	}
	else if(subsets[xParent].Rank > subsets[yParent].Rank)
	{
		subsets[yParent].Parent = xParent;
	}
	else
	{
		subsets[xParent].Parent = yParent;
		subsets[yParent].Rank++;
	}
}

public class Subset
{
	public int Parent { get; set; }
	
	public int Rank { get; set; }
	
	public Subset(int parent, int rank)
	{
		Parent = parent;
		Rank = rank;
	}
}