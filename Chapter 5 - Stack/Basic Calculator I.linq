<Query Kind="Program" />

void Main()
{
	// 1-(7-8+9)+11
	Calculate("(7)-(0)+(4)").Dump();
}

public int Calculate(string s)
{
	var stack = new Stack<int>();
	int operand = 0;
	int multiplier = 1;
	for (int i = s.Length-1 ; i >= 0; i--)
	{
		var ch = s[i];
		if(ch == ' ')
		{
			continue;
		}
		
		if(IsInt(ch))
		{			
			operand = operand + (ch - '0')* multiplier;
			multiplier = multiplier * 10;
		}
		else if(ch != ' ')
		{
			if(multiplier != 1)
			{
				stack.Push(operand);
				operand = 0;
				multiplier = 1;
			}
			
			if(ch == '(')
			{
				int res = EvaluateExpression(stack);
				stack.Pop();
				stack.Push(res);
			}
			else
			{
				stack.Push(ch);
			}
		}
	}
	
	if(multiplier != 1)
	{
		stack.Push(operand);
	}
	
	return EvaluateExpression(stack);
}

public bool IsInt(int ch)
{
	return ch >= '0' && ch <= '9';
}

public bool IsOperand(int ch)
{
	return ch == '+' || ch == '-';
}

private int EvaluateExpression(Stack<int> stack)
{
	int res = 0;
	if(stack.Any())
	{
		res = stack.Pop();
	}
	
	while(stack.Any() && stack.Peek() != ')')
	{
		var sign = stack.Pop();
		
		if(sign == '+')
		{
			res += stack.Pop();
		}
		else if(sign == '-')
		{
			res -= stack.Pop();
		}
	}
	
	return res;
}
