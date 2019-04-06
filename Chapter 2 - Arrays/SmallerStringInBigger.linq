<Query Kind="Program" />

void Main()
{
	FindSmallerString("abc", "abcbbacbabcaccb").Dump();
	"****************************************".Dump();
	FindSmallerString1("abc", "abcbbacbabcaccb").Dump();
}

public List<List<int>> FindSmallerString(string s, string b)
{
	var result = new List<List<int>>();
	
	int i = 0;
	while(i + s.Length <= b.Length)
	{
		if(i+s.Length < b.Length)
		{
			var hasNotFound = false;
			var subString = b.Substring(i, s.Length);
			for (int j = 0; j < s.Length; j++)
			{
				var index = subString.IndexOf(s[j]);
				if(index == -1)
				{
					i = i + s.Length;
					hasNotFound = true;
					break;
				}
			}

			if(!hasNotFound)
			{
				result.Add(new List<int> { i, i + s.Length });
				i++;
			}
		}
	}
	
	return result;
}

public List<List<int>> FindSmallerString1(string s, string b)
{
	var result = new List<List<int>>();

	int M = s.Length; 
    int N = b.Length; 
  
    // countP[]: Store count of all  
    // characters of pattern  
    // countTW[]: Store count of current  
    // window of text  
    char[] countP = new char[256]; 
    char[] countTW = new char[256]; 
    for (int i = 0; i < M; i++) 
    { 
        (countP[s[i]])++; 
        (countTW[b[i]])++; 
    }

	for (int i = M; i < N; i++)
	{
		if(compareCount(countP, countTW))
		{
			result.Add(new List<int> {i-M, i});
		}

		(countTW[b[i]])++;
		
		(countTW[b[i-M]])--;
	}

	if (compareCount(countP, countTW))
	{
		result.Add(new List<int> { N - M, N });
	}

	return result;
}

public bool compareCount(char[] a, char[] b)
{
	for (int i = 0; i < 256; i++)
	{
		if(a[i] != b[i])
		{
			return false;
		}
	}
	
	return true;
}