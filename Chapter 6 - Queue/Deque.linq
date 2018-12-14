<Query Kind="Program" />

void Main()
{
	var deque = new Deque<int>(5);

	deque.InsertFront(1);
	deque.InsertRear(2);
	deque.InsertFront(3);
	deque.InsertRear(4);
	deque.InsertRear(5);

	deque.Print();
	
	deque.DeleteRear();
	deque.GetRear();
}

// 1 insertatfront 1
// 2 1 insertAtRear 4

// middle = 4
// 2
// 0 0 0 0 0 0 0 0
public class Deque<T>
{
	private T[] _input;
	private int _front;
	private int _rear;
	private int _size;

	public Deque(int size)
	{
		_size = size;
		_front = -1;
		_rear = 0;
		_input = new T[_size];
	}

	public bool IsFull()
	{
		return (_front == 0 && _rear == _size - 1) || _front == _rear + 1;
	}

	public bool IsEmpty()
	{
		return (_front == -1 && _rear == -1);
	}

	public void InsertFront(T value)
	{
		if (IsFull())
		{
			throw new OverflowException("Queue is full");
		}

		if (_front == -1 && _rear == 0)
		{
			_front = 0;
			_rear = 0;
		}
		else if (_front == 0)
		{
			_front = _size - 1;
		}
		else
		{
			_front--;
		}

		_input[_front] = value;
	}

	public void DeleteFront()
	{
		if (IsEmpty())
		{
			throw new UnderflowException("Queue is Empty");
		}

		if (_front == _rear)
		{
			_front = -1;
			_rear = -1;
		}
		else
		{
			if (_front == _size - 1)
			{
				_front = 0;
			}
			else
			{
				_front++;
			}
		}
	}

	public void InsertRear(T value)
	{
		if (IsFull())
		{
			throw new OverflowException("Queue is full");
		}

		if (_front == -1 && _rear == 0)
		{
			_front = 0;
			_rear = 0;
		}
		else if (_rear == _size - 1)
		{
			_rear = 0;
		}
		else
		{
			_rear++;
		}

		_input[_rear] = value;
	}

	public void DeleteRear()
	{
		if (IsEmpty())
		{
			throw new UnderflowException("Queue is Empty");
		}

		if (_front == _rear)
		{
			_front = -1;
			_rear = -1;
		}
		else if (_rear == 0)
		{
			_rear = _size - 1;
		}
		else
		{
			_rear--;
		}
	}

	public void GetFront()
	{
		if (IsEmpty())
		{
			throw new UnderflowException("Queue is Empty");
		}

		_input[_front].Dump();
	}

	public void GetRear()
	{
		if (IsEmpty())
		{
			throw new UnderflowException("Queue is Empty");
		}

		_input[_rear].Dump();
	}
	
	public void Print()
	{
		for (int i = _front; i < _rear; i++)
		{
			_input[i].Dump();
		}
	}
}

public class UnderflowException : Exception
{
	public UnderflowException(string message) : base(message)
	{

	}
}
