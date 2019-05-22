<Query Kind="Program" />

void Main()
{
	Fib(3).Dump();
}

Dictionary<int, int> cache = new Dictionary<int, int>();

public int Fib(int N)
{
	if (cache.ContainsKey(N))
	{
		return cache[N];
	}
	int result;
	if (N < 2)
	{
		result = N;
	}
	else
	{
		result = Fib(N - 1) + Fib(N - 2);
	}
	// keep the result in cache.
	cache.Add(N, result);
	return result;
}