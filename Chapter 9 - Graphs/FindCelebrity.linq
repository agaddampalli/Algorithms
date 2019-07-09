<Query Kind="Program" />

void Main()
{
	var graph = new bool[,] { { true, false }, { false, true } };;
	
	graph.Dump();
	
	FindCelebrity(2).Dump();
}

public int FindCelebrity(int n)
{
	int x = 0;
	for (int i = 0; i < n; ++i) if (Knows(x, i)) x = i;
	for (int i = 0; i < x; ++i) if (Knows(x, i)) return -1;
	for (int i = 0; i < n; ++i) if (!Knows(i, x)) return -1;
	return x;
}

public int FindCelebrity1(int n)
{
	if(n == 0 || n == 1)
	{
		return n;
	}
	
	for (int i = 0; i < n; i++)
	{
		int j = 0;
		if (i == j || !Knows(i, j))
		{
			while ((j < n && !Knows(i, j) && Knows(j,i)) || (i == j))
			{
				++j;
			}

			if (j == n)
			{
				return i;
			}
		}
	}
	
	return -1;
}

public bool Knows(int a, int b)
{
	var graph = new bool[,] { { true, false }, { false, true } };
	
	return graph[a, b];
}