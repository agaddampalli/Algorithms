<Query Kind="Program" />

void Main()
{
	var input = new LinkedList(new Node(3));
	input.Add(5);
	input.Add(8);
	input.Add(5);
	input.Add(10);
	input.Add(2);
	input.Add(1);
	
	PartitionAroundX(input, 5).Print();
}

public LinkedList PartitionAroundX(LinkedList input, int partition)
{
	var node = input.Head;
	
	if(node == null || node.NextNode == null)
	{
		return input;
	}
	
	var previousNode = node;
	node = node.NextNode;
	
	while(node != null)
	{
		if(node.Data < partition)
		{
			var data = node.Data;
			previousNode.NextNode = node.NextNode;
			input.AddAtStart(data);
		}
		else
		{
			previousNode = node;
		}
		
		node = node.NextNode;
	}
	
	return input;
}


public class Node
{
	public int Data;

	public Node NextNode { get; set; }

	public Node(int data)
	{
		this.Data = data;
	}
}

public class LinkedList
{
	public Node Head;

	public LinkedList(Node node)
	{
		Head = node;
	}

	public void Add(int data)
	{
		var node = this.Head;

		while (node.NextNode != null)
		{
			node = node.NextNode;
		}

		node.NextNode = new Node(data);
	}

	public void AddAtStart(int data)
	{
		var node = new Node(data);
		
		node.NextNode = this.Head;
		
		this.Head = node;
	}

	public void Print()
	{
		var node = this.Head;

		while (node != null)
		{
			node.Data.Dump();
			node = node.NextNode;
		}
	}
}
