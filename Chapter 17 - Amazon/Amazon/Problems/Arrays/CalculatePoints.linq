<Query Kind="Program" />

void Main()
{
	var ops = new string[] { "5", "2", "C", "D", "+" };

	CalPoints(ops).Dump();
}

public int CalPoints(string[] ops)
{
	var stack = new Stack<int>();

	for (int i = 0; i < ops.Length; i++)
	{
		if (ops[i] == "C")
		{
			stack.Pop();
		}
		else if (ops[i] == "D" && stack.Count != 0)
		{
			stack.Push(stack.Peek() * 2);
		}
		else if (ops[i] == "+")
		{
			int val1 = stack.Pop();

			int val = val1 + stack.Peek();

			stack.Push(val1);
			stack.Push(val);
		}
		else
		{
			int val = 0;
			int.TryParse(ops[i], out val);
			if (val != 0)
			{
				stack.Push(val);
			}
		}
	}

	var res = 0;
	while (stack.Any())
	{
		res += stack.Pop();
	}

	return res;
}
