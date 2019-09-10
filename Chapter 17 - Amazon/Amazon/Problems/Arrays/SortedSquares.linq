<Query Kind="Program" />

void Main()
{
	var nums = new int[] {-4,-1,0,3,10};
	
	SortedSquares(nums).Dump();
}

//https://leetcode.com/problems/squares-of-a-sorted-array/submissions/
public int[] SortedSquares(int[] A)
{
	int start = 0;
	int end = A.Length - 1;
	int[] result = new int[A.Length];

	for (int i = A.Length - 1; i >= 0; i--)
	{
		int s = Math.Abs(A[start]);
		int e = Math.Abs(A[end]);

		if (s > e)
		{
			result[i] = s * s;
			start++;

		}
		else
		{
			result[i] = e * e;
			end--;
		}

	}

	return result;
}
