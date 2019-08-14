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

public List<int> IDsOfSongs(int rideDuration, List<int> songDurations)
{
	var songDurationDict = new Dictionary<int, int>();
	for (int i = 0; i < songDurations.Count; i++)
	{
		songDurationDict.Add(songDurations[i], i);
	}

	songDurations.Sort();

	var target = rideDuration - 30;
	var output = new List<int>();

	var song1 = 0;
	var song2 = 0;

	int start = 0;
	int end = songDurations.Count - 1;
	var maxDiff = int.MinValue;

	while (start < end)
	{
		var temp = songDurations[start] + songDurations[end];

		if (temp == target)
		{
			var diff = Math.Abs(songDurations[start] - songDurations[end]);
			if (diff > maxDiff)
			{
				song1 = songDurations[start];
				song2 = songDurations[end];
				maxDiff = diff;
			}

			start++;
			end--;
		}
		else if (temp < target)
		{
			start++;
		}
		else if (temp > target)
		{
			end--;
		}
	}

	output.Add(songDurationDict[song1]);
	output.Add(songDurationDict[song2]);

	return output;
}