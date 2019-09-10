<Query Kind="Program" />

void Main()
{
	var time = new int[] {30,20,150,100,40};

	NumPairsDivisibleBy60(time).Dump();
	NumPairsDivisibleBy601(time).Dump();
	NumPairsDivisibleBy602(time).Dump();
}

public int NumPairsDivisibleBy60(int[] time)
{
	int count = 0;
	
	for (int i = 0; i < time.Length; i++)
	{
		for (int j = i+1; j < time.Length; j++)
		{	
			var temp = time[i] + time[j];
			
			if(temp % 60 == 0)
			{
				count++;
			}
		}
	}
	
	return count;
}

public int NumPairsDivisibleBy601(int[] time)
{
	int count = 0;
	Dictionary<int, int> dict = new Dictionary<int, int>();
	
	for (int i = 0; i < time.Length; i++)
	{
		var temp = time[i] % 60;
		var key = (60 - temp) % 60;
		
		if(!dict.ContainsKey(key))
		{
			dict.Add(temp, 1);
		}
		else
		{
			count += dict[key];
		}
	}

	return count;
}

public int NumPairsDivisibleBy602(int[] time)
{
	int[] cnts = new int[60];
	int cnt = 0;
	foreach (int t in time)
	{
		cnt += cnts[(60 - t % 60) % 60];
		++cnts[t % 60];
	}
	return cnt;
}