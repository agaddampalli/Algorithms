<Query Kind="Program" />

void Main()
{
	var input = new char[] {'w', 'h', 'a', 'l', 'e', ' ', 'i', 's', ' ', 't', 'h', 'i', 's'};
	ReversewordArrays(input);
}


//Reverse the entire string
//Reverse each word
public void ReversewordArrays(char[] input)
{
	var i = 0;
	var j = input.Length - 1;
	string temp = null;
	
	while(j > i)
	{
		if(input[j] != ' ')
		{
			temp = input[j] + temp;
			j--;
		}
		else
		{
			var x = input.Length - 1;
			while(j != i)
			{
				input[x--] = input[--j];
			}
			
			for (int k = 0; k < temp.Length; k++)
			{
				input[i] = temp[k];
				i++;
			}
			
			input[i++] = ' ';
			
			j = input.Length - 1;
			temp = null;
		}
	}
	
	input.Dump();
	
}