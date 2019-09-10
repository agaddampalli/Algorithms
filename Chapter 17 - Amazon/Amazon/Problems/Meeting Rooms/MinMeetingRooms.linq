<Query Kind="Program" />

void Main()
{
	var interavls = new int[][] {new int[] {0, 30},new int[] {5, 10}, new int[] {10, 15}, new int[] {15, 20}};
	
	MinMeetingRooms(interavls).Dump();
}

// 0 5 15 
// 10 20 30

public int MinMeetingRooms(int[][] intervals)
{
	var n = intervals.Length;

	var start = new int[n];
	var end = new int[n];
	
	int i = 0;
	for (; i < n; i++)
	{
		start[i] = intervals[i][0];
		end[i] = intervals[i][1];
	}
	
	Array.Sort(start);
	Array.Sort(end);
	
	i = 0;
	int j = 0;
	int usedRooms = 0;
	
	while(i < start.Length)
	{
		if(start[i] >= end[j])
		{
			usedRooms--;
			j++;
		}
		
		usedRooms++;
		i++;
	}
	
	return usedRooms;
}
