<Query Kind="Program" />

void Main()
{
	var words = new List<string> {"cat","cats","catsdogcats","dog","dogcatsdog","hippopotamuses","rat","ratcatdogcat"};	
	
	GetConcatenatedStrings(words).Dump();
}

public List<IList<string>> GetConcatenatedStrings(List<string> words)
{
	var root = new Trie();
	foreach (var word in words)
	{
		root.Insert(root, word);
	}
	
	var result = new List<IList<string>>();

	
	
	foreach (var word in words)
	{
		var res = new List<string>();
		if(root.IsMatch(root, word, 0 , res, 0))
		{
			res.Add(word);
			result.Add(res);
		}
	}
	
	return result;
}

public class Trie
{
	public Trie[] Child {get; set;}

	public bool IsEnd { get; set; }
	
	public string val {get; set;}
	
	public Trie()
	{
		Child = new Trie[26];
	}
	
	public void Insert(Trie root, string word)
	{
		var node = root;
		
		for (int i = 0; i < word.Length; i++)
		{
			var ch = word[i] - 'a';
			if(node.Child[ch] == null)
			{
				node.Child[ch] = new Trie();
			}
			
			node = node.Child[ch];
		}

		node.IsEnd = true;
		node.val = word;
	}

	public bool IsMatch(Trie root, string word, int start, List<string> temp, int wordCount)
	{
		if(start == word.Length && wordCount >= 2)
		{
			return true;
		}
		
		var ends = FindEnds(root, word, start);
		for (int i = 0; i < ends.Count; i++)
		{
			if(IsMatch(root, word, ends[i].val + 1, temp, wordCount + 1))
			{
				temp.Add(ends[i].word);
				return true;
			}
		}
		
		return false;
	}
	
	public List<End> FindEnds(Trie root, string word, int start)
	{
		var node = root;
		var ends = new List<End>();
		for (int i = start; i < word.Length; i++)
		{
			var ch = word[i] - 'a';
			if (node.Child[ch] == null)
			{
				return ends;
			}

			node = node.Child[ch];
			if(node.IsEnd)
			{
				ends.Add(new End(i, node.val));
			}
		}

		return ends;
	}
}

public class End
{
	public int val {get; set;}
	
	public string word { get; set; }
	
	public End(int val, string word)
	{
		this.val = val;
		this.word = word;
	}
}
