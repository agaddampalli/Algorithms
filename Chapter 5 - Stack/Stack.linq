<Query Kind="Program" />

void Main()
{
	var stack = new Stack();

	"*********PUSH********".Dump();
	stack.Push(10);
	stack.Push(20);
	stack.Push(30);
	stack.Push(40);
	stack.Push(50);

	Console.WriteLine($"Peek : {stack.Peek()}");

	stack.Print();

	"*********POP********".Dump();
	stack.Pop();
	stack.Pop();
	stack.Pop();
	Console.WriteLine($"Peek : {stack.Peek()}");
	stack.Print();
}

public class Stack
{
	private int[] _elements;
	private int _top;
	private int _max = 4;

	public Stack()
	{
		_elements = new int[_max];
		_top = -1;
	}

	public void Push(int input)
	{
		if (_top == _max - 1)
		{
			_max = _max * 2;
			var newArray = new int[_max];
			Array.Copy(_elements, newArray, _elements.Length);
			_elements = newArray;
		}
		_elements[++_top] = input;
	}

	public int Pop()
	{
		if (_top == -1)
		{
			Console.WriteLine("Stack is Empty");
			return -1;
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

	public int Peek()
	{
		if (_top == -1)
		{
			return -1;
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
