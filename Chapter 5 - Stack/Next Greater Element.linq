<Query Kind="Program" />

void Main()
{
	var input = new int[]{11, 13, 21, 3};
	NextGreaterElement(input);
}

private static void NextGreaterElement(int[] input)
{
	var greaterElementStack = new Stack<int>();
	var inputLength = input.Length;
	greaterElementStack.Push(input[0]);
	for (int i = 1 ; i < inputLength ; i++)
	{
		var nextElement = input[i];
		if(!greaterElementStack.IsEmpty() && nextElement < greaterElementStack.Peek())
		{
			greaterElementStack.Push(nextElement);
			continue;
		}
		
		while(!greaterElementStack.IsEmpty() && nextElement > greaterElementStack.Peek())
		{
			$"Element : {greaterElementStack.Pop()}; NextGreaterElement: {nextElement}".Dump();
		}
		
		greaterElementStack.Push(nextElement);
	}
	
	while(!greaterElementStack.IsEmpty())
	{
		$"Element : {greaterElementStack.Pop()}; NextGreaterElement: {-1}".Dump();
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