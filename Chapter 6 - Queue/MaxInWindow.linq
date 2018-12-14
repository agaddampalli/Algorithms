<Query Kind="Program" />

void Main()
{
	var input = new int[]{8, 5, 10, 7, 9, 4, 15, 12, 90, 13};
	PrintMaximums(input, 2);
}


public static void PrintMaximums(int[] input, int windowSize)
{
	int i = 0;
	int j = 1;
	int end = windowSize;
	int max = 0;
	
	var output = new List<int>();
	
	while(j != input.Length)
	{
		max = input[i];
		while(j-i != windowSize && j != input.Length)
		{
			if (max < input[j])
			{
				max = input[j];
			}
			
			j++;
		}
		
		output.Add(max);
		
		if(j != input.Length)
		{
			i++;
			j = i + 1;
		}	
	}
	
	output.Dump();
}
