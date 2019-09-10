<Query Kind="Program" />

void Main()
{
	
}

public class MedianFinder
{
	private Heap low;
	private Heap high;

	public MedianFinder()
	{
		high = new Heap(HeapType.Min);
		low = new Heap(HeapType.Max);
	}

	public void AddNum(int num)
	{
		low.Enqueue(num);
		high.Enqueue(low.Dequeue());

		if (low.Count() < high.Count())
		{
			low.Enqueue(high.Dequeue());
		}
	}

	public double FindMedian()
	{
		if (high.Count() == low.Count())
		{
			var value1 = high.Peek();
			var value2 = low.Peek();

			return (double)(value1 + value2) / 2;
		}

		return low.Peek();
	}
}

public enum HeapType
{
	Min,

	Max
}

public class Heap
{
	private int capacity = 4;
	private int currentIndex = 0;
	private HeapType heapType;
	private int[] data;

	public Heap(HeapType type)
	{
		data = new int[capacity];
		heapType = type;
	}

	public int GetLeftChildIndex(int parentIndex) { return 2 * parentIndex + 1; }
	public int GetRightChildIndex(int parentIndex) { return 2 * parentIndex + 2; }
	public int GetParentIndex(int childIndex) { return (childIndex - 1) / 2; }

	public bool HasLeftChild(int parentIndex) { return GetLeftChildIndex(parentIndex) < currentIndex; }
	public bool HasRightChild(int parentIndex) { return GetRightChildIndex(parentIndex) < currentIndex; }
	public bool HasParent(int childIndex) { return GetParentIndex(childIndex) >= 0; }

	public int GetLeftChild(int parentIndex) { return data[GetLeftChildIndex(parentIndex)]; }
	public int GetRightChild(int parentIndex) { return data[GetRightChildIndex(parentIndex)]; }
	public int GetParent(int childIndex) { return data[GetParentIndex(childIndex)]; }

	public int Peek()
	{
		if (currentIndex == 0)
		{
			throw new InvalidOperationException();
		}

		return data[0];
	}

	public int Count()
	{
		return currentIndex;
	}

	public void Enqueue(int val)
	{
		EnsureCapacity();
		data[currentIndex++] = val;
		HeapifyUp();
	}

	public int Dequeue()
	{
		if (currentIndex == 0)
		{
			throw new InvalidOperationException();
		}

		var val = data[0];
		data[0] = data[currentIndex - 1];
		data[currentIndex - 1] = 0;
		currentIndex--;

		HeapifyDown();
		return val;
	}

	private void EnsureCapacity()
	{
		if (currentIndex == capacity)
		{
			capacity = capacity * 2;
			var temp = new int[capacity];
			Array.Copy(data, temp, data.Length);
			data = temp;
		}
	}

	private void HeapifyUp()
	{
		var index = currentIndex - 1;

		while (HasParent(index) && CompareForHeapifyUp(data[index], GetParent(index)))
		{
			Swap(index, GetParentIndex(index));
			index = GetParentIndex(index);
		}
	}

	private void HeapifyDown()
	{
		var index = 0;

		while (HasLeftChild(index))
		{
			var val = GetLeftChild(index);
			var indexToSwap = GetLeftChildIndex(index);

			var isRightIndexToSwap = HasRightChild(index) &&
										(heapType == HeapType.Min ? GetRightChild(index) < val : GetRightChild(index) > val);
			if (isRightIndexToSwap)
			{
				indexToSwap = GetRightChildIndex(index);
			}

			var shouldSwap = heapType == HeapType.Min ? data[indexToSwap] >= data[index] : data[indexToSwap] < data[index];
			if (shouldSwap)
			{
				break;
			}
			else
			{
				Swap(index, indexToSwap);
			}

			index = indexToSwap;
		}
	}

	private void Swap(int i, int j)
	{
		var temp = data[i];
		data[i] = data[j];
		data[j] = temp;
	}

	private bool CompareForHeapifyUp(int x, int y)
	{
		switch (heapType)
		{
			case HeapType.Max:
				return x > y;
			default:
				return x < y;
		}
	}
}