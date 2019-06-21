<Query Kind="Program" />

void Main()
{
	MySqrt(8).Dump();
}

public int MySqrt(int x)
{
	long left = 0, right = x, mid = 0;

	while (left <= right)
	{
		mid = (left + right) / 2;

		long tmp = mid * mid;
		if (tmp == x)
			return (int)mid;
		else if (tmp > x)
		{
			right = mid - 1;
		}
		else if (tmp < x)
		{
			left = mid + 1;
		}
	}
	//  Console.WriteLine("left->"+left+" right->"+right);
	return (int)right;
}