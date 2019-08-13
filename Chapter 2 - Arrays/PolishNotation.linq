<Query Kind="Program" />

void Main()
{
	var tokens = new string[] {"10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+"};
	EvalRPN(tokens).Dump();
}

public int EvalRPN(string[] tokens)
{
	var stack = new Stack<int>();
	var operatorsSet = new HashSet<string> {"+", "-", "*", "/"};
	
	foreach (var element in tokens)
	{
		if(!operatorsSet.Contains(element))
		{
			stack.Push(Convert.ToInt32(element));
		}
		else
		{
			var value1 = stack.Pop();
			var value2 = stack.Pop();
			switch(element)
			{
				case "+":
					stack.Push(value1 + value2);
					break;
				case "*":
					stack.Push(value1 * value2);
					break;
				case "-":
					stack.Push(value2 - value1);
					break;
				case "/":
					stack.Push(value2 / value1);
					break;
			}
		}
	}
	
	return stack.Pop();
}
