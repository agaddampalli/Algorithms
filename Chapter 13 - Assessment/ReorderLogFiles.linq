<Query Kind="Program" />

void Main()
{

}

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
	var leftArray = left.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
	var rightArray = right.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

	var leftCondition = leftArray.Length > 1 && leftArray[1].Length > 0 && leftArray[1][0] > 47 && leftArray[1][0] < 58;
	var rightCOndition = rightArray.Length > 1 && rightArray[1].Length > 0 && rightArray[1][0] > 47 && rightArray[1][0] < 58;
	if (leftCondition && rightCOndition)
	{
		return true;
	}
	else if (leftCondition)
	{
		return false;
	}
	else if (rightCOndition)
	{
		return true;
	}

	int i = 1;
	int j = 1;
	while (i < leftArray.Length || j < rightArray.Length)
	{
		var leftString = i < leftArray.Length ? leftArray[i++] : null;
		var rightString = j < rightArray.Length ? rightArray[j++] : null;
		var result = string.Compare(leftString, rightString);

		if (result == -1)
		{
			return true;
		}
		else if (result == 1)
		{
			return false;
		}
	}

	var result1 = string.Compare(leftArray[0], rightArray[0]);

	if (result1 <= 0)
	{
		return true;
	}
	else
	{
		return false;
	}
}
