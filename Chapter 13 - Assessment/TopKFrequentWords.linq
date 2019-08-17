<Query Kind="Program" />

void Main()
{
	var words = new string[] {"glarko","zlfiwwb","nsfspyox","pwqvwmlgri","qggx","qrkgmliewc","zskaqzwo","zskaqzwo","ijy","htpvnmozay","jqrlad","ccjel","qrkgmliewc","qkjzgws","fqizrrnmif","jqrlad","nbuorw","qrkgmliewc","htpvnmozay","nftk","glarko","hdemkfr","axyak","hdemkfr","nsfspyox","nsfspyox","qrkgmliewc","nftk","nftk","ccjel","qrkgmliewc","ocgjsu","ijy","glarko","nbuorw","nsfspyox","qkjzgws","qkjzgws","fqizrrnmif","pwqvwmlgri","nftk","qrkgmliewc","jqrlad","nftk","zskaqzwo","glarko","nsfspyox","zlfiwwb","hwlvqgkdbo","htpvnmozay","nsfspyox","zskaqzwo","htpvnmozay","zskaqzwo","nbuorw","qkjzgws","zlfiwwb","pwqvwmlgri","zskaqzwo","qengse","glarko","qkjzgws","pwqvwmlgri","fqizrrnmif","nbuorw","nftk","ijy","hdemkfr","nftk","qkjzgws","jqrlad","nftk","ccjel","qggx","ijy","qengse","nftk","htpvnmozay","qengse","eonrg","qengse","fqizrrnmif","hwlvqgkdbo","qengse","qengse","qggx","qkjzgws","qggx","pwqvwmlgri","htpvnmozay","qrkgmliewc","qengse","fqizrrnmif","qkjzgws","qengse","nftk","htpvnmozay","qggx","zlfiwwb","bwp","ocgjsu","qrkgmliewc","ccjel","hdemkfr","nsfspyox","hdemkfr","qggx","zlfiwwb","nsfspyox","ijy","qkjzgws","fqizrrnmif","qkjzgws","qrkgmliewc","glarko","hdemkfr","pwqvwmlgri"};
	
	TopKFrequent(words, 14).Dump();
}

public IList<string> TopKFrequent(string[] words, int k)
{
	var temp = new Dictionary<string, int>();
	var wordsList = new List<Word>();
	
	int i = 0;
	foreach (var word in words)
	{
		if (!temp.ContainsKey(word))
		{
			temp.Add(word, i++);
			wordsList.Add(new Word(word, 1));
		}
		else
		{
			wordsList[temp[word]].count++;
		}
	}
	
	wordsList.Sort(new Comparer());

	var result = new List<string>();
	for (int j = 0; j < k; j++)
	{
		result.Add(wordsList[j].val);
	}
	
	return result;
}

public class Word
{
	public string val { get; set; }
	
	public int count { get; set; }
	
	public Word(string val, int count)
	{
		this.val = val;
		this.count = count;
	}
}


public void SortK(List<Word> words, int left, int right, int k)
{
	if(left <= right)
	{
		var pivot = FindPivot(words, left, right);
		
		if(pivot == k)
		{
			return;
		}
		else if(pivot > k)
		{
			right = pivot - 1;
			SortK(words, left , right, k);
		}
		else
		{
			left = pivot + 1;
			SortK(words, left , right, k);
		}
	}
}

private int FindPivot(List<Word> words, int left, int right)
{
	var pivot = words[left];
	var index = left;
	for (int i = left+1; i <= right; i++)
	{
		if (pivot.count == words[i].count && pivot.val.CompareTo(words[i].val) == -1)
		{
			continue;
		}
		
		if(pivot.count <= words[i].count)
		{
			index++;
			Swap(words, index, i);
		}
	}
	
	Swap(words, left , index);
	
	return index;
}

private void Swap(List<Word> words, int i, int j)
{
	var temp = words[i];
	words[i] = words[j];
	words[j] = temp;
}

public class Comparer : System.Collections.Generic.IComparer<Word>
{
	public int Compare(Word x, Word y)
	{
		return x.count == y.count ? x.val.CompareTo(y.val) : y.count - x.count;
	}
}