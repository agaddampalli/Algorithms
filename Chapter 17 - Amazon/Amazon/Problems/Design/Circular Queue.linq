<Query Kind="Program" />

void Main()
{
	var queue = new MyCircularQueue(3);

	queue.IsEmpty();
	
	queue.EnQueue(1);
	queue.EnQueue(2);
	queue.EnQueue(3);
	
	queue.IsFull().Dump();
	
	queue.EnQueue(4);
	queue.queue.Dump();

	queue.DeQueue();
	queue.EnQueue(4);
	queue.queue.Dump();
}

public class MyCircularQueue
{
	public int[] queue {get;}
	private int front, rear = 0;
	private int size = 0;
	private int capacity;

	public MyCircularQueue(int k)
	{
		capacity = k;
		queue = new int[k];
	}

	public bool EnQueue(int value)
	{
		if(IsFull())
		{
			return false;
		}
		
		queue[rear++] = value;
		size++;
		rear = rear % capacity;
		return true;
	}

	public bool DeQueue()
	{
		if (IsEmpty())
		{
			return false;
		}
		
		var value = queue[front++];
		size--;
		front = front % capacity;
		return true;
	}

	public int Front()
	{
		if (IsEmpty())
		{
			return -1;
		}
		
		return queue[front];
	}

	public int Rear()
	{
		if (IsEmpty())
		{
			return -1;
		}
		
		return rear - 1 < 0 ? queue[capacity - 1] : queue[rear - 1];
	}

	public bool IsEmpty()
	{
		return size == 0;
	}

	public bool IsFull()
	{
		return size == capacity;
	}
}
