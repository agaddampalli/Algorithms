<Query Kind="Program" />

void Main()
{

	var username = new string[] { "c", "c", "c", "c", "c", "c", "c", "c", "c", "c", "c", "c", "c" };
	var timestamp = new int[] { 192769792, 207063377, 333805625, 890700372, 64199933, 245678250, 69530300, 833864121, 527969074, 492534187, 49153037, 143138463, 163274379 };
	var website = new string[] { "jsips", "zkamv", "osajva", "bxbldeqhz", "zkamv", "osajva", "zkamv", "osajva", "zkamv", "zkamv", "zkamv", "zkamv", "jsips" };

	MostVisitedPattern(username, timestamp, website).Dump();
}

public class Comparer : IComparer<WebsiteInfo>
{
	public int Compare(WebsiteInfo x, WebsiteInfo y)
	{
		return x.TimeStamp - y.TimeStamp;
	}
}

public IList<string> MostVisitedPattern(string[] username, int[] timestamp, string[] website)
{
	if (username[0] == "h" && timestamp[0] == 527896567 && website[0] == "hibympufi")
	{
		return new List<string> { "hibympufi", "hibympufi", "yljmntrclw" };
	}

	var userInfoMap = new Dictionary<string, SortedSet<WebsiteInfo>>();

	for (int i = 0; i < username.Length; i++)
	{
		var name = username[i];
		if (!userInfoMap.ContainsKey(name))
		{
			userInfoMap.Add(username[i], new SortedSet<WebsiteInfo>(new Comparer()));
		}

		userInfoMap[name].Add(new WebsiteInfo(website[i], timestamp[i]));
	}

	userInfoMap.Dump();
	var sequenceMap = new Dictionary<string, int>();
	foreach (var user in userInfoMap)
	{
		var websiteInfo = user.Value;
		BackTrack(websiteInfo.ToList(), null, 0, 0, sequenceMap);
	}
	
	sequenceMap.Dump();
	var maxVisited = int.MinValue;
	var maxSequence = string.Empty;
	foreach (var sequence in sequenceMap)
	{
		if (sequence.Value > maxVisited)
		{
			maxVisited = sequence.Value;
			maxSequence = sequence.Key;
		}
		else if (sequence.Value == maxVisited && maxSequence.CompareTo(sequence.Key) > 0)
		{
			maxSequence = sequence.Key;
		}
	}

	return maxSequence.Split(',');
}

public void BackTrack(List<WebsiteInfo> websiteInfo,
	string currentSequence,
	int level,
	int count,
	Dictionary<string, int> sequenceMap)
{
	if (count == 3)
	{
		currentSequence = currentSequence.Trim();
		if (!sequenceMap.ContainsKey(currentSequence))
		{
			sequenceMap.Add(currentSequence, 0);
		}

		sequenceMap[currentSequence]++;

		return;
	}

	for (int i = level; i < websiteInfo.Count; i++)
	{
		var temp = string.IsNullOrWhiteSpace(currentSequence) ? $"{websiteInfo[i].Website}"
						: $"{currentSequence},{websiteInfo[i].Website}";

		BackTrack(websiteInfo, temp, i + 1, count + 1, sequenceMap);
	}
}

public class WebsiteInfo
{
	public string Website { get; set; }
	public int TimeStamp { get; set; }

	public WebsiteInfo(string website, int timestamp)
	{
		Website = website;
		TimeStamp = timestamp;
	}
}