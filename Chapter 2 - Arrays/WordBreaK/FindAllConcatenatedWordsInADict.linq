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
		if(root.Match(root, words[i]))
		{
			output.Add(words[i]);
		}
	}
	
	root.Find(root, "cat").Dump();
	
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

	public bool Find(Trie root, string word)
	{
		var node = root;
		for (int i = 0; i < word.Length; i++)
		{
			if (node.children[word[i] - 'a'] == null)
			{
				return false;
			}

			node = node.children[word[i] - 'a'];
		}

		return node.end;
	}

	public bool Match(Trie root, string word)
	{
		var node = root;
		int start = 0;
		for (int i = start; i < word.Length; i++)
		{
			var child = node.children[word[i]- 'a'];
			if(child != null)
			{
				if(child.end)
				{
					start = i;
					node = root;
				}
				else
				{
					node = child;
				}
			}
			else
			{
				return false;
			}
		}
		
		return node.end;
	}
}