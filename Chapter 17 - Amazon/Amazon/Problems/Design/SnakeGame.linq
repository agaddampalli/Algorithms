<Query Kind="Program" />

void Main()
{

}

public class SnakeGame
{
	private int width, height = 0;
	private int[][] food;
	private int foodIndex;
	private LinkedList<Point> snake;

	public SnakeGame(int width, int height, int[][] food)
	{
		this.width = width;
		this.height = height;
		this.food = food;
		this.foodIndex = 0;

		snake = new LinkedList<Point>();
		var start = new Point(0, 0);
		snake.AddFirst(start);
	}

	public int Move(string direction)
	{
		var dirs = GetDirections(direction);
		var currentPosition = snake.First();

		var x = currentPosition.x + dirs[0];
		var y = currentPosition.y + dirs[1];
		
		if(IsBoundary(x,y))
		{
			return -1;
		}
		
		var oldPosition = snake.Last();
		snake.RemoveLast();
		
		foreach (var point in snake)
		{
			if(point.x == x && point.y == y)
			{
				return -1;
			}
		}
		
		snake.AddFirst(new Point(x,y));
		
		if(foodIndex < food.Length && food[foodIndex][0] == x && food[foodIndex][1] == y)
		{
			snake.AddLast(oldPosition);
			foodIndex++;
		}
		
		return foodIndex;
	}

	private int[] GetDirections(string direction)
	{
		switch (direction)
		{
			case "U":
				return new int[] { -1, 0 };
			case "D":
				return new int[] { 1, 0 };
			case "L":
				return new int[] { 0, -1 };
			case "R":
				return new int[] { 0, 1 };
			default:
				return new int[] { 0, 0 };
		}
	}

	private bool IsBoundary(int x, int y)
	{
		return x < 0 || x > height-1 || y < 0 || y > width-1;
	}
}

public class Point
{
	public int x { get; set; }
	public int y { get; set; }

	public Point(int x, int y)
	{
		this.x = x;
		this.y = y;
	}
}
