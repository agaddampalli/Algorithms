<Query Kind="Program" />

void Main()
{
	var input = new string[] {"eat", "tea", "tan", "ate", "nat", "bat"};
	
	GroupAnagrams(input).Dump();
}

public IList<IList<string>> GroupAnagrams(string[] strs)
{
	var output = new List<IList<string>>();
	
	if(strs == null || strs.Length == 0)
	{
		return output;
	}
	
	var dictionary = new Dictionary<string, List<string>>();
	
	for (int i = 0; i < strs.Length; i++)
	{
		var value = strs[i];
		value = string.Concat(value.OrderBy(c => c));
		if(dictionary.ContainsKey(value))
		{
			dictionary[value].Add(strs[i]);
		}
		else
		{
			dictionary.Add(value, new List<string> {strs[i]});
		}
	}
	
	foreach (var item in dictionary)
	{
		output.Add(item.Value);
	}
	
	return output;
}
