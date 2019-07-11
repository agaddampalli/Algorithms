<Query Kind="Program" />

void Main()
{
	var input = new List<int> {-1,0,3,5,9,12};
	
	search(input, 9).Dump();
}

public int search(List<int> reader, int target)
{
	var low = 0;
	var high = 2;
	
	while(low < high)
	{
		if(reader[low] == target)
		{
			return low;
		}
		else if(reader[high] == target)
		{
			return high;
		}
		else if(reader[high] < target)
		{
			low++;
			high = high * 2 > 10000 ? 10000 : high * 2;
		}
		else
		{
			high = (low + high)/2;
		}
	}
	
	
	return -1;
}
