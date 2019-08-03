<Query Kind="Program" />

void Main()
{
	var packagesSpace = new int[] {1,10,25,35,60, 50};
	
	AmazonSortCenter(packagesSpace, 90).Dump();
}

// Time Complexity: O(N)
// Space complexity: O(N)
public int[] AmazonSortCenter(int[] packagesSpace, int truckSpace)
{
	var targetTruckSpace = truckSpace - 30;
	
	var maxSpace = int.MinValue;
	var dictionary = new Dictionary<int, int>();
	
	for (int i = 0; i < packagesSpace.Length; i++)
	{
		dictionary.Add(packagesSpace[i], i);
	}
	
	for (int i = 0; i < packagesSpace.Length; i++)
	{
		var temp = targetTruckSpace - packagesSpace[i];
		
		if(dictionary.ContainsKey(temp))
		{
			if(packagesSpace[i] > maxSpace)
			{
				maxSpace = packagesSpace[i];
			}
		}
	}
	
	return new int[] {dictionary[targetTruckSpace - maxSpace], dictionary[maxSpace]};
}