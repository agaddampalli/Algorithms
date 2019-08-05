<Query Kind="Program" />

void Main()
{
	var heap = new MinHeap(5);

	heap.Enqueue(8);
	heap.Enqueue(1);
	heap.Enqueue(5);
	heap.Enqueue(10);
	heap.Enqueue(3);
	
	heap.Print();

	heap.Dequeue();
	heap.Dequeue();
	heap.Dequeue();
	
	heap.Print();
	
}

public class MinHeap
{
	private int _capacity = 10;
	private int[] _items;
	private int currentSize;
	
	public MinHeap()
	{
		_items = new int[_capacity];
		currentSize = 0;
	}

	public MinHeap(int capacity)
	{
		_capacity = capacity;
		currentSize = 0;
		_items = new int[capacity];
	}
	
	public int GetLeftChildIndex(int i)	{ return 2 * i + 1;	}
	public int GetRightChildIndex(int i){ return 2 * i + 2;	}
	public int GetParentIndex(int childIndex){ return (childIndex - 1) / 2; }

	public bool HasLeftChild(int i) { return GetLeftChildIndex(i) < currentSize; }
	public bool HasRightChild(int i) { return GetRightChildIndex(i) < currentSize; }
	public bool HasParent(int i) { return GetParentIndex(i) >=0;}

	public int GetLeftChild(int i){	return _items[GetLeftChildIndex(i)];}
	public int GetRightChild(int i)	{ return _items[GetRightChildIndex(i)];}
	public int GetParent(int i){ return _items[GetParentIndex(i)]; }

	public void Swap(int i, int j)
	{
		var temp = _items[i];
		_items[i] = _items[j];
		_items[j] = temp;
	}

	public void EnsureCapacity()
	{
		if(currentSize == _capacity)
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
		if(currentSize == 0)
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
			var smallerIndex = GetLeftChildIndex(index);
			
			if(HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
			{
				smallerIndex = GetRightChildIndex(index);
			}
			
			if(_items[index] < _items[smallerIndex])
			{
				break;
			}
			else
			{
				Swap(index, smallerIndex);
			}
			
			index = smallerIndex;
		}
	}

	public void HeapifyUp()
	{
		var index = currentSize-1;
		
		if(HasParent(index) && GetParent(index) > _items[index])
		{
			Swap(GetParentIndex(index), index);
			index = GetParentIndex(index);
		}
	}
}