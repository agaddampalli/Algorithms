<Query Kind="Program" />

void Main()
{
	var input = new int[]{1,2,3,4,5,6};
	
	// 1 2 3 4 5 6
	// 6 5 4 3 2 1
	// 1 2 3 6 5 4
	// 6 5 4 3 1 2
	
	FindArrayType(input).Dump();
}

public string FindArrayType(int[] input)
{
	
	FindArrayType(input, 0, input.Length-1);
	
	return string.Empty;
}


public int FindArrayType(int[] input, int start, int end)
{
	if(start > end)
	{
		return 0;
	}
	
	var mid = (start+end)/2;

	var left = FindArrayType(input, start, mid - 1);
	var right = FindArrayType(input, mid+1, end);


	return 0;
}