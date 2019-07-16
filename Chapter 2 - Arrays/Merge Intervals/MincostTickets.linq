<Query Kind="Program" />

void Main()
{
	var days = new int[] { 1, 4, 6, 7, 8, 20 };
	var costs = new int[] { 2,7,15};
	
	MincostTickets(days, costs).Dump();
}

public int MincostTickets(int[] days, int[] costs)
{
	var hashset = new HashSet<int>(days);
	var cache = new int[366];
	
	return MincostTickets(hashset, costs, cache, 1);
	
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