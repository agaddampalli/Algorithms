<Query Kind="Program" />

void Main()
{
	var logs = new string[] { "a1 9 2 3 1", "g1 act car", "zo4 4 7", "ab1 off key dog", "a8 act zoo" };

	ReorderLogFiles(logs).Dump();
}

// Merge sort
// Time Compelxity: O(NLogN) where N is content of logs
// Space Complexity: O(N)
public string[] ReorderLogFiles(string[] logs)
{
	Sort(0, logs.Length - 1, logs);
	return logs;
}

public void Sort(int start, int end, string[] logs)
{
	if (start < end)
	{
		var mid = (start + end) / 2;
		Sort(start, mid, logs);
		Sort(mid + 1, end, logs);
		Merge(start, mid, end, logs);
	}
}

public void Merge(int start, int mid, int end, string[] logs)
{
	var leftArray = new string[mid - start + 1];
	var rightArray = new string[end - mid];

	Array.Copy(logs, start, leftArray, 0, mid - start + 1);
	Array.Copy(logs, mid + 1, rightArray, 0, end - mid);

	int x = 0;
	int y = 0;
	for (int i = start; i < end + 1; i++)
	{
		if (x == leftArray.Length)
		{
			logs[i] = rightArray[y];
			y++;
		}
		else if (y == rightArray.Length)
		{
			logs[i] = leftArray[x];
			x++;
		}
		else if (IsLesser(leftArray[x], rightArray[y]))
		{
			logs[i] = leftArray[x];
			x++;
		}
		else
		{
			logs[i] = rightArray[y];
			y++;
		}
	}
}

public bool IsLesser(string left, string right)
{
	var split1 = left.Split(' ');
	var split2 = right.Split(' ');
	bool isDigit1 = IsDigit(split1[1][0]);
	bool isDigit2 = IsDigit(split2[1][0]);
	
	if (!isDigit1 && !isDigit2)
	{
		var cmp = split1[1].CompareTo(split2[1]);
		if (cmp != 0) return cmp == -1 ? true : false;
		return split1[0].CompareTo(split2[0]) == -1 ? false : true;
	}
	
	return isDigit1 ? (isDigit2 ? true : false) : true;
}

public bool IsDigit(char ch)
{
	return ch >= '0' && ch <= '9';
}