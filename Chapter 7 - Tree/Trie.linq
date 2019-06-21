<Query Kind="Program" />

void Main()
{
	var trie = new Trie();

	trie.Insert("apple");
	trie.Insert("app");
	trie.Search("apple").Dump();   // returns true
	trie.Search("app").Dump();     // returns false
	trie.StartsWith("app").Dump(); // returns true
	trie.Insert("app");
	trie.Search("app").Dump();
}

class TrieNode
{
	private int R = 26;
	private TrieNode[] children;
    private String item;

	public TrieNode()
	{
		children = new TrieNode[R];
		item = "";
	}

	public String getItem()
	{
		return item;
	}

	public void setItem(String item)
	{
		this.item = item;
	}

	public TrieNode[] getChildren()
	{
		return children;
	}

	public TrieNode getChild(int i)
	{
		if (i >= 26 || i < 0) throw new ArgumentException();
		return children[i];
	}

	public void setChild(int i, TrieNode node)
	{
		children[i] = node;
	}
}

public class Trie
{
	private TrieNode root;

	public Trie()
	{
		root = new TrieNode();
	}

	// Inserts a word into the trie.
	public void Insert(String word)
	{
		TrieNode curr = root;
		for (int i = 0; i < word.Length; i++)
		{
			if (curr.getChild(word[i] - 'a') == null) curr.setChild(word[i] - 'a', new TrieNode());
			curr = curr.getChild(word[i] - 'a');
		}
		
		curr.setItem(word);
	}

	// Returns if the word is in the trie.
	public bool Search(String word)
	{
		TrieNode curr = root;
		for (int i = 0; i < word.Length; i++)
		{
			if (curr.getChild(word[i] - 'a') == null) return false;
			curr = curr.getChild(word[i] - 'a');
		}

		return curr.getItem().Equals(word);
	}

	// Returns if there is any word in the trie
	// that starts with the given prefix.
	public bool StartsWith(String prefix)
	{
		TrieNode curr = root;
		for (int i = 0; i < prefix.Length; i++)
		{
			if (curr.getChild(prefix[i] - 'a') == null) return false;
			curr = curr.getChild(prefix[i] - 'a');
		}
	
		return true;
	}
}

public class Trie1
{
	private HashSet<string> dictionary;

	/** Initialize your data structure here. */
	public Trie1()
	{
		dictionary = new HashSet<string>();
	}

	/** Inserts a word into the trie. */
	public void Insert(string word)
	{
	   if(!dictionary.Contains(word))
	   {
	   	 dictionary.Add(word);
	   }
	}

	/** Returns if the word is in the trie. */
	public bool Search(string word)
	{
		return dictionary.Contains(word);
	}

	/** Returns if there is any word in the trie that starts with the given prefix. */
	public bool StartsWith(string prefix)
	{
		foreach (var element in dictionary)
		{
			if(element.StartsWith(prefix))
			{
				return true;
			}
		}
		
		return false;
	}
}
