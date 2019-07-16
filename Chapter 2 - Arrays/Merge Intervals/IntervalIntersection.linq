<Query Kind="Program" />

void Main()
{
	var a = new int[][] { new int[] { 0, 2 }, new int[] { 5, 10 }, new int[] { 13, 23 }, new int[] { 24, 25 } };
	var b = new int[][] { new int[] { 1, 5 }, new int[] { 8, 12 }, new int[] { 15, 24 }, new int[] { 25, 26 } };
	
	IntervalIntersection(a,b).Dump();
}

public int[][] IntervalIntersection(int[][] A, int[][] B)
{
	int i =0, j =0;

	var output = new List<int[]> {};
	
	while(i < A.Length && j < B.Length)
	{
		var start = Math.Max(A[i][0], B[j][0]);
		var end = Math.Min(A[i][1], B[j][1]);
		
		if(start <= end)
		{
			output.Add(new int[] {start, end});
		}
		
		if(A[i][1] < B[j][1])
		{
			i++;
		}
		else
		{
			j++;
		}
	}
	
	return output.ToArray();
}