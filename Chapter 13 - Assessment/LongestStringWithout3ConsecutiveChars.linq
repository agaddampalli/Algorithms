<Query Kind="Program" />

void Main()
{
	var maxHeap = new MaxHeap(3);

	maxHeap.Enqueue(new Char('a', 1));
	maxHeap.Enqueue(new Char('b', 2));
	maxHeap.Enqueue(new Char('c', 3));

	maxHeap.Print();
	
	ReorganizeString(maxHeap).Dump();
}

public string ReorganizeString(MaxHeap maxHeap)
{
	var output = new StringBuilder();
	

	char prev = default(char);
	
	while(!maxHeap.IsEmpty)
	{
		var top = maxHeap.Dequeue();

		if (top.Value != prev)
		{
			prev = top.Value;
			if (top.Count == 1)
			{
				output.Append(top.Value);
				top.Count--;
			}
			else
			{
				output.Append(top.Value);
				output.Append(top.Value);
				
				top.Count -= 2;
				
				if(top.Count > 0)
				{
					maxHeap.Enqueue(top);
				}
			}
		}
		else if(!maxHeap.IsEmpty)
		{
			var next = maxHeap.Dequeue();
			prev = next.Value;
			output.Append(next.Value);
			next.Count--;

			if (next.Count > 0)
			{
				maxHeap.Enqueue(next);
			}
			
			maxHeap.Enqueue(top);
		}
		else
		{
			break;
		}
	}
	
	return output.ToString();
}

public class Char
{
	public char Value { get; set; }
	
	public int Count { get; set; }
	
	public Char(char value, int count)
	{
		Value = value;
		Count = count;
	}
}

public class MaxHeap
{
	private int _capacity = 10;
	private Char[] _items;
	private int currentSize;

	public MaxHeap()
	{
		_items = new Char[_capacity];
		currentSize = 0;
	}
	
	public MaxHeap(int capacity)
	{
		_capacity = capacity;
		currentSize = 0;
		_items = new Char[capacity];
	}

	public int GetLeftChildIndex(int i) { return 2 * i + 1; }
	public int GetRightChildIndex(int i) { return 2 * i + 2; }
	public int GetParentIndex(int childIndex) { return (childIndex - 1) / 2; }

	public bool HasLeftChild(int i) { return GetLeftChildIndex(i) < currentSize; }
	public bool HasRightChild(int i) { return GetRightChildIndex(i) < currentSize; }
	public bool HasParent(int i) { return GetParentIndex(i) >= 0; }

	public Char GetLeftChild(int i) { return _items[GetLeftChildIndex(i)]; }
	public Char GetRightChild(int i) { return _items[GetRightChildIndex(i)]; }
	public Char GetParent(int i) { return _items[GetParentIndex(i)]; }

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
			var temp = new Char[_capacity];
			Array.Copy(_items, temp, _items.Length);
			_items = temp;
		}
	}

	public Char Peek()
	{
		if (currentSize == 0)
		{
			throw new InvalidOperationException();
		}

		return _items[0];
	}

	public bool IsEmpty
	{
		get { return currentSize == 0;}
	}

	public void Print()
	{
		_items.Dump();
	}


	public Char Dequeue()
	{
		if (currentSize == 0)
		{
			throw new InvalidOperationException();
		}

		var result = _items[0];
		_items[0] = _items[currentSize - 1];
		currentSize--;
		HeapifyDown();
		return result;
	}

	public void Enqueue(Char item)
	{
		EnsureCapacity();
		_items[currentSize] = item;
		currentSize++;
		HeapifyUp();
	}

	public void HeapifyDown()
	{
		var index = 0;
		while(HasLeftChild(index))
		{
			var biggerIndex = GetLeftChildIndex(index);
			
			if(HasRightChild(index) && GetRightChild(index).Count > GetLeftChild(index).Count)
			{
				biggerIndex = GetRightChildIndex(index);
			}
			
			if(_items[index].Count > _items[biggerIndex].Count)
			{
				break;
			}
			
			Swap(index,biggerIndex);
			index = biggerIndex;
		}
	}

	public void HeapifyUp()
	{
		var index = currentSize - 1;
		while (HasParent(index) && GetParent(index).Count < _items[index].Count)
		{
			Swap(GetParentIndex(index), index);
			index = GetParentIndex(index);
		}
	}
}
