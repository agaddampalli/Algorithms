<Query Kind="Program" />

void Main()
{
	var activities = new int[][] { new int[] {20, 30},new int[] {12, 25}, new int[] {10, 20}, new int[] {15, 17}, new int[] {5, 10}  };
	
	GetMaximumActivities(activities).Dump();
}

public List<IList<int>> GetMaximumActivities(int[][] activities)
{
	var output = new List<IList<int>>();
	
	Array.Sort(activities, (x,y) => x[1]-y[1]);
	
	activities.Dump();
	
	var length = activities.GetLength(0);
	
	output.Add(activities[0]);
	var index = 0;
	for (int i = 1; i < length; i++)
	{
		if(activities[index][1] <= activities[i][0])
		{
			output.Add(activities[i]);
			index++;
		}
	}
	
	return output;
}
