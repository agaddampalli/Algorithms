<Query Kind="Program" />

void Main()
{
	var input = "ababcbacadefegdehijhklij";
	
	PartitionLabels(input).Dump();
}

public IList<int> PartitionLabels(string S)
{
	var temp = new int[26];
	var output = new List<int>();
	for (int i = 0; i < S.Length; i++)
	{
		temp[S[i]- 'a'] = i;
	}
	
	var j = int.MinValue;
	int startIndex = 0;
	for (int i = 0; i < S.Length; i++)
	{
		j = Math.Max(j, temp[S[i]-'a']);
		
		if(i == j)
		{
			output.Add(i-startIndex+1);
			startIndex = i+1;
		}
	}
	
	return output;
}
