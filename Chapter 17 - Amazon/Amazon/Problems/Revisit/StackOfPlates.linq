<Query Kind="Program" />

void Main()
{
	var stackOfPlates = new StackOfPlates();
	
	"*********PUSH********".Dump();
	stackOfPlates.Push(1);
	stackOfPlates.Push(2);
	stackOfPlates.Push(3);
	stackOfPlates.Push(4);
	stackOfPlates.Push(5);
	stackOfPlates.Push(6);

	"*********POP********".Dump();
	stackOfPlates.Pop();
	stackOfPlates.Pop();
	stackOfPlates.Pop();
	stackOfPlates.Pop(0);
	stackOfPlates.Pop();
	stackOfPlates.Pop();
}

public class StackOfPlates
{
	private Stack<int>[] _stacksOfPlates;
	private Stack<int> _currentStack;
	private int _max = 2;
	private int top = 0;
	
	public StackOfPlates()
	{
		_stacksOfPlates = new Stack<int>[_max];
		_currentStack = new Stack<int>();
	}
	
	public void Push(int value)
	{
		if(_currentStack.Count < _max)
		{
			$"Inserting value: {value}".Dump();
			_currentStack.Push(value);
		}
		else
		{
			if (_stacksOfPlates.Length == _max)
			{
				var newLength = _max * 2;
				var newArray = new Stack<int>[newLength];
				Array.Copy(_stacksOfPlates, newArray, _stacksOfPlates.Length);
				_stacksOfPlates = newArray;
			}
			
			$"Reached Maximum. Creating new stack".Dump();
			_stacksOfPlates[top++] = _currentStack;
			_currentStack = new Stack<int>();
			
			$"Inserting value: {value}".Dump();
			_currentStack.Push(value);
		}
	}

	public void Pop()
	{
		if (_currentStack.Count != 0)
		{
			$"Removing value: {_currentStack.Peek()}".Dump();
			_currentStack.Pop();
		}
		else
		{
			$"Removing stack of plates".Dump();
			_currentStack = _stacksOfPlates[--top];
			$"Removing value: {_currentStack.Peek()}".Dump();
			_currentStack.Pop();
		}
	}

	public void Pop(int index)
	{
		var stack = _stacksOfPlates[index];
		stack.Pop();
	}
}