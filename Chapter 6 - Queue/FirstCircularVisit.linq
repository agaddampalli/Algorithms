<Query Kind="Program" />

void Main()
{
	// {4, 6}, {6, 5}, {7, 3} and {4, 5}

	var gasStations = new List<GasStation>{
		new GasStation(4, 6),
		new GasStation(6, 5),
		new GasStation(7, 9),
		new GasStation(12, 5),
	};

	printTour(gasStations).Dump();

}

public static int printTour(List<GasStation> arr)
{
	int start = 0;
	int end = 1;
	int curr_petrol = arr[start].Gas -
					  arr[start].Distance;

	int n = arr.Count;
	// If current amount of petrol in   
	// truck becomes less than 0, then  
	// remove the starting petrol pump from tour  
	while (end != start || curr_petrol < 0)
	{

		// If current amount of petrol in 
		// truck becomes less than 0, then  
		// remove the starting petrol pump from tour  
		while (curr_petrol < 0 && start != end)
		{
			// Remove starting petrol pump. 
			// Change start  
			curr_petrol -= arr[start].Gas -
						   arr[start].Distance;
			start = (start + 1) % n;

			// If 0 is being considered as  
			// start again, then there is no  
			// possible solution  
			if (start == 0)
			{
				return -1;
			}
		}

		// Add a petrol pump to current tour  
		curr_petrol += arr[end].Gas -
					   arr[end].Distance;

		end = (end + 1) % n;
	}

	// Return starting point  
	return start;
}

public class GasStation
{
	public int Gas;
	public int Distance;

	// constructor  
	public GasStation(int gas,
					  int distance)
	{
		this.Gas = gas;
		this.Distance = distance;
	}
}

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

	public bool IsEmpty()
	{
		return _front == 0 && _rear == 0;
	}

	public void Enqueue(T value)
	{
		if (_rear == _size)
		{
			var newArray = new T[_size * 2];
			Array.Copy(_input, _front, newArray, 0, _size);
			_input = newArray;
			_size = _size * 2;
		}

		_input[_rear] = value;
		_rear++;
	}

	public T Dequeue()
	{
		if (_front == _rear)
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
		return _input[_rear - 1];
	}

	public void Print()
	{
		for (int i = _front; i < _rear; i++)
		{
			_input[i].Dump();
		}
	}
}