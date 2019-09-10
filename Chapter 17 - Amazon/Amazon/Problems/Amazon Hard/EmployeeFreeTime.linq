<Query Kind="Program" />

void Main()
{
	
}

public class Interval
{
	public int start;
	public int end;

	public Interval() { }
	public Interval(int _start, int _end)
	{
		start = _start;
		end = _end;
	}
}

public IList<Interval> EmployeeFreeTime(IList<IList<Interval>> schedule)
{
	var output = new List<Interval>();
	if(schedule == null || !schedule.Any())
	{
		return output;
	}
	
	int OPEN = 0, CLOSE = 1;
	var events = new List<int[]>();
	for (int i = 0; i < schedule.Count; i++)
	{
		foreach (var interval in schedule[i])
		{
			events.Add(new int[] { interval.start, OPEN });
			events.Add(new int[] { interval.end, CLOSE});
		}
	}
	
	var eventsArray = events.ToArray();
	Array.Sort(eventsArray, (x,y) => x[0] != y[0] ? x[0]-y[0] : x[1]-y[1]);	
	
	var start = 0;
	var prevEndTime = int.MinValue;
	
	for (int i = 0; i < eventsArray.Length; i++)
	{
		if(start == 0 && prevEndTime >= 0)
		{
			output.Add(new Interval(prevEndTime, eventsArray[i][0]));
		}
		
		start += eventsArray[i][1] == OPEN ? 1 : -1;
		prevEndTime = eventsArray[i][0];
	}
	
	return output;
}