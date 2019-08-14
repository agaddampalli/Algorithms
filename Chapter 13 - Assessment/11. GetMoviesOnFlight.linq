<Query Kind="Program" />

void Main()
{
	var durations = new int[] {90, 85, 75, 65, 120, 150, 125};
	
	GetMoviesOnFlight(durations, 250).Dump();
}


// Time Complexity: O(NLogN)
// Space complexity: O(N)
public int[] GetMoviesOnFlight(int[] moviesDuration, int totalDuration)
{
	Array.Sort(moviesDuration);
	
	var target = totalDuration - 30;
	var output = new List<int>();
	
	var movie1 = 0;
	var movie2 = 0;

	int start = 0;
	int end = moviesDuration.Length - 1;
	var maxDiff = int.MinValue;
	
	while(start < end)
	{
		var temp = moviesDuration[start] + moviesDuration[end];
		if(temp == target)
		{
			var diff = Math.Abs(moviesDuration[start] - moviesDuration[end]);
			if(diff > maxDiff)
			{
				movie1 = start;
				movie2 = end;
				maxDiff = diff ;
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

	output.Add(movie1);
	output.Add(movie2);
	
	return output.ToArray();
}