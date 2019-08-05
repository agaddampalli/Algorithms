<Query Kind="Program" />

void Main()
{
	var durations = new int[] { 803,468,292,154,924,424,197,277,753,86,984,144,105,450,287,265,655,404,407,794,513,976,241,272,84,503,65,654,805,413,362,907,297,473,113,567,646,607,806,674,424,753,870,574,765,170,603,696,513,58};

	TwoSumLessThanK(durations, 300).Dump();
}

public int TwoSumLessThanK(int[] A, int K)
{
	Array.Sort(A);

	int i = 0;
	int j = A.Length - 1;

	var maxSum = -1;
	var minDiff = int.MaxValue;
	
	while (i < j)
	{
		var temp = A[i] + A[j];

		if (temp == K-1)
		{
			return temp;
		}
		else if(temp < K-1)
		{
			var diff = K - temp;
			if (diff < minDiff)
			{
				minDiff = diff;
				maxSum = temp;
			}

			i++;
		}
		else
		{
			j--;
		}
	}

	return maxSum;
}