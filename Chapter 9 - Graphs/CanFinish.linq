<Query Kind="Program" />

void Main()
{
	var array = new int[][] { new int[] {1,0}, new int[] {0,2}, new int[] {1,2}, new int[] {2,0}};
	
	CanFinish(3, array).Dump();
}


public bool CanFinish(int numCourses, int[][] prerequisites)
{
	var graph = new Graph<int>();
	
	for (int i = 0; i < prerequisites.Length; i++)
	{
		graph.AddDirectedEdge(prerequisites[i][0], prerequisites[i][1]);
	}
	
	graph.AdjacencyList.Dump();
	var visited = new HashSet<int>();
	
	for (int i = 0; i < numCourses; i++)
	{
		if(!graph.DFS(i,visited))
		{
			return false;
		}
	}
	
	return true;
}

public class Graph<T>
{
	public Dictionary<T, List<T>> AdjacencyList { get; set; }
	public bool IsCyclic = false;
	public HashSet<T> Taken;
	
	public Graph()
	{
		AdjacencyList = new Dictionary<T, List<T>>();
		Taken = new HashSet<T>();
	}

	public void AddDirectedEdge(T src, T dest)
	{
		if (AdjacencyList.ContainsKey(src))
		{
			AdjacencyList[src].Add(dest);
		}
		else
		{
			var list = new List<T>();
			list.Add(dest);
			AdjacencyList.Add(src, list);
		}
	}

	public bool DFS(T src, HashSet<T> visited)
	{
		if(Taken.Contains(src))
		{
			return true;
		}
		
		if(visited.Contains(src))
		{
			return false;
		}
		
		visited.Add(src);
		if (AdjacencyList.ContainsKey(src))
		{
			var values = AdjacencyList[src];
			foreach (var element in values)
			{
				if (!DFS(element, visited))
				{
					return false;
				}
			}
		}

		Taken.Add(src);
		return true;
	}
}
