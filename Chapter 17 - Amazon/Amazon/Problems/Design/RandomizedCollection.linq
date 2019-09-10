<Query Kind="Program" />

void Main()
{
	var collection = new RandomizedCollection();

	collection.Insert(9);
	collection.Insert(9);
	collection.Insert(1);
	collection.Insert(1);
	collection.Insert(2);
	collection.Insert(1);

	collection.Remove(2);
	collection.Remove(1);
	collection.Remove(1);
	
	collection.Insert(9);
	collection.Remove(1);
}

public class RandomizedCollection
{
	private IDictionary<int, List<int>> _valueIndexMap;
	private IList<int> _input;
	private Random _rand;
	
	public RandomizedCollection()
	{
		_valueIndexMap = new Dictionary<int, List<int>>();
		_input = new List<int>();
		_rand = new Random();
	}

	public bool Insert(int val)
	{
		if(!_valueIndexMap.ContainsKey(val))
		{
			_valueIndexMap.Add(val, new List<int>());
		}
		
		_valueIndexMap[val].Add(_input.Count);
		_input.Add(val);
		
		return true;
	}

	public bool Remove(int val)
	{
		if (!_valueIndexMap.ContainsKey(val))
		{
			return false;
		}
		
		var indices = _valueIndexMap[val];
		var index = -1;
		if(indices.Count > 1)
		{
			index = indices.Last();
			_valueIndexMap[val].RemoveAt(indices.Count-1);
		}
		else
		{
			index = indices[0];
			_valueIndexMap.Remove(val);
		}
		
		if(index != _input.Count-1)
		{
			_input[index] = _input[_input.Count-1];
			_valueIndexMap[_input[index]].Remove(_input.Count-1);
			_valueIndexMap[_input[index]].Add(index);
		}
		
		_input.RemoveAt(_input.Count-1);
		
		return true;
	}

	public int GetRandom()
	{
		var index =_rand.Next(_input.Count);
		return _input[index];
	}
}
