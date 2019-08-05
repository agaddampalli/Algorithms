<Query Kind="Program" />

void Main()
{
	var numTotalAvailableRoads = new List<List<int>> { new List<int>{ 1, 2 }, new List<int>{ 2, 3 }, new List<int>{ 4, 5 }, new List<int>{ 5, 6 }, new List<int>{ 1, 5 }, new List<int>{ 2, 4 }, new List<int>{ 3, 4 } };
	var costRoadsToBeRepaired = new List<List<int>> { new List<int>{ 1, 5, 110 }, new List<int>{ 2, 4, 84 }, new List<int>{3, 4, 79 } };
	
	GetMinimumCostToRepair(6,7,numTotalAvailableRoads, 3, costRoadsToBeRepaired).Dump();
}

// We build weighted undirected graph, with 0 as the weight for available roads and the cost of the roads to be repaired
// We then find the minimum spanning tree in the graph
// Time COmplexity: O(N ^ 2);
// Space complexity: O(N)
public int GetMinimumCostToRepair(
int numTotalAvailableCities,
int numTotalAvailableRoads,
List<List<int>> roadsAvailable,
int numRoadsToBeRepaired,
List<List<int>> costRoadsToBeRepaired)
{
	var subsets = new List<Subset>();
	subsets.Add(new Subset(-1, 0));
	for (int i = 1; i <= numTotalAvailableCities; i++)
	{
		subsets.Add(new Subset(i, 0));
	}
	
	var edgesList = new List<Edge>();
	for (int i = 0; i < roadsAvailable.Count; i++)
	{
		edgesList.Add(new Edge(roadsAvailable[i][0], roadsAvailable[i][1], 0));
	}
	
	for (int i = 0; i < edgesList.Count; i++)
	{
		for (int j = 0; j < costRoadsToBeRepaired.Count; j++)
		{
			if(edgesList[i].Source == costRoadsToBeRepaired[j][0] && edgesList[i].Dest == costRoadsToBeRepaired[j][1])
			{
				edgesList[i].Weight = costRoadsToBeRepaired[j][2];
			}
		}
	}
	
	var cost = 0;
	edgesList.Sort((x,y) =>x.Weight-y.Weight);
	edgesList.Dump();
	
	for (int i = 0; i < edgesList.Count; i++)
	{
		var x = Find(subsets, edgesList[i].Source);
		var y = Find(subsets, edgesList[i].Dest);
		
		if(x == y)
		{
			return cost;
		}
		
		Union(subsets, edgesList[i].Source, edgesList[i].Dest);
		cost += edgesList[i].Weight;
	}
	
	return cost;
}


public int Find(List<Subset> subsets, int vertex)
{
	if (subsets[vertex].Parent != vertex)
	{
		subsets[vertex].Parent = Find(subsets, subsets[vertex].Parent);
	}

	return subsets[vertex].Parent;
}

public void Union(List<Subset> subsets, int x, int y)
{
	var xParent = Find(subsets, x);
	var yParent = Find(subsets, y);

	if (subsets[xParent].Rank < subsets[yParent].Rank)
	{
		subsets[xParent].Parent = yParent;
	}
	else if (subsets[xParent].Rank > subsets[yParent].Rank)
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

public class Edge
{
	public int Source { get; set; }

	public int Dest { get; set; }
	
	public int Weight { get; set; }

	public Edge(int source, int dest, int weight)
	{
		Source = source;
		Dest = dest;
		Weight = weight;
	}
}