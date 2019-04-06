<Query Kind="Program" />

void Main()
{
	var input = new int[]{10, 4, 5, 90, 120, 80};
	
	var output = CalculateStockSpan(input);
	output.Dump();
}

private static int[] CalculateStockSpan(int[] input)
{
	var output = new int[input.Length];
	var valuesStack = new Stack<int>();
	
	for(int i=0; i<input.Length; i++)
	{
		if(valuesStack.IsEmpty() || input[i] < valuesStack.Peek())
		{
			output[i] = 1;
		}
		else
		{
			CalculateCount(valuesStack, input[i], 1, output, i);
		}
		
		valuesStack.Push(input[i]);
	}
	
	return output;
}

private static void CalculateCount(Stack<int> valuesStack, int inputValue, int count, int[] output, int index)
{
	if(!valuesStack.IsEmpty() && inputValue >= valuesStack.Peek())
	{
		var temp = valuesStack.Pop();
		count++;
		output[index] = count;
		CalculateCount(valuesStack, inputValue, count, output, index);
		valuesStack.Push(temp);
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
