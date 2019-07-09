<Query Kind="Program" />

void Main()
{
	var stack = new MaxStack();

	stack.Push(92);
	stack.PeekMax().Dump();
	
	stack.Push(54);
	stack.PeekMax().Dump();

	stack.Push(22);
	stack.PeekMax().Dump();

	stack.Pop().Dump();
	stack.Pop().Dump();

	stack.Push(-57);
	stack.PeekMax().Dump();

	stack.Push(-24);
	stack.PeekMax().Dump();

	stack.PopMax().Dump();
	stack.Top().Dump();

	stack.Push(26);
	stack.Push(-71);
	stack.PeekMax().Dump();

	stack.PopMax().Dump();
	stack.PopMax().Dump();
}

public class MaxStack
{
	private int top = -1;
	private int[] stack;
	private Stack<int> maxStack;

	public MaxStack()
	{
		stack = new int[10000];
		maxStack = new Stack<int>();
	}

	public void Push(int x)
	{
		stack[++top] = x;

		if (maxStack.Count == 0 || maxStack.Peek() <= x)
		{
			maxStack.Push(x);
		}
		else
		{
			maxStack.Push(maxStack.Peek());
		}
	}

	public int Pop()
	{
		maxStack.Pop();
		return stack[top--];
	}

	public int Top()
	{
		return stack[top];
	}

	public int PeekMax()
	{
		return maxStack.Peek();
	}

	public int PopMax()
	{
		var temp = new Stack<int>();
		var max = maxStack.Peek();
		
		while(top >= 0)
		{
			if(stack[top] == max)
			{
				top--;
				maxStack.Pop();
				break;
			}
			
			temp.Push(stack[top--]);
			maxStack.Pop();
		}
		
		while(temp.Count != 0)
		{
			var value = temp.Pop();
			stack[++top] = value;
			if (maxStack.Count == 0 || maxStack.Peek() <= value)
			{
				maxStack.Push(value);
			}
			else
			{
				maxStack.Push(maxStack.Peek());
			}
		}

		return max;
	}
}
