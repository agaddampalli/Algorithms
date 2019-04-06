<Query Kind="Program" />

void Main()
{
	GetPairsWithDifference(new int[] {1,7,5,9,2,12,3}, 2).Dump();
}

public HashSet<List<int>> GetPairsWithDifference(int[] input, int difference)
{
	
	var result = new HashSet<List<int>>();
	
	var inputHashTable = new HashSet<int>();
	
	for (int i = 0; i < input.Length; i++)
	{
		inputHashTable.Add(input[i]);	
	}
	
	foreach (var element in inputHashTable)
	{
		if(inputHashTable.Contains(element + difference))
		{
			result.Add(new List<int> {element, element + difference});
		}

	}
	return result;
}