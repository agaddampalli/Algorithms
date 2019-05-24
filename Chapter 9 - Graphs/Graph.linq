<Query Kind="Program">
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
//	var graph = new Graph<int>();

	//	graph.AddVertex(1);
	//	graph.AddVertex(2);
	//	graph.AddVertex(3);
	//	graph.AddEdge(1, 2);
	//	graph.AddEdge(1, 3);
	//	graph.AddEdge(2, 3);
	//	graph.AddEdge(4, 3);
	//	graph.AddEdge(4, 1);
	//	graph.AddEdge(4, 2);
	//	graph.AddEdge(3, 3);

	//	graph.AddDirectedEdge(0, 1);
	//	graph.AddDirectedEdge(0, 2);
	//	graph.AddDirectedEdge(1, 2);
	//	graph.AddDirectedEdge(2, 0);
	//	graph.AddDirectedEdge(2, 3);
	//	graph.AddDirectedEdge(3, 3);

	//	graph.AddDirectedEdge(1, 0);
	//	graph.AddDirectedEdge(0, 2);
	//	graph.AddDirectedEdge(2, 1);
	//	graph.AddDirectedEdge(0, 3);
	//	graph.AddDirectedEdge(1, 4);

	//	graph.AddDirectedEdge(0, 1);
	//	graph.AddDirectedEdge(0, 2);
	//	graph.AddDirectedEdge(1, 3);
	//	graph.AddDirectedEdge(4, 1);
	//	graph.AddDirectedEdge(6, 4);
	//	graph.AddDirectedEdge(5, 6);
	//	graph.AddDirectedEdge(5, 2);
	//	graph.AddDirectedEdge(6, 0);

	//	graph.AddDirectedEdge(0, 1);
	//	graph.AddDirectedEdge(0, 2);
	//	graph.AddDirectedEdge(1, 2);
	//	graph.AddDirectedEdge(2, 0);
	//	graph.AddDirectedEdge(2, 3);
	//	graph.AddDirectedEdge(3, 3);

	//	graph.AddEdge(0, 1);
	//	graph.AddEdge(0, 2);
	//	graph.AddEdge(1, 2);
	//	graph.AddEdge(1, 5);
	//	graph.AddEdge(2, 3);
	//	graph.AddEdge(2, 4);
	//	graph.AddEdge(2, 5);
	//	graph.AddEdge(2, 6);
	//	graph.AddEdge(3, 4);
	//	graph.AddEdge(3, 6);
	//	graph.AddEdge(3, 7);
	//	graph.AddEdge(4, 6);
	//	graph.AddEdge(4, 7);
	//	graph.AddEdge(5, 6);
	//	graph.AddEdge(5, 8);
	//	graph.AddEdge(6, 8);
//		graph.AddEdge(6, 7);

		var graph = new Graph<string>();
		graph.AddDirectedEdge("a", "b");
		graph.AddDirectedEdge("a", "c");
		graph.AddDirectedEdge("a", "e");
		graph.AddDirectedEdge("b", "d");
		graph.AddDirectedEdge("b", "e");
		graph.AddDirectedEdge("c", "e");
		graph.AddDirectedEdge("d", "c");

//		graph.AddDirectedEdge(0, 1);
//		graph.AddDirectedEdge(0, 2);
//		graph.AddDirectedEdge(0, 3);
//		graph.AddDirectedEdge(2, 0);
//		graph.AddDirectedEdge(2, 1);
//		graph.AddDirectedEdge(1, 3);
	
	graph.Print();

	//	graph.BFS(0);
	//	graph.DFS(0);
	//	graph.DFSIterative(0);
	//
	//	var vertices = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
	//	$"Mother Vertex: {graph.MotherVertex(vertices)}".Dump();
	//
	//	$"Transitive Closure: ".Dump();
	//	graph.TransitiveClosure(vertices).Dump();
	//
	//	graph.FindKCores(3, vertices);

	//	graph.AddDirectedEdge(0, 1);
	//	graph.AddDirectedEdge(0, 2);
	//	graph.AddDirectedEdge(1, 2);
	//	graph.AddDirectedEdge(2, 0);
	//	graph.AddDirectedEdge(2, 3);
	
	graph.FindAllPaths("a","e").Dump();
}

public class Graph<T>
{
	public Dictionary<T, List<T>> AdjacencyList { get; set; }

	public Graph()
	{
		AdjacencyList = new Dictionary<T, List<T>>();
	}

	public void AddVertex(T val)
	{
		if (!AdjacencyList.ContainsKey(val))
		{
			AdjacencyList.Add(val, new List<T>());
		}
	}

	public void AddEdge(T src, T dest)
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

		if (src.Equals(dest))
		{
			return;
		}

		if (AdjacencyList.ContainsKey(dest))
		{
			AdjacencyList[dest].Add(src);
		}
		else
		{
			var list = new List<T>();
			list.Add(src);
			AdjacencyList.Add(dest, list);
		}
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

	public void Print()
	{
		foreach (var vertex in AdjacencyList)
		{
			var printString = $"Vertex : {vertex.Key} --> Edges: ";
			foreach (var element in vertex.Value)
			{
				printString = printString + element + ", ";
			}

			printString.Substring(0, printString.Length - 2).Dump();
		}
	}

	public void BFS(T src)
	{
		var queue = new Queue<T>();
		var visited = new HashSet<T>();

		queue.Enqueue(src);
		visited.Add(src);

		var BFS = "BFS : ";

		while (queue.Count != 0)
		{
			var vertex = queue.Dequeue();
			BFS = BFS + vertex + "-->";

			if (AdjacencyList.ContainsKey(vertex))
			{
				var values = AdjacencyList[vertex];
				foreach (var element in values)
				{
					if (!visited.Contains(element))
					{
						queue.Enqueue(element);
						visited.Add(element);
					}
				}
			}
		}

		BFS.Substring(0, BFS.Length - 3).Dump();
	}

	public void DFS(T src)
	{
		var visited = new HashSet<T>();
		var dfs = "DFS : ";

		dfs = DFS(src, visited, dfs);
		dfs.Substring(0, dfs.Length - 3).Dump();
	}

	public void DFSIterative(T src)
	{
		var stack = new Stack<T>();
		var visited = new HashSet<T>();

		stack.Push(src);
		var dfs = "DFS Iterative: ";

		while (stack.Count != 0)
		{
			var vertex = stack.Pop();

			if (!visited.Contains(vertex))
			{
				dfs = dfs + vertex + "-->";
				visited.Add(vertex);
			}

			if (AdjacencyList.ContainsKey(vertex))
			{
				var values = AdjacencyList[vertex];
				foreach (var element in values)
				{
					if (!visited.Contains(element))
					{
						stack.Push(element);
					}
				}
			}
		}

		dfs.Substring(0, dfs.Length - 3).Dump();
	}

	public string DFS(T src, HashSet<T> visited, string dfs)
	{
		dfs = dfs + src + "-->";
		visited.Add(src);
		if (AdjacencyList.ContainsKey(src))
		{
			var values = AdjacencyList[src];
			foreach (var element in values)
			{
				if (!visited.Contains(element))
				{
					dfs = DFS(element, visited, dfs);
				}
			}
		}

		return dfs;
	}

	public int MotherVertex(T[] vertices)
	{
		var visited = new HashSet<T>();

		T vertex = vertices[0];
		foreach (var element in vertices)
		{
			if (!visited.Contains(element))
			{
				DFS(element, visited, "");
				vertex = element;
			}
		}

		visited = new HashSet<T>();
		DFS(vertex, visited, "");

		foreach (var element in vertices)
		{
			if (!visited.Contains(element))
			{
				return -1;
			}
		}

		return Convert.ToInt32(vertex);
	}

	public void DFS(T src, T dest, int[,] visited)
	{
		visited[Convert.ToInt64(src), Convert.ToInt64(dest)] = 1;
		if (AdjacencyList.ContainsKey(src))
		{
			var values = AdjacencyList[dest];
			foreach (var element in values)
			{
				if (visited[Convert.ToInt64(src), Convert.ToInt64(element)] == 0)
				{
					DFS(src, element, visited);
				}
			}
		}
	}

	public int[,] TransitiveClosure(T[] vertices)
	{
		var visited = new int[vertices.Length, vertices.Length];

		foreach (var element in vertices)
		{
			DFS(element, element, visited);
		}

		return visited;
	}

	public void FindKCores(int k, T[] vertices)
	{
		var degree = new int[vertices.Length];

		for (int i = 0; i < vertices.Length; i++)
		{
			degree[i] = AdjacencyList[vertices[i]].Count;
		}

		var visited = new HashSet<T>();
		DFS(vertices[0], visited, degree, k);

		degree.Dump();
	}

	public bool DFS(T src, HashSet<T> visited, int[] degree, int k)
	{
		visited.Add(src);

		foreach (var element in AdjacencyList[src])
		{
			if (degree[Convert.ToInt64(src)] < k)
			{
				degree[Convert.ToInt64(element)]--;
			}
			
			if (!visited.Contains(element))
			{
				if (DFS(element, visited, degree, k))
				{
					degree[Convert.ToInt64(src)]--;
				}
			}
		}

		return degree[Convert.ToInt64(src)] < k;
	}

	public int FindAllPaths(T src, T dest)
	{
		var visited = new HashSet<T>();
		int pathCount = 0; 
		
		var result = new List<IList<T>>();

		DFS(src, dest, visited, new List<T> { src}, result);
		
		result.Dump();
		
		return DFS(src, dest,visited,pathCount);
	}

	public int DFS(T src, T dest, HashSet<T> visited, int count)
	{
		visited.Add(src);
		
		if(src.Equals(dest))
		{
			count++;
		}
		else
		{
			foreach (var element in AdjacencyList[src])
			{
				if (!visited.Contains(element))
				{
					count = DFS(element, dest, visited, count);
				}
			}
		}

		visited.Remove(src);

		return count;
	}

	public void DFS(T src, T dest, HashSet<T> visited, List<T> currentList, List<IList<T>> result)
	{
		visited.Add(src);

		if (src.Equals(dest))
		{
			var clonedList = Clone(currentList);
			result.Add(clonedList);
		}
		else
		{
			foreach (var element in AdjacencyList[src])
			{
				if (!visited.Contains(element))
				{
					currentList.Add(element);
					DFS(element, dest, visited, currentList, result);
				}
			}
		}

		visited.Remove(src);
		currentList.Remove(src);
	}

	public IList<T> Clone(IList<T> listToClone)
	{
		return listToClone.Select(item => (T)item).ToList();
	}
}