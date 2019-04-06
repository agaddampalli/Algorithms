<Query Kind="Program" />

void Main()
{
	CheckPermutation("abc", "acb").Dump();
	CheckPermutation1("cba", "abc").Dump();
}

public bool CheckPermutation1(string str1, string str2)
{
	if(str1.Length != str2.Length)
	{
		return false;
	}
	
	char[] str1Chars = new char[256];
	for (int i = 0; i < str1.Length; i++)
	{
		(str1Chars[str1[i]])++;
	}

	for (int i = 0; i < str1.Length; i++)
	{
		if(!(str1Chars[str2[i]] > 0))
		{
			return false;
		}
	}

	return true;
}

public bool CheckPermutation(string str1, string str2)
{
	char[] str1Chars = new char[256];
	char[] str2Chars = new char[256];

	string maxString = null;
	string minString = null;
	if (str1.Length > str2.Length)
	{
		maxString = str1;
		minString = str2;
	}
	else
	{
		maxString = str2;
		minString = str1;
	}

	for (int i = 0; i < minString.Length; i++)
	{
		(str1Chars[minString[i]])++;
		(str2Chars[maxString[i]])++;
	}

	for (int i = minString.Length; i < maxString.Length; i++)
	{
		if (Compare(str1Chars, str2Chars))
		{
			return true;
		}

		(str2Chars[maxString[i]])++;
		(str2Chars[maxString[i - minString.Length]])--;
	}

	if (Compare(str1Chars, str2Chars))
	{
		return true;
	}

	return false;
}

public bool Compare(char[] array1, char[] array2)
{
	for (int i = 0; i < 256; i++)
	{
		if (array1[i] != array2[i])
		{
			return false;
		}
	}

	return true;
}