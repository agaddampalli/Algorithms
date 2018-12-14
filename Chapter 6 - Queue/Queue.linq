<Query Kind="Program" />

void Main()
{
	var newQueue = new Queue<int>();

	newQueue.Enqueue(1);
	newQueue.Enqueue(2);
	newQueue.Enqueue(3);
	newQueue.Enqueue(4);
	newQueue.Enqueue(5);
	
	newQueue.Print();

	"**********************".Dump();
	newQueue.Dequeue().Dump();
	newQueue.Dequeue().Dump();
	newQueue.Front().Dump();
	newQueue.Rear().Dump();

	"**********************".Dump();
	newQueue.Print();
}


// 1 2 3 4
public class Queue<T>
{
	private T[] _input;
	private int _front;
	private int _rear;
	private int _size;
	
	public Queue()
	{
		_size = 4;
		_front = 0;
		_rear = 0;
		_input = new T[_size];
	}
	
	public void Enqueue(T value)
	{
		if(_rear == _size)
		{
			var newArray = new T[_size*2];
			Array.Copy(_input, _front, newArray, 0 ,_size);
			_input = newArray;
			_size = _size * 2;
		}
		
		_input[_rear] = value;
		_rear++;
	}

	public T Dequeue()
	{
		if(_front == _rear)
		{
			throw new InvalidOperationException();
		}
		return _input[_front++];
	}
	
	public T Front()
	{
		return _input[_front];
	}

	public T Rear()
	{
		return _input[_rear-1];
	}
	
	public void Print()
	{
		for (int i = _front; i < _rear; i++)
		{
			_input[i].Dump();
		}
	}
}