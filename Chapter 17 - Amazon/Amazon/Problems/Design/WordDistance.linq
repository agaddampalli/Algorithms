<Query Kind="Program" />

void Main()
{

}

public class WordDistance
{
	private Dictionary<string, List<int>> dict;

	public WordDistance(string[] words)
	{
		dict = new Dictionary<string, List<int>>();

		for (int i = 0; i < words.Length; i++)
		{
			if (!dict.ContainsKey(words[i]))
			{
				dict.Add(words[i], new List<int>());
			}

			dict[words[i]].Add(i);
		}
	}

	public int Shortest(string word1, string word2)
	{
		var word1Indices = dict[word1];
		var word2Indices = dict[word2];

		var minDiff = int.MaxValue;
		var firstIndex = 0;
		var secondIndex = 0;

		while (firstIndex < word1Indices.Count && secondIndex < word2Indices.Count)
		{
			minDiff = Math.Min(minDiff, Math.Abs(word1Indices[firstIndex] - word2Indices[secondIndex]));

			if (word1Indices[firstIndex] > word2Indices[secondIndex])
			{
				secondIndex++;
			}
			else
			{
				firstIndex++;
			}
		}

		return minDiff;
	}
}
