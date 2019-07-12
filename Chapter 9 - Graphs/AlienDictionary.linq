<Query Kind="Program" />

void Main()
{
	var words = new string[] { "wrt", "wrf", "er", "ett", "rftt" };

	AlienOrder(words).Dump();
}

public string AlienOrder(string[] words)
{

	var graph = new Dictionary<char, HashSet<char>>();
	var levels = new Dictionary<char, int>();

	BuildGraph(words, levels, graph);

	levels.Dump();
	graph.Dump();

	return string.Empty;
}

public void BuildGraph(string[] words, Dictionary<char, int> levels, Dictionary<char, HashSet<char>> graph)
{
	var root = new Trie();
	var current = root;

	for (int i = 0; i < words.Length; i++)
	{
		for (int j = 0; j < words[i].Length; j++)
		{
			var ch = words[i][j];
			var pos = ch - 'a';

			if (current.children[pos] == null)
			{
				current.children[pos] = new Trie();
			}

			if (current.val != default(char) && ch != current.val)
			{
				if (!graph.ContainsKey(current.val))
				{
					graph.Add(current.val, new HashSet<char>());
				}
				
				if (!graph[current.val].Contains(ch))
				{
					graph[current.val].Add(ch);

					if (!levels.ContainsKey(ch))
					{
						levels.Add(ch, 0);
					}

					levels[ch]++;
				}

				if (!levels.ContainsKey(current.val))
				{
					levels.Add(current.val, 0);
				}
			}
			else if (current.val == default(char))
			{
				if (!levels.ContainsKey(ch))
				{
					levels.Add(ch, 0);
				}
			}

			current.val = ch;
			current = current.children[pos];
		}

		current = root;
	}
}

public class Trie
{
	public char val { get; set; }
	public Trie[] children { get; set; }

	public Trie()
	{
		children = new Trie[26];
		val = default(char);
	}
}