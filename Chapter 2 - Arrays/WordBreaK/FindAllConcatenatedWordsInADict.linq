<Query Kind="Program" />

void Main()
{
	var words = new string[]{"cat","cats","catsdogcats", "dog"};
	
	FindAllConcatenatedWordsInADict(words).Dump();
}

public IList<string> FindAllConcatenatedWordsInADict(string[] words)
{
	var output = new List<string>();
	
	var root = new Trie();
	
	for (int i = 0; i < words.Length; i++)
	{
		root.Add(root, words[i]);
	}

	for (int i = 0; i < words.Length; i++)
	{
		if(root.Match(root, words[i], 0, 0))
		{
			output.Add(words[i]);
		}
	}
	
	return output;
}


public class Trie
{
	public Trie[] children { get; set; }
	public string value { get; set; }
	public bool end {get; set;}
	
	public Trie()
	{
		children = new Trie[26];
	}
	
	public void Add(Trie root, string word)
	{
		var node = root;
		for (int i = 0; i < word.Length; i++)
		{
			if(node.children[word[i]-'a'] == null)
			{
				node.children[word[i]-'a'] = new Trie();
			}
			
			node = node.children[word[i]-'a'];
		}

		node.value = word;
		node.end = true;
	}

	public bool Match(Trie root, string word, int start, int wordCount)
	{
		if(start >= word.Length)
		{
			return wordCount >= 2;
		}
		
		var node = root;
		
		var ends = FindEnds(root, word, start);
		
		for (int i = ends.Count-1; i >= 0; i--)
		{
			if(Match(root, word, ends[i] + 1, wordCount + 1))
			{
				return true;
			}
		}

		return false;
	}
	
	public IList<int> FindEnds(Trie root, string word, int start)
	{
		var ends = new List<int>();
		var node = root;
		for (int i = start; i < word.Length; i++)
		{
			var child = node.children[word[i] - 'a'];
			if (child == null)
			{
				return ends;
			}

			node = child;

			if (node.end)
			{
				ends.Add(i);
			}
		}

		return ends;
	}
}