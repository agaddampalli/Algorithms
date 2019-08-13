<Query Kind="Program" />

void Main()
{
	// bbarfoo
	//	var s = "aaaaaaaa";
	var s = "barfoothefoobarman";
	var words = new string[] { "foo", "bar" };

	FindSubstring(s, words).Dump();
}

public IList<int> FindSubstring(string s, string[] words)
{
	var output = new List<int>();
	var wordsLength = 0;
	var wordLength = 0;
	var dict = new Dictionary<string, int>();
	for (int i = 0; i < words.Length; i++)
	{
		if(!dict.ContainsKey(words[i]))
		{
			dict.Add(words[i], 0);
		}
		dict[words[i]]++;
		wordLength = words[i].Length;
		wordsLength += wordLength;
	}

	for (int i = 0; i < wordLength; i++)
	{
		var index  = i;
		while(index + wordsLength <= s.Length)
		{
			var hashSet = new Dictionary<string, int>(dict);
			var endIndex = index + wordsLength;
			var hasNotFound = false;
			while(endIndex > index)
			{
				var temp = s.Substring(endIndex-wordLength, wordLength);
				if(!hashSet.ContainsKey(temp) || hashSet[temp] <= 0)
				{
					hasNotFound = true;
					break;
				}
				
				hashSet[temp]--;
				endIndex -= wordLength;
			}
			
			if(hasNotFound)
			{
				index = endIndex;
				continue;
			}
			
			output.Add(index);
			index += wordLength;
		}
	}

	return output;
}


public IList<int> FindSubstring1(string s, string[] words)
{
	var output = new List<int>();

	var root = new Trie();
	int i = 0;
	var wordLength = words[i].Length;
	for (; i < words.Length; i++)
	{
		root.Insert(root, words[i]);
	}

	i = 0;
	var startIndex = 0;
	while (i < s.Length)
	{
		var count = 0;
		startIndex = i;
		var node = root;
		if (node.Child[s[i] - 'a'] != null)
		{
			var hashSet = new Dictionary<string, int[]>();
			while (i < s.Length && node.Child[s[i] - 'a'] != null)
			{
				node = node.Child[s[i] - 'a'];
				i++;

				if (node.val != null)
				{
					if (!hashSet.ContainsKey(node.val))
					{
						count++;
						hashSet.Add(node.val, new int[] { i, 1 });
					}
					else if (hashSet[node.val][1] != node.count)
					{
						hashSet[node.val][1]++;
						count++;
					}
					else
					{
						i = hashSet[node.val][0];
						break;
					}

					node = root;
					if (count == words.Length)
					{
						count = 0;
						output.Add(startIndex);
						break;
					}
				}
			}
			i = startIndex + 1;
		}
		else
		{
			i++;
		}
	}

	return output;
}

public class Trie
{
	public Trie[] Child { get; set; }
	private const int _size = 26;
	public string val { get; set; }
	public int count { get; set; }

	public Trie()
	{
		Child = new Trie[_size];
	}

	public void Insert(Trie root, string word)
	{
		var node = root;
		for (int i = 0; i < word.Length; i++)
		{
			var ch = word[i] - 'a';
			if (node.Child[ch] == null)
			{
				node.Child[ch] = new Trie();
			}

			node = node.Child[ch];
		}

		node.val = word;
		node.count++;
	}
}