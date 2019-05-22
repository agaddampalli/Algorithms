<Query Kind="Program" />

void Main()
{
	int[][] input = new int[][] { new int[]{0, 1},
							   		new int[]{0, 2},
							   		new int[]{0, 3},
							   		new int[]{1, 4},
							   		new int[]{2, 3},
//							   		new int[]{5, 4},
//							   		new int[]{4, 5},
//							   		new int[]{5, 6},
//							   		new int[]{6, 3},
//							   		new int[]{6, 1},
									};

	ValidTree(5, input).Dump();
}

public bool ValidTree(int n, int[][] edges)
{
	if (n <= 1) return true;
	int[] parent = new int[n];
	for (int i = 0; i < n; i++)
	{
		parent[i] = i;
	}
	foreach (var edge in edges)
	{
		int x = find(parent, edge[0]);
		int y = find(parent, edge[1]);
		if (x == y) return false;
		parent[y] = x;
	}
	
	return edges.Length == n - 1;
}

public int find(int[] parent, int i)
{
	if (parent[i] != i)
	{
		parent[i] = find(parent, parent[i]);
	}
	return parent[i];
}

public bool ValidTree1(int n, int[][] edges)
{
	if(n == 1)
	{return true;}
	if(edges == null || edges.Length != n-1)
	{
		return false;
	}

	
	var childNodes = new HashSet<int>();
	var parentNodes = new HashSet<int>();
	parentNodes.Add(edges[0][0]);
	childNodes.Add(edges[0][1]);
	
	for (int i = 1; i < edges.Length; i++)
	{
		var condition1 = (edges[i][0] == edges[i - 1][0] || edges[i][0] == edges[i - 1][1]);
		var condition2 = (!parentNodes.Contains(edges[i][0]) && !childNodes.Contains(edges[i][0]));
		var condition3 = childNodes.Contains(edges[i][1]);
		
		
		if( (!condition1 && condition2) || condition3)
		{
			return false;
		}
		
		if(!parentNodes.Contains(edges[i][0]))
		{
			parentNodes.Add(edges[i][0]);
		}
		childNodes.Add(edges[i][1]);	
	}
	
	return true;
}

public bool ContainsAsChild(Dictionary<int, HashSet<int>> dictionary,HashSet<int> childSet, int val)
{
	if(childSet.Contains(val))
	{
		return true;
	}
	
	foreach (var element in childSet)
	{
		if(dictionary.ContainsKey(element))
		{
			return ContainsAsChild(dictionary, dictionary[element],val);
		}
	}
	
	return false;
}