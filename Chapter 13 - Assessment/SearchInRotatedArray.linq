<Query Kind="Program" />

void Main()
{
	
}

public static void searchRotate()
{
	var a = new int[]{ 6, 7, 8, 1, 2, 3, 4, 5 };
	int lt = 0, rt = a.Length - 1, mid = 0;
	int find = 3;
	bool found = false;
	while (lt <= rt)
	{
		mid = (lt + rt) / 2;
		if (a[mid] == find)
		{
			found = true;
			break;
		}
		if (a[mid] <= a[rt])
		{
			if (find > a[mid] && find <= a[rt])
			{
				lt = mid + 1;
			}
			else
			{
				rt = mid - 1;
			}
		}
		else if (a[lt] <= a[mid])
		{
			if (find > a[lt] && find <= a[mid])
			{
				rt = mid - 1;
			}
			else
			{
				lt = mid + 1;
			}
		}
	}

	if (!found)
}
