<Query Kind="Program" />

void Main()
{
	ReverseWords("the sky is blue").Dump();
}

public string ReverseWords(string s)
{
	var sentence = new StringBuilder(s);
	
	Reverse(sentence, 0, sentence.Length -1);
	
	var start = 0;
	bool wordStart = false;
	for (int i = 0; i < sentence.Length; i++)
	{
		if(sentence[i] == ' ')
		{
			if(!wordStart)
			{
				sentence.Remove(start,1);
				i--;
				continue;
			}
			else
			{
				Reverse(sentence, start, i - 1);
				start = i+1;
				wordStart = false;
			}
		}
		else
		{
			wordStart = true;
		}
	}
	
	Reverse(sentence, 0, sentence.Length -1);
	return sentence.ToString().Trim();
}

public void Reverse(StringBuilder input, int start, int end)
{
	while(start < end)
	{
		var temp = input[end];
		input[end] = input[start];
		input[start] = temp;
		
		start++;
		end--;
	}
}