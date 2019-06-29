<Query Kind="Program" />

void Main()
{
	ConvertToTitle(3380).Dump();
	TitleToNumber("DYZ").Dump();
}

//26             Z
//51             AY
//52             AZ
//80             CB
//676            YZ
//702            ZZ
//705            AAC
 
public string ConvertToTitle(int n)
{
	var output = new StringBuilder();
	
	while(n > 0)
	{
		var rem = n % 26;
		if(rem == 0)
		{
			output.Append('Z');
			n = (n/26)-1;
		}
		else
		{
			output.Append((char)((rem - 1) + 'A'));
			n = (n/26);
		}
	}
	
	return new String(output.ToString().Reverse().ToArray());
}

public int TitleToNumber(string s)
{
	
//	if(s.Length == 1)
//	{
//		return (s[0]-65+1);
//	}
//	
	int res = 0;
	int mult = 1;
	for (int i = s.Length-1; i >=0; i--)
	{
		res = res + (s[i] - 65 + 1) * mult;
		mult = mult * 26;
	}
	
	return res;
}

