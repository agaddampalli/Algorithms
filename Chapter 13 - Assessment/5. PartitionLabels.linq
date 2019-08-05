<Query Kind="Program" />

void Main()
{
	var input = "ababcbacadefegdehijhklij";
	
	PartitionLabels(input).Dump();
}

// We first find the maximum index of each character occurrence in S
// Then we iterate through S to find the partition of string where the maximum occurrence of character
// in this substring is equal to the current index of the character
// We group the substring by the first occurrence of a character and the maximum occurrence of the character
// Time Complexity: O(N) where N is the length of the string
// Space complexity: O(N) where N is the length of the string
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