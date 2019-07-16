<Query Kind="Program" />

void Main()
{
	// 1 + 1 + (2 * 4) = 11
	// 2315^6-121*+^*+2-
	// 2315^6-121*+^*+2-
	Calculate("12-11").Dump();
}

Dictionary<char, int> dict;
bool hasOperation;
public int Calculate(string s)
{
	dict = new Dictionary<char, int> { {'^', 3},{'/', 2},{'*', 2},{'+', 1},{'-', 1}};
	hasOperation = false;
	var postFixExp = PostFixExpression(s);
	
	postFixExp.Dump();
	if(!hasOperation)
	{
		return Convert.ToInt32(s);
	}
	
	return Evaluate(postFixExp);
}

public string PostFixExpression(string s)
{
	var stack = new Stack<char>();
	var result = new StringBuilder();
	for (int i = 0; i < s.Length; i++)
	{
		if(s[i] == ' ')
		{
			continue;
		}
		
		char ch = s[i];
		if(ch >= '0' && ch <= '9')
		{
			result. Append(ch);
		}
		else if(ch == '(')
		{
			stack.Push(ch);
		}
		else if(ch == ')')
		{
			while(stack.Count != 0 && stack.Peek() != '(')
			{
				result.Append(stack.Pop());
			}
			
			if(stack.Count != 0 && stack.Peek() == '(')
			{
				stack.Pop();
			}
		}
		else if(dict.ContainsKey(ch))
		{
			hasOperation = true;
			if(!stack.Any() || stack.Peek() == '(')
			{
				stack.Push(ch);
				continue;
			}
			
			while(stack.Any() && dict.ContainsKey(stack.Peek()) && dict[stack.Peek()] >= dict[ch])
			{
				result.Append(stack.Pop());
			}
			
			stack.Push(ch);
		}
	}

	while (stack.Any())
	{
		result.Append(stack.Pop());
	}
	
	return result.ToString();
}

public int Evaluate(string s)
{
	var evalStack = new Stack<int>();
	for (int i = 0; i < s.Length; i++)
	{
		var ch = s[i];
		if(dict.ContainsKey(ch))
		{
			var value2 = evalStack.Pop();
			var value1 = evalStack.Pop();

			var output = PerformOperation(ch, value1, value2);
			if (output != null)
			{
				evalStack.Push(output.Value);
			}
		}
		else
		{
			evalStack.Push(ch - '0');
		}
	}
	
	var result = 0;
	var mul = 1;
	while(evalStack.Any())
	{
		result = evalStack.Pop() * mul + result;
		mul = mul * 10;
	}
	
	return result;
}


private static int? PerformOperation(char operatorValue, int value1, int value2)
{
	switch (operatorValue)
	{
		case '*':
			return value1 * value2;
		case '+':
			return value1 + value2;
		case '-':
			return value1 - value2;
		case '/':
			return (value1 / value2);
		case '%':
			return (value1 % value2);
		case '^':
			return (value1 ^ value2);
		default:
			return null;
	}
}