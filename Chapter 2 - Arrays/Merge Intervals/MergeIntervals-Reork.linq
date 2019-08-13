<Query Kind="Program" />

void Main()
{
	var intervals = new List<int[]> { new int[] { 1, 3}, new int[] { 2,6}, new int[] { 8,10}, new int[] { 15,18}};
	
	MergeIntervals(intervals).Dump();
}

public List<int[]> MergeIntervals(List<int[]> intervals)
{
	var output = new List<int[]>();
	
	intervals.Sort((x,y) => x[1] - y[1]);
	
	int j = 0;
	output.Add(intervals[0]);
	for (int i = 0; i < intervals.Count; i++)
	{
		if(intervals[i][0] <= output[j][1])
		{
			output[j][1] = Math.Max(intervals[i][1], output[j][1]);
		}
		else
		{
			output.Add(intervals[i]);
			j++;
		}
	}
	
	return output;
}
