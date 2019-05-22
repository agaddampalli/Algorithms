<Query Kind="Program" />

void Main()
{
	getRow(5).Dump();
}

public List<int> getRow(int rowIndex)
{
	List<int> res = new List<int>();
	for (int i = 0; i <= rowIndex; i++)
	{
		res.Add(1);
		for (int j = i - 1; j > 0; j--)
		{
			res[j] = res[j - 1] + res[j];
		}
	}
	
	return res;
}
