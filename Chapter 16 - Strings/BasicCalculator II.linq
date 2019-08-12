<Query Kind="Program" />

void Main()
{
	BasicCalculatorII("(2+6* 3+5- (3*14/7+2)*5)+3").Dump();
	Calculate("(2+6* 3+5- (3*14/7+2)*5)+3").Dump();
}

public int BasicCalculatorII(string s)
{
	var stack = new Stack<int>();
	var len = s.Length;
	
	var operand = 0;
	var mul = 1;
	int hasPriorityOperator = 0;

	for (int i = len - 1; i >= 0; i--)
	{
		if (s[i] == ' ')
		{
			continue;
		}
		
		if(IsInt(s[i]))
		{
			operand = operand + (s[i] - '0') * mul;
			mul = mul * 10;
		}
		else
		{
			if(mul != 1)
			{
				stack.Push(operand);
				operand = 0;
				mul = 1;
			}
			
			while(hasPriorityOperator != 0 && s[i] != '*' && s[i] != '/')
			{
				var operand1 = stack.Pop();
				var sign = stack.Pop();
				var operand2 = stack.Pop();
				
				var temp = Eval(sign, operand1, operand2);

				if (temp != null)
				{
					stack.Push(temp.Value);
				}
				
				hasPriorityOperator--;
			}

			if(s[i] == '(')
			{
				EvalExpression(stack, hasPriorityOperator);
			}
			else
			{
				if(s[i] == '*' || s[i] == '/')
				{
					hasPriorityOperator++;
				}
				stack.Push(s[i]);
			}
		}
	}
	
	if(mul != 1)
	{
		stack.Push(operand);
		EvalExpression(stack, hasPriorityOperator);
	}
	
	return stack.Pop();
}

public bool IsInt(char ch)
{
	return ch >= '0' && ch <= '9';
}

public void EvalExpression(Stack<int> stack, int priorityOperatorCount)
{
	while (priorityOperatorCount != 0)
	{
		var operand1 = stack.Pop();
		var sign = stack.Pop();
		var operand2 = stack.Pop();

		var temp = Eval(sign, operand1, operand2);

		if (temp != null)
		{
			stack.Push(temp.Value);
		}

		priorityOperatorCount--;
	}
	
	var res = stack.Pop();
	
	while(stack.Count != 0 && stack.Peek() != ')')
	{
		var sign = stack.Pop();
		var operand2 = stack.Pop();
		var temp = Eval(sign, res, operand2);
		if(temp != null)
		{
			res = temp.Value;
		}
	}
	
	if(stack.Count != 0 && stack.Peek() == ')')
	{
		stack.Pop();
	}
	
	stack.Push(res);
}

public int? Eval(int sign, int operand1, int operand2)
{
	switch (sign)
	{
		case '+':
			return operand1 + operand2;
		case '-':
			return operand1 - operand2;
		case '*':
			return operand1 * operand2;
		case '/':
			return operand1 / operand2;
		default:
		  return null;
	}
}

public int Calculate(string s)
{
	int num;
	char lastOp = '+';
	int res = 0;
	int prev = -1;

	int read = 0;


	if (s == null || s.Length == 0) { return 0; }

	s = s.Replace(" ", "");
	while (read < s.Length)
	{

		if (Char.IsDigit(s[read]) == true)
		{
			num = s[read] - '0';
			read++;
			while (read < s.Length && Char.IsDigit(s[read]) == true)
			{
				num = num * 10 + s[read] - '0';
				read++;
			}

			if (lastOp == '+')
			{
				res += num;
				prev = num;
			}
			else if (lastOp == '-')
			{
				res -= num;
				prev = -num;
			}
			else if (lastOp == '*')
			{
				res = res - prev + prev * num;
				prev = prev * num;
			}
			else if (lastOp == '/')
			{
				res = res - prev + prev / num;
				prev = prev / num;
			}

		}
		else
		{
			lastOp = s[read];
			read++;
		}
	}

	return res;
}