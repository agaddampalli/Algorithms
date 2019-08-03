<Query Kind="Program" />

void Main()
{
	var forwardRouteList = new int[,] { { 1, 3000 }, { 2, 5000 }, { 3, 7000 }, { 4, 10000 } };
	var returnRouteList = new int[,] { { 1, 2000 }, { 2, 4000 }, { 3, 4000 }, { 4, 5000 } };
	
	FindOptimumRoute(10000, forwardRouteList, returnRouteList).Dump();
}

// Time Complexity: O(mn) m- forward route list length, n - return route list
// Space complexity: O(2)
public List<IList<int>> FindOptimumRoute(int maxTravelDist, int[,] forwardRouteList, int[,] returnRouteList)
{
	var result = new List<IList<int>>();
	var previousMax = int.MinValue;
	for (int i = 0; i < forwardRouteList.GetLength(0); i++)
	{
		var currentMax = int.MinValue;
		var currentList = new List<IList<int>>();
		
		for (int j = 0; j < returnRouteList.GetLength(0); j++)
		{
			var dist = forwardRouteList[i,1] + returnRouteList[j,1];
			
			if(dist > maxTravelDist || dist < currentMax)
			{
				continue;
			}
			
			if(dist > currentMax)
			{
				currentMax = dist;
				currentList = new List<IList<int>> { new List<int> { forwardRouteList[i, 0], returnRouteList[j, 0] }};
			}
			else
			{
				currentList.Add(new List<int> { forwardRouteList[i, 0], returnRouteList[j, 0] });
			}
		}
		
		if(currentMax > previousMax)
		{
			result = currentList;
			previousMax = currentMax;
		}
		else if(currentMax == previousMax)
		{
			result.AddRange(currentList);
		}
	}
	
	return result;
}