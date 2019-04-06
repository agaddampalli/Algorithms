<Query Kind="Program" />

void Main()
{
	IsPalindrome(1).Dump();
}

public bool IsPalindromeSlow(int x)
{
	if(x < 0)
	{
		return false;
	}
	
	var inputList = new List<int>();
	
	while(x!=0)
	{
		inputList.Add(x%10);
		x = x/10;
	}

	var j = inputList.Count - 1;
	for (int i = 0; i < inputList.Count; i++)
	{
		if(inputList[i] != inputList[j-i])
		{
			return false;
		}
	}
	
	return true;
}


public bool IsPalindrome(int x)
{
	if (x < 0)
	{
		return false;
	}

	var reverseValue = 0;

	var y = x;
	while (x != 0)
	{
		reverseValue = reverseValue * 10 + x %10;
		x = x/10;
	}

	return reverseValue == y;
}