<Query Kind="Program" />

void Main()
{
	var items = new int[][] { new int[] { 1, 10 }, new int[] { 2, 20 }, new int[] { 1, 30 }, new int[] {2, 10}};
	
	HighFive(items).Dump();
}

//https://leetcode.com/problems/high-five/
public int[][] HighFive(int[][] items)
{
	Array.Sort(items, (x,y) => y[1]-x[1]);
	
	var output = new List<int[]>();
	var dictionary = new Dictionary<int, int[]>();
	
	for (int i = 0; i < items.Length; i++)
	{
		if(!dictionary.ContainsKey(items[i][0]))
		{
			dictionary.Add(items[i][0], new int[] { 1, items[i][1]});
		}
		else if(dictionary[items[i][0]][0] < 5)
		{
			dictionary[items[i][0]][0]++;
			dictionary[items[i][0]][1] +=  items[i][1];
			
			if(dictionary[items[i][0]][0] == 5)
			{
				var average = dictionary[items[i][0]][1]/5;
				output.Add(new int[]{items[i][0], average});
			}
		}
	}
	
	var temp = output.ToArray();
	
	Array.Sort(temp, (x,y) => x[0]-y[0]);
	
	return temp;
}

public int[][] HighFive1(int[][] items)
{
	Array.Sort(items, (x,y) => y[1]-x[1]);
	
	var output = new List<int[]>();
	var dictionary = new Dictionary<int, int[]>();
	
	for (int i = 0; i < items.Length; i++)
	{
		if(!dictionary.ContainsKey(items[i][0]))
		{
			dictionary.Add(items[i][0], new int[] { 1, items[i][1]});
		}
		else if(dictionary[items[i][0]][0] < 5)
		{
			dictionary[items[i][0]][0]++;
			dictionary[items[i][0]][1] +=  items[i][1];
			
			if(dictionary[items[i][0]][0] == 5)
			{
				var average = dictionary[items[i][0]][1]/5;
				output.Add(new int[]{items[i][0], average});
			}
		}
	}
	
	var temp = output.ToArray();
	
	Array.Sort(temp, (x,y) => x[0]-y[0]);
	
	return temp;
}