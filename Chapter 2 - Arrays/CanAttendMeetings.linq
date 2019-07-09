<Query Kind="Program" />

void Main()
{
	var intervals = new int[][] { new int[] {25,30},new int[] {5,10}, new int[] {10,20} };
	
	CanAttendMeetings(intervals).Dump();
}

public bool CanAttendMeetings(int[][] intervals)
{
	Array.Sort(intervals, (x,y) => x[0]-y[0]);
	
	for (int i = 0; i < intervals.Length-1; i++)
	{
		var end = intervals[i][1];
		var start = intervals[i+1][0];
		
		if(end > start)
		{
			return false;
		}
	}
	
	return true;
}
