<Query Kind="Program" />

void Main()
{
	var input = new CatDogShelter();

	input.Enqueue("Dog");
	input.Enqueue("Dog");
	input.Enqueue("Cat");
	input.Enqueue("Dog");
	input.Enqueue("Cat");
	input.Enqueue("Dog");
	input.Enqueue("Cat");
	input.Enqueue("Dog");

	input.DequeueCat().Dump();
	input.DequeueAny().Dump();
	input.DequeueAny().Dump();
	input.DequeueAny().Dump();
	input.DequeueDog().Dump();
	input.DequeueAny().Dump();
	input.DequeueAny().Dump();
}

public class CatDogShelter
{
	public LinkedList<Node> catShelter = new LinkedList<Node>();
	public LinkedList<Node> dogShelter = new LinkedList<Node>();
	private int order;
	
	public void Enqueue(string input)
	{
		if(input == "Dog")
		{
			dogShelter.AddLast(new Node(input, order++));
		}
		else
		{
			catShelter.AddLast(new Node(input, order++));
		}
	}
	
	public string DequeueAny()
	{
		var dogNode = dogShelter.First();
		var catNode = catShelter.First();
		if(dogNode.order < catNode.order)
		{
			dogShelter.RemoveFirst();
			return dogNode.value;
		}
		else
		{
			catShelter.RemoveFirst();
			return catNode.value;
		}
	}

	public string DequeueDog()
	{
		var value = dogShelter.First();
		dogShelter.RemoveFirst();
		
		return value.value;
	}

	public string DequeueCat()
	{
		var value = catShelter.First();
		catShelter.RemoveFirst();

		return value.value;
	}
}

public class Node
{
	public string value {get; set;}
	
	public int order {get; set;}
	
	public Node(string value, int order)
	{
		this.value = value;
		this.order = order;
	}
}