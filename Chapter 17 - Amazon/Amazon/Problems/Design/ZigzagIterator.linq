<Query Kind="Program" />

void Main()
{
	var input1 = new List<int> { 1, 2 };
	var input2 = new List<int> { 3,4,5,6 };
	
	var iterator = new ZigzagIterator(input1, input2);
	
	while(iterator.HasNext())
	{
		iterator.Next().Dump();
	}
}

public class ZigzagIterator
{
	private IList<IList<int>> _input;
	private int _index;
	
	public ZigzagIterator(IList<int> v1, IList<int> v2)
	{
		_input = new List<IList<int>>();
		
		if(v1.Any())
		{
			_input.Add(v1);
		}

		if (v2.Any())
		{
			_input.Add(v2);
		}
		
		_index = 0;
	}

	public bool HasNext()
	{
		return _input.Count > 0;
	}

	public int Next()
	{
		var rowIndex = _index % _input.Count;
		var colIndex = _index / _input.Count;
		
		var result = _input[rowIndex][colIndex];
		
		if(colIndex == _input[rowIndex].Count-1)
		{
			_input.RemoveAt(rowIndex);
			_index -= colIndex;
		}
		else
		{
			_index++;
		}

		return result;
	}
}
