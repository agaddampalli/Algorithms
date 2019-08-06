<Query Kind="Program" />

void Main()
{
	var strs = new List<string> {""};
	
	var output = Encode(strs);
	
	output.Dump();
	
	var strs1 = Decode(output).Dump();
}

public string Encode(IList<string> strs)
{
	if(strs == null || strs.Count == 0)
	{
		return null;
	}
	
	var delimiter = "%^&**901";
	var output = new StringBuilder();

	int count = 0;
	foreach (var element in strs)
	{
		count++;
		output.Append(element);
		if (count != strs.Count)
		{
			output.Append(delimiter);
		}
	}

	return output.ToString();
}

// Decodes a single string to a list of strings.
public IList<string> Decode(string s)
{
	if(s == null)
	{
		return new List<string>();
	}
	
	var delimiter = "%^&**901";
	return s.Split(new string[]{delimiter}, StringSplitOptions.None);;
}
