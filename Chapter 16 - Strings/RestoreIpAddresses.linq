<Query Kind="Program" />

void Main()
{
	RestoreIpAddresses("123456").Dump();
}

public int length;
public string ip;
public IList<string> RestoreIpAddresses(string s)
{
	var output = new List<string>();
	
	length = s.Length;
	ip = s;
	
	if(string.IsNullOrWhiteSpace(s))
	{
		return output;
	}
	
	BackTrack(0, 3, new List<string>(), output);
	
	return output;
}


public void BackTrack(int current, int dots, List<string> temp, List<string> output)
{
	var maxpositionForCurrentDot = Math.Min(length - 1, current + 4); 
	for (int i = current; i < maxpositionForCurrentDot; i++)
	{
		var segment = ip.Substring(current, i+1-current);
		if(IsValid(segment))
		{
			temp.Add(segment);
			if(dots - 1 == 0)
			{
				var last = ip.Substring(i+1);
				if(IsValid(last))
				{
					temp.Add(last);
					var ipaddress = temp.Aggregate((x, y) => x + "." + y);
					output.Add(ipaddress);
					temp.RemoveAt(temp.Count - 1);
				}
				
				temp.RemoveAt(temp.Count - 1);
			}
			else
			{
				BackTrack(i+1, dots-1, temp, output);
				temp.RemoveAt(temp.Count-1);
			}
		}
	}
}

public bool IsValid(string segment)
{
	int m = segment.Length;
	if (m > 3)
		return false;
	return (segment[0] != '0') ? Convert.ToInt32(segment) <= 255 : (m == 1);
}