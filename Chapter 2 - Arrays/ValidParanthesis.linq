<Query Kind="Program" />

void Main()
{
	IsValid("[]}").Dump();
}

public bool IsValid(string s)
{
	if(string.IsNullOrWhiteSpace(s))
	{
		return true;
	}
	
	var stack = new Stack<char>();
	stack.Push(s[0]);
	
	for (int i = 1; i < s.Length; i++)
	{
		if(s[i] == '(' || s[i] == '[' || s[i] == '{')
		{
			stack.Push(s[i]);
		}
		else if(s[i] == ')')
		{
			if (stack.Count != 0 )
			{
				if(stack.Peek() != '(')
				{
					return false;
				}
				else
				{
					stack.Pop();
				}
			}
			else
			{
				return false;
			}
		}
		else if (s[i] == ']')
		{
			if (stack.Count != 0)
			{
				if (stack.Peek() != '[')
				{
					return false;
				}
				else
				{
					stack.Pop();
				}
			}
			else
			{
				return false;
			}
		}
		else if (s[i] == '}')
		{
			if (stack.Count != 0 )
			{
				if(stack.Peek() != '{')
				{
					return false;
				}
				else
				{
					stack.Pop();
				}
			}
			else
			{
				return false;
			}
		}
	}

	return stack.Count == 0;
}
