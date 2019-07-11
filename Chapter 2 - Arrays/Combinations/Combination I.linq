<Query Kind="Program" />

void Main()
{
	Combine(4, 2).Dump();
}

public IList<IList<int>> Combine(int n, int k)
{

	var output = new List<IList<int>>();

	Combination(n, k, 1, new List<int>(), output);

	return output;
}

public void Combination(int n, int k, int level, List<int> temp, List<IList<int>> output)
{
	if (k == temp.Count)
	{
		output.Add(new List<int>(temp));
		return;
	}

	if (level > n)
		return;

	for (var i = level; i <= n; i++)
	{
		temp.Add(i);
		Combination(n, k, i + 1, temp, output);
		temp.RemoveAt(temp.Count - 1);
	}
}