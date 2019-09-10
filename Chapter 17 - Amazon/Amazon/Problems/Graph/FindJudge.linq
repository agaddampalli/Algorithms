<Query Kind="Program" />

void Main()
{
	var input = new int[][] {
	new int[]{1,3},
	new int[]{2,3},
	};

	FindJudge(3, input).Dump();
	FindJudge1(3, input).Dump();
}

public int FindJudge(int N, int[][] trust)
{
	var graph = new Dictionary<int, HashSet<int>>();
	for (int i = 1; i <= N; i++)
	{
		graph.Add(i, new HashSet<int>());
	}
	
	int judge = -1;
	for (int i = 0; i < trust.Length; i++)
	{
		graph[trust[i][1]].Add(trust[i][0]);
		if(graph[trust[i][1]].Count == N-1)
		{
			judge = trust[i][1];
		}
	}
	
	foreach (var people in graph)
	{
		if(people.Value.Contains(judge))
		{
			judge = -1;
		}
	}
	
	return judge;
}

public int FindJudge1(int N, int[][] trust)
{
	var trustValue = new int[N + 1];
	
	for (int i = 0; i < trust.Length; i++)
	{
		trustValue[trust[i][0]] -= 1;
		trustValue[trust[i][1]] += 1;
	}
	
	for (int i = 1; i < trustValue.Length; i++)
	{
		if(trustValue[i] == N-1)
		{
			return i;
		}
	}
	
	return -1;
}