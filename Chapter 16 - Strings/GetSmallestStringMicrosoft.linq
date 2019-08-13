<Query Kind="Program" />

void Main()
{
	GetSmallestStringMicrosoft("cb").Dump();
}

public string GetSmallestStringMicrosoft(string s)
{
	var smallest = s.Substring(1);
	for (int i = 1; i < s.Length; i++)
	{
		var temp = s.Substring(0, i) + s.Substring(i+1);
		
		if(temp.CompareTo(smallest) == -1)
		{
			smallest = temp;
		}
	}
	
	return smallest;
}
