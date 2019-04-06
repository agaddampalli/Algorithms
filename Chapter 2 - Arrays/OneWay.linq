<Query Kind="Program" />

void Main()
{
	Oneway("Pale", "ple").Dump();
	Oneway1("bake", "bke").Dump();
}

public bool Oneway(string str1, string str2)
{
	string maxString;
	string minString;
	
	if(str1.Length >= str2.Length)
	{
		maxString = str1.ToLower();
		minString = str2.ToLower();
	}
	else
	{
		maxString = str2.ToLower();
		minString = str1.ToLower();
	}
	
	var hashset = new HashSet<char>();
	for (int i = 0; i < maxString.Length; i++)
	{
		hashset.Add(maxString[i]);
	}
	
	for (int i = 0; i < minString.Length; i++)
	{
		if(hashset.Contains(minString[i]))
		{
			hashset.Remove(minString[i]);
		}
		else
		{
			hashset.Add(minString[i]);
		}
	}
	
	return hashset.Count > 2 ? false : true;
}


public bool Oneway1(string str1, string str2)
{
	if(str1.Length == str2.Length)
	{
		return Removal(str1, str2);
	}
	else if(str1.Length + 1 == str2.Length)
	{
		return OneInsertion(str1, str2);
	}
	else if (str1.Length - 1 == str2.Length)
	{
		return OneInsertion(str2, str1);
	}
	
	return false;
}

public bool Removal(string str1, string str2)
{
	bool foundOne = false;
	
	for (int i = 0; i < str1.Length; i++)
	{
		if(str1[i] != str2[i])
		{
			if(foundOne)
			{
				return false;
			}
			
			foundOne = true;
		}
	}
	
	return true;
}

public bool OneInsertion(string str1, string str2)
{
	var i =0;
	var j= 0;
	
	while(i< str1.Length && j < str2.Length)
	{
		// apple aple
		// bake tyu
		if(str1[i] != str2[j])
		{
			if(i != j)
			{
				return false;
			}
			
			j++;
		}
		else
		{
			i++;
			j++;
		}
	}
	
	return true;
	
}

