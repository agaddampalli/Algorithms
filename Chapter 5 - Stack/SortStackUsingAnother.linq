<Query Kind="Program" />

void Main()
{
	var input = new Stack<int>();
	input.Push(1);
	input.Push(-4);
	input.Push(2);
	input.Push(5);
	input.Push(3);
	input.Push(2);
	input.Push(-3);
	
	SortStack(input).Dump();
}

public Stack<int> SortStack(Stack<int> input)
{
	if(input.Count <= 1)
	{
		return input;
	}
	
	var output = new Stack<int>();
	output.Push(input.Pop());
	
	while(input.Count != 0)
	{
		var currentValue = input.Pop();
		
		Add(output, currentValue);
	}
	
	return output;
}

public void Add(Stack<int> stack, int value)
{
	if(stack.Count == 0)
	{
		stack.Push(value);
	}
	else if(value > stack.Peek())
	{
		var currentValue = stack.Pop();
		Add(stack, value);
		stack.Push(currentValue);
	}
	else
	{
		stack.Push(value);
	}
}