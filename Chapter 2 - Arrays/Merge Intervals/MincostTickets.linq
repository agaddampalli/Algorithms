<Query Kind="Program" />

void Main()
{
	var days = new int[] { 1, 4, 6, 7, 8, 20 };
	var costs = new int[] { 2,7,15};

	MincostTickets(days, costs).Dump();
	MincostTicketsDP(days, costs).Dump();
}

public int MincostTickets(int[] days, int[] costs)
{
	var hashset = new HashSet<int>(days);
	var cache = new int[366];
	
	return MincostTickets(hashset, costs, cache, 1);
	
}

public int MincostTicketsDP(int[] days, int[] costs)
{
	var lastTravelDay = days[days.Length-1];
	
	var dp = new int[lastTravelDay + 1];
	var travelDay = new bool[lastTravelDay+1];
	
	for (int i = 0; i < days.Length; i++)
	{
		travelDay[days[i]] = true;
	}
	
	dp[0] = 0;
	
	for (int i = 1; i <= lastTravelDay; i++)
	{
		if(!travelDay[i])
		{
			dp[i] = dp[i-1];
			continue;
		}

		dp[i] = dp[i - 1] + costs[0];
		dp[i] = Math.Min(dp[Math.Max(i - 7, 0)] + costs[1], dp[i]);
		dp[i] = Math.Min(dp[Math.Max(i - 30, 0)] + costs[2], dp[i]);
	}
	
	return dp[lastTravelDay];
}

public int MincostTickets(HashSet<int> days, int[] costs, int[] cache, int day)
{
	if(day > 365)
	{
		return 0;
	}
	
	if(cache[day] != 0)
	{
		return cache[day];
	}
	
	int ans = int.MaxValue;
	if(days.Contains(day))
	{
		var day1Pass = MincostTickets(days, costs, cache, day + 1) + costs[0];
		var day7Pass = MincostTickets(days, costs, cache, day + 7) + costs[1];
		ans = Math.Min(day1Pass, day7Pass);

		var day30Pass = MincostTickets(days, costs, cache, day + 30) + costs[2];
		ans = Math.Min(ans, day30Pass);
	}
	else
	{
		ans = MincostTickets(days, costs, cache, day + 1);
	}
	
	cache[day] = ans;
	
	return cache[day];
}