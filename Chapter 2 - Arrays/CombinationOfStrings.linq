<Query Kind="Program" />

void Main()
{
	Permutation("ABCD","");
}


public void Permutation(string str, string prefix)
{
	if(str.Length == 0)
	{	
		prefix.Dump();
	}
	else
	{
		
		for (int i = 0; i < str.Length; i++)
		{
			var rem = str.Substring(0,i) + str.Substring(i+1);
			Permutation(rem, prefix + str[i]);
		}
	}
	
}