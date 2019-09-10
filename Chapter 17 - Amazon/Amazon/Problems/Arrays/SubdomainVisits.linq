<Query Kind="Program" />

void Main()
{
	var cpdomains = new string[] {"900 google.mail.com", "50 yahoo.com", "1 intel.mail.com", "5 wiki.org"};
	
	SubdomainVisits(cpdomains).Dump();
}

public IList<string> SubdomainVisits(string[] cpdomains)
{
	var output = new List<string>();
	
	if(cpdomains == null || cpdomains.Length == 0)
	{
		return output;
	}
	
	var cpdomainDict = new Dictionary<string, int>();
	var temp = new StringBuilder();
	
	foreach (var cpdomain in cpdomains)
	{
		temp.Clear();
		int count = 0;
		int mul = 10;
		int i = 0;
		for (; i < cpdomain.Length; i++)
		{
			if( cpdomain[i] == ' ')
			{
				break;
			}

			var ch = cpdomain[i] - '0';
			count = count * mul + ch;
		}
		
		
		for (int j = cpdomain.Length-1; j > i; j--)
		{
			if(cpdomain[j] == '.' && temp.Length != 0)
			{
				if(!cpdomainDict.ContainsKey(temp.ToString()))
				{
					cpdomainDict.Add(temp.ToString(), 0);
				}
				
				cpdomainDict[temp.ToString()] += count;
			}
			
			temp.Insert(0, cpdomain[j]);
		}

		if (!cpdomainDict.ContainsKey(temp.ToString()))
		{
			cpdomainDict.Add(temp.ToString(), count);
		}
		else
		{
			cpdomainDict[temp.ToString()] += count;
		}
	}
	
	foreach (var cpdomain in cpdomainDict)
	{
		output.Add($"{cpdomain.Value} {cpdomain.Key}");
	}
	
	return output;
}
