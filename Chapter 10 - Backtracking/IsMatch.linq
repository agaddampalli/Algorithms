<Query Kind="Program" />

void Main()
{
	var s = "aa";
	var p = "*";
	
	IsMatch(s,p).Dump();
}

public bool IsMatch(string s, string p)
{
	return IsMatch(s, p, 0, 0);
}

public bool IsMatch(string s, string p, int sindex, int pindex)
{
	if(sindex == s.Length && pindex == p.Length)
	{
		return true;
	}
	else if(pindex == p.Length)
	{
		return false;
	}
	
	if(p[pindex] == '*')
	{
		if(pindex + 1 < p.Length && p[pindex+1] == s[sindex])
		{
			pindex++;
			return IsMatch(s, p, ++sindex, ++pindex);
		}
		
		return IsMatch(s, p, ++sindex, pindex);
	}

	if (p[pindex] == '?')
	{
		return IsMatch(s, p, ++sindex, ++pindex);
	}

	if( p[pindex] == s[sindex])
	{
		return IsMatch(s, p, ++sindex, ++pindex);
	}
	
	return false;
}