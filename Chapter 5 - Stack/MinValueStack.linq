<Query Kind="Program" />

void Main()
{
	var stack = new Stack();
	
	"*********PUSH********".Dump();
	stack.Push(10);
	stack.Print();
	stack.Push(5);
	stack.Print();
	stack.Push(7);
	stack.Print();
	stack.Push(6);
	stack.Print();
	stack.Push(4);
	stack.Print();
	stack.Push(8);
	stack.Print();
	stack.Push(1);
	stack.Print();
	stack.Push(2);
	stack.Print();
	stack.Push(0);
	stack.Print();
	stack.Push(15);
	stack.Print();
	stack.Push(14);
	stack.Print();
	stack.Push(-1);
	stack.Print();

	stack.Print();

	"*********POP********".Dump();
	stack.Pop();
	stack.Pop();
	stack.Pop();
	
	stack.Print();
}

public class Stack
{
	private int[] _elements;
	private int _top;
	private int _max = 4;
	private Stack<int> _minStack;
	
	public Stack()
	{
		_elements = new int[_max];
		_top = -1;
		_minStack = new Stack<int>();
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
		
		if(_minStack.Count == 0)
		{
			_minStack.Push(input);
		}
		else
		{
			if(_minStack.Peek() <= input)
			{
				_minStack.Push(_minStack.Peek());
			}
			else
			{
				_minStack.Push(input);
			}
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
			_minStack.Pop();
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

	public int Min()
	{
		if (_top == -1)
		{
			return -1;
		}

		return _minStack.Peek();
	}
	
	public void Print()
	{
		var count = 0;
		for (int i = _top; i >= 0; i--)
		{
			Console.WriteLine($"Element at {count} : {_elements[i]} & MinValue: {_minStack.Peek()}");
			count++;
		}
	}
}
