<Query Kind="Program" />

void Main()
{
	UniqueString("abc").Dump();
}

public bool UniqueString(string input)
{
	bool[] charArray = new bool[256];
	
	for (int i = 0; i < input.Length; i++)
	{
		if(charArray[input[i]])
		{
			return false;
		}
		
		charArray[input[i]] = true;
	}
	
	return true;
}
