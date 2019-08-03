<Query Kind="Program" />

void Main()
{
	var input = new int[][] { new int[] { 2, 2 }, new int[] { 2, 2 }, new int[] { 1, 1 } };

	KClosest(input, 1).Dump();
}

// If we ignore the order, we can perform partial sort of elements using quick sort
// we pick a pivot and sort all the elements smaller than this to left and greater than to right
// if the current pivot is less than k we sort the elements from pivot+1 to end
// if the current pivot is greater than k then we sort the elements from start to pivot-1
// once we find K as pivot, then all the elements before that are already partially sorted
// Time Complexity: O(N) on average
// Space  Complexity: O(N) for recursive call stack

public int[][] KClosest(int[][] input, int K)
{
	Sort(input, 0, input.Length-1, K);

	var output = new int[K][];
	for (int i = 0; i < K; i++)
	{
		output[i] = input[i];
	}

	return output;
}

public void Sort(int[][] input, int start, int end, int k)
{
	if(start >= end)
	{
		return;
	}
	
	var pivot = Partition(input, start, end);
	
	if(pivot == k)
	{
		return;
	}
	else if(pivot < k)
	{
		Sort(input, pivot + 1, end, k);
	}
	else if (pivot > k)
	{
		Sort(input, start, pivot - 1, k);
	}
}

public int Partition(int[][] input, int start, int end)
{
	var pivot = input[start];
	int index = start;

	for (int i = start + 1; i <= end; i++)
	{
		var temp = Compare(pivot, input[i]);
		if (temp > 0)
		{
			index++;
			Swap(input, index, i);
		}
	}

	Swap(input, index, start);

	return index;
}

public int Compare(int[] pointA, int[] pointB)
{
	return (pointA[0] * pointA[0] + pointA[1] * pointA[1]) - (pointB[0] * pointB[0] + pointB[1] * pointB[1]);
}

public void Swap(int[][] input, int x, int y)
{
	var temp = input[x];
	input[x] = input[y];
	input[y] = temp;
}

public int[][] KClosestNlogN(int[][] input, int K)
{
	var output = new List<int[]>();
	var source = new int[] { 0, 0 };

	if (input == null)
	{
		return output.ToArray();
	}

	var temp = new int[input.Length][];

	for (int i = 0; i < input.Length; i++)
	{
		temp[i] = new int[] { i, Distance(source, input[i]) };
	}

	Array.Sort(temp, (x, y) => x[1] - y[1]);

	for (int i = 0; i < K; i++)
	{
		output.Add(input[temp[i][0]]);
	}

	return output.ToArray();
}

public int Distance(int[] pointA, int[] pointB)
{
	return (pointA[0] - pointB[0]) * (pointA[0] - pointB[0]) + (pointA[1] - pointB[1]) * (pointA[1] - pointB[1]);
}