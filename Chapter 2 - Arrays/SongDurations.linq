<Query Kind="Program" />

void Main()
{
	// 2 3 4 5 7 8

	// 12 

	// 10 

	var input = new List<int> {1, 10, 25, 30, 35,20,40, 60};
	
	IDsOfSongs(90, input).Dump();

}

public List<int> IDsOfSongs(int rideDuration, List<int> songDurations)
{
	var playlistDict = new Dictionary<int, int>();
	var songs = new List<int>();

	var target = rideDuration - 30;

	for (int i = 0; i < songDurations.Count; i++)
	{
		playlistDict.Add(songDurations[i], i);
	}

	for (int i = 0; i < songDurations.Count; i++)
	{
		var temp = target - songDurations[i];
		if (playlistDict.ContainsKey(temp) && playlistDict[temp] != i)
		{
			songs.Add(songDurations[i]);  
			songs.Add(temp);
		}
	}
	
	int max = int.MinValue;
	
	for (int i = 0; i < songs.Count; i++)
	{
		if(max < songs[i])
		{
			max = songs[i];
		}
	}
	
	var result = new List<int>();

	result.Add(playlistDict[target - max]);
	result.Add(playlistDict[max]);

	return result;
}