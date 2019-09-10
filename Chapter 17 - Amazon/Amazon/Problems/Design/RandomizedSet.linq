<Query Kind="Program" />

void Main()
{
	
}


public class RandomizedSet
{
	private IDictionary<int, int> _valueIndexMap;
	private IList<int> _input;
	private Random _rand;

	public RandomizedSet()
	{
		_valueIndexMap = new Dictionary<int, int>();
		_input = new List<int>();
		_rand = new Random();
	}

	public bool Insert(int val)
	{
		if (_valueIndexMap.ContainsKey(val))
		{
			return false;
		}

		_valueIndexMap.Add(val, _input.Count);
		_input.Add(val);

		return true;
	}

	public bool Remove(int val)
	{
		if (!_valueIndexMap.ContainsKey(val))
		{
			return false;
		}

		var index = _valueIndexMap[val];
		_valueIndexMap.Remove(val);

		if (index != _input.Count - 1)
		{
			_input[index] = _input[_input.Count - 1];
			_valueIndexMap[_input[index]] = index;
		}

		_input.RemoveAt(_input.Count - 1);

		return true;
	}

	public int GetRandom()
	{
		var index = _rand.Next(_input.Count);
		return _input[index];
	}
}

