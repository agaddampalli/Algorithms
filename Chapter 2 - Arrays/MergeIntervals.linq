<Query Kind="Program" />

void Main()
{
	var input = new int[][] { new int[] { 1, 3 }, new int[] { 8, 10 }, new int[] { 2, 6 }, new int[] { 15, 18 }, new int[]{0,4}};
	
	Merge(input).Dump();
}

public int[][] Merge(int[][] intervals)
{
	List<int[]> output = new List<int[]>();
	
	if(intervals == null)
	{
		return output.ToArray();
	}

	Array.Sort(intervals, (x,y) => x[0]-y[0]);
	
	intervals.Dump();
	
	int j = -1;
	for (int i = 0; i < intervals.Length; i++)
	{
		if(!output.Any() || output[j][1] < intervals[i][0])
		{
			output.Add(intervals[i]);
			j++;
		}
		else
		{
			output[j][1] = Math.Max(output[j][1], intervals[i][1]);
		}
	}

	return output.ToArray();
}
