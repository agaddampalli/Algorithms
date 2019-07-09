<Query Kind="Program" />

void Main()
{
	var input = new int[][] {
								  new int[] {3,3},
								  new int[] {5,-12},
								  new int[] {-2,4},
								  new int[] {0,5},
								  new int[] {9,-4},
								  new int[] {-22,6}};
								  
	FindKMimimumDistPoints(input, new int[] {1, -2}, 4).Dump();
}

public int[][] FindKMimimumDistPoints(int[][] input,int[] source, int k)
{
	var output = new List<int[]>();
	
	if(input == null)
	{
		return output.ToArray();
	}

	var temp = new int[input.Length][];
	
	for (int i = 0; i < input.Length; i++)
	{
		temp[i] = new int[] { i, Distance(source, input[i])};
	}
	
	Array.Sort(temp, (x,y) => x[1]-y[1]);
	
	for (int i = 0; i < k; i++)
	{
		output.Add(input[temp[i][0]]);
	}
	
	return output.ToArray();
}

public int Distance(int[] pointA, int[] pointB)
{
	return (pointA[0] - pointB[0])*(pointA[0] - pointB[0]) + (pointA[1] - pointB[1]) * (pointA[1] - pointB[1]);
}