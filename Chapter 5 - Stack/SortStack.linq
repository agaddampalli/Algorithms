<Query Kind="Program" />

void Main()
{
	var stack = new Stack<int>();
	stack.Push(-3);
	stack.Push(14);
	stack.Push(18);
	stack.Push(-5);
	stack.Push(30);
	stack.Push(-3);
	
	Sort(stack);
	
	stack.Print();
	
}

private static void Sort(Stack<int> input)
{
	if(!input.IsEmpty())
	{
		var temp = input.Pop();
		Sort(input);
		InsertInSortedStack(input, temp);
	}
}

private static void InsertInSortedStack(Stack<int> input, int value)
{
	if(input.IsEmpty())
	{
		input.Push(value);
	}
	else if(value < input.Peek())
	{
		var temp = input.Pop();
		InsertInSortedStack(input, value);
		input.Push(temp);
	}
	else
	{
		input.Push(value);
	}
}

public class Stack<T>
{
	private T[] _elements;
	private int _top;
	private int _max = 4;

	public Stack()
	{
		_elements = new T[_max];
		_top = -1;
	}

	public void Push(T input)
	{
		if (_top == _max - 1)
		{
			_max = _max * 2;
			var newArray = new T[_max];
			Array.Copy(_elements, newArray, _elements.Length);
			_elements = newArray;
		}
		_elements[++_top] = input;
	}

	public T Pop()
	{
		if (_top == -1)
		{
			throw new ArgumentNullException("Stack is Empty");
		}
		else
		{
			return _elements[_top--];
		}
	}

	public bool IsEmpty()
	{
		return _top == -1;
	}

	public T Peek()
	{
		if (_top == -1)
		{
			throw new ArgumentNullException("Stack is Empty");
		}

		return _elements[_top];
	}

	public void Print()
	{
		var count = 0;
		for (int i = _top; i >= 0; i--)
		{
			Console.WriteLine($"Element at {count} : {_elements[i]}");
			count++;
		}
	}
}
