<Query Kind="Program" />

void Main()
{
	var sentences = new string[] { "i love you", "island", "ironman", "i love leetcode" };
	var times = new int[] {5,3,2,2};
	
	var autoCompleteSystem = new AutocompleteSystem(sentences, times);

	autoCompleteSystem.Input('i').Dump();
	autoCompleteSystem.Input(' ').Dump();
	autoCompleteSystem.Input('a').Dump();
//	autoCompleteSystem.Input('n').Dump();
//	autoCompleteSystem.Input('m').Dump();
//	autoCompleteSystem.Input('a').Dump();
//	autoCompleteSystem.Input('n').Dump();
	autoCompleteSystem.Input('#').Dump();
	
//	autoCompleteSystem.Input('i').Dump();
}

public class AutocompleteSystem 
{
	private StringBuilder _currentString;
	private Trie _root;
	private Dictionary<string, int> sentenceTimeDict;
	
	public AutocompleteSystem(string[] sentences, int[] times)
	{
		_root = new Trie();
		_currentString = new StringBuilder();
		sentenceTimeDict = new Dictionary<string, int>();
		
		for (int i = 0; i < sentences.Length; i++)
		{
			_root.Insert(_root, sentences[i], times[i]);
			sentenceTimeDict.Add(sentences[i], times[i]);
		}
	}

	public IList<string> Input(char c)
	{
		var output = new List<string>();
		if(c == '#')
		{
			var sentenceToInsert = _currentString.ToString();
			int times = 1;
			if(sentenceTimeDict.ContainsKey(sentenceToInsert))
			{
				sentenceTimeDict[sentenceToInsert]++;
				times = sentenceTimeDict[sentenceToInsert];
			}
			else
			{
				sentenceTimeDict.Add(sentenceToInsert, times);
			}
			
			_root.Insert(_root, sentenceToInsert, times);
			_currentString.Clear();
			return output;
		}
		else
		{
			_currentString.Append(c);
			var pairs = _root.Find(_root, _currentString.ToString());

			return pairs == null ? output :  pairs.Select(x => x.Sentence).ToList();
		}
	}
}

public class Pair
{
	public string Sentence { get; set; }
	public int Times {get; set;}
	
	public Pair(string sentence, int times)
	{
		Sentence = sentence;
		Times = times;
	}
}

public class Comparer : IComparer<Pair>
{
	public int Compare(Pair x, Pair y)
	{
		return x.Times != y.Times ? y.Times - x.Times : x.Sentence.CompareTo(y.Sentence);
	}
}

public class Trie
{
	private int _capacity = 27;
	private int _spaceIndex = 26;
	
	public Trie[] Nodes { get; set;}
	public SortedSet<Pair> HotWords {get; set;}
	
	public Trie()
	{
		Nodes = new Trie[_capacity];
		HotWords = new SortedSet<Pair>(new Comparer());
	}
	
	public void Insert(Trie root, string sentence, int times)
	{
		var node = root;
		for (int i = 0; i < sentence.Length; i++)
		{
			var index = GetCharIndex(sentence[i]);
			if(node.Nodes[index] == null)
			{
				var pair = new Pair(sentence, times);
				node.Nodes[index] = new Trie();
				node.Nodes[index].HotWords.Add(pair);
			}
			else
			{
				var pair = new Pair(sentence, times-1);
				if(node.Nodes[index].HotWords.Contains(pair))
				{
					node.Nodes[index].HotWords.Remove(pair);
				}
				
				node.Nodes[index].HotWords.Add(new Pair(sentence, times));
				
				if(node.Nodes[index].HotWords.Count > 3)
				{
					var pairToRemove = node.Nodes[index].HotWords.Last();
					node.Nodes[index].HotWords.Remove(pairToRemove);
				}
			}
			
			node = node.Nodes[index];
		}
	}
	
	public List<Pair> Find(Trie root, string sentence)
	{
		var node  = root;
		for (int i = 0; i < sentence.Length; i++)
		{
			var index = GetCharIndex(sentence[i]);
			if(node.Nodes[index] == null)
			{
				return null;
			}
			
			node = node.Nodes[index];
		}
		
		return node.HotWords.ToList();
	}
	
	
	private int GetCharIndex(char ch)
	{
		return ch == ' ' ? _spaceIndex : ch - 'a';
	}
}