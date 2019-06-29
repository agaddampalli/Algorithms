<Query Kind="Program" />

void Main()
{
	var movingAverage = new MovingAverage(3);
	movingAverage.Next(1).Dump();
	movingAverage.Next(10).Dump();
	movingAverage.Next(3).Dump();
	movingAverage.Next(5).Dump();
}

public class MovingAverage
{
	private Queue<int> queue;
	private int windowSize;
	private int sum;
	
	public MovingAverage(int size)
	{
		windowSize = size;
		queue = new Queue<int>(size);
	}

	public double Next(int val)
	{
		if (queue.Count == windowSize)
        {
            sum -= queue.Dequeue();
        }

        sum += val;
        queue.Enqueue(val);

        return (double)sum / queue.Count;
	}
}
