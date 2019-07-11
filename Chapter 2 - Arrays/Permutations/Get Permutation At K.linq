<Query Kind="Program" />

void Main()
{
	GetPermutation(4,9).Dump();
}

public int count = 0;
public string GetPermutation(int n, int k)
{
	return Permute(n, k, new List<int>(), new bool[n]);
}

public string Permute(int n, int k, List<int> temp, bool[] used)
{
	if(temp.Count == n)
	{
		count++;
		
		if(count == k)
		{
			var res = string.Empty;
			for (int i = 0; i < temp.Count; i++)
			{
				res += temp[i].ToString();
			}
			
			return res;
		}
		
		return null;
	}
	
	for (int i = 1; i <= n; i++)
	{
		if(used[i-1])
			continue;
			
		temp.Add(i);
		used[i-1] = true;
		
		var res = Permute(n, k, temp, used);
		
		if(string.IsNullOrWhiteSpace(res))
		{
			used[i-1] = false;
			temp.RemoveAt(temp.Count - 1);
		}
		else
		{
			return res;
		}
	}
	
	return null;
}