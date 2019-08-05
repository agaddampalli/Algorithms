<Query Kind="Program" />

void Main()
{
	ReorganizeString("aaabbb").Dump();
}

public string ReorganizeString(string S)
{
	var counts = new int[26];
	var heap = new MaxHeap(5);
	for (int i = 0; i < S.Length; i++)
	{
		counts[S[i]-'a'] += 100;
	}

	for (int i = 0; i < counts.Length; i++)
	{
		if(counts[i] > 0)
		{
			var count = counts[i]/100;
			if(count > (S.Length + 1)/2)
			{
				return string.Empty;
			}
			counts[i] += i;
			heap.Enqueue(counts[i]);
		}
	}
	
	var result = new StringBuilder();
	
	while(heap.Size >= 2)
	{
		var chCount1 = heap.Dequeue();
		var chCount2 = heap.Dequeue();

		var ch1 = (char)('a' + (chCount1 % 100));
		var ch2 = (char)('a' + (chCount2 % 100));

		result.Append(ch1);
		result.Append(ch2);

		var nextCount1 = (chCount1 - chCount1 % 100) - 100;
		if(nextCount1 > 0)
		{
			heap.Enqueue(chCount1-100);
		}

		var nextCount2 = (chCount2 - chCount2 % 100) - 100;
		if (nextCount2 > 0)
		{
			heap.Enqueue(chCount2-100);
		}
	}	
	
	if(heap.Size > 0)
	{
		var chCount1 = heap.Dequeue();
		var ch1 = (char)('a' + (chCount1 % 100));
		result.Append(ch1);
	}

	return result.ToString();
}

public class MaxHeap
{
	private int _capacity = 10;
	private int[] _items;
	private int currentSize;

	public int Size { get { return currentSize;}}
	public MaxHeap()
	{
		_items = new int[_capacity];
		currentSize = 0;
	}

	public MaxHeap(int capacity)
	{
		_capacity = capacity;
		currentSize = 0;
		_items = new int[capacity];
	}

	public int GetLeftChildIndex(int i) { return 2 * i + 1; }
	public int GetRightChildIndex(int i) { return 2 * i + 2; }
	public int GetParentIndex(int childIndex) { return (childIndex - 1) / 2; }

	public bool HasLeftChild(int i) { return GetLeftChildIndex(i) < currentSize; }
	public bool HasRightChild(int i) { return GetRightChildIndex(i) < currentSize; }
	public bool HasParent(int i) { return GetParentIndex(i) >= 0; }

	public int GetLeftChild(int i) { return _items[GetLeftChildIndex(i)]; }
	public int GetRightChild(int i) { return _items[GetRightChildIndex(i)]; }
	public int GetParent(int i) { return _items[GetParentIndex(i)]; }

	public void Swap(int i, int j)
	{
		var temp = _items[i];
		_items[i] = _items[j];
		_items[j] = temp;
	}

	public void EnsureCapacity()
	{
		if (currentSize == _capacity)
		{
			_capacity = _capacity * 2;
			var temp = new int[_capacity];
			Array.Copy(_items, temp, _items.Length);
			_items = temp;
		}
	}

	public void Print()
	{
		_items.Dump();
	}
	
	public int Peek()
	{
		if (currentSize == 0)
		{
			throw new InvalidOperationException();
		}

		return _items[0];
	}

	public int Dequeue()
	{
		if (currentSize == 0)
		{
			throw new InvalidOperationException();
		}

		var result = _items[0];
		_items[0] = _items[currentSize - 1];
		_items[currentSize - 1] = 0;
		currentSize--;
		HeapifyDown();
		return result;
	}

	public void Enqueue(int item)
	{
		EnsureCapacity();
		_items[currentSize] = item;
		currentSize++;
		HeapifyUp();
	}

	public void HeapifyDown()
	{
		var index = 0;

		while (HasLeftChild(index))
		{
			var biggerIndex = GetLeftChildIndex(index);

			if (HasRightChild(index) && GetRightChild(index) > GetLeftChild(index))
			{
				biggerIndex = GetRightChildIndex(index);
			}

			if (_items[index] > _items[biggerIndex])
			{
				break;
			}

			Swap(index, biggerIndex);
			index = biggerIndex;
		}
	}

	public void HeapifyUp()
	{
		var index = currentSize - 1;

		while (HasParent(index) && GetParent(index) < _items[index])
		{
			Swap(GetParentIndex(index), index);
			index = GetParentIndex(index);
		}
	}
}
