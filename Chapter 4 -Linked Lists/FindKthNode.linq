<Query Kind="Program" />

void Main()
{
	var input = new LinkedList(new Node(1));
	input.Add(2);
	input.Add(3);
	input.Add(4);
	input.Add(5);
	input.Add(6);
	input.Add(7);
	input.Add(8);
	input.Add(9);

	input.Print();
	"*******************************".Dump();
	FindKthNodeFromLast(input, 1).Dump();
	"*******************************".Dump();
	DeleteMiddleNode(input).Print();
	"*******************************".Dump();
	DeleteANode(input.Head.NextNode.NextNode).Dump();
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

public Node FindKthNodeFromLast(LinkedList input, int k)
{
	if (input == null || input.Head == null)
	{
		return null;
	}

	if(input.Head.NextNode == null)
	{
		return input.Head;
	}
	
	Node pointer1 = input.Head;
	Node pointer2 = input.Head;

	int count = 0;
	while (count < k && pointer2 != null)
	{
		pointer2 = pointer2.NextNode;
		count++;
	}

	while (pointer2 != null)
	{
		pointer2 = pointer2.NextNode;
		pointer1 = pointer1.NextNode;
	}

	return pointer1;
}

public LinkedList DeleteMiddleNode(LinkedList input)
{
	if (input == null || input.Head == null || input.Head.NextNode == null)
	{
		return input;
	}
	
	Node pointer1 = input.Head;
	Node pointer2 = input.Head;
	Node previousNode = pointer1;
	
	while(pointer2 != null)
	{
		int count = 0;
		while (count < 2 && pointer2 != null)
		{
			pointer2 = pointer2.NextNode;
			count++;
		}
		
		if(pointer2 == null && pointer1.NextNode != null)
		{
			previousNode.NextNode =  pointer1.NextNode;
		}
		else
		{
			previousNode = pointer1;
			pointer1 = pointer1.NextNode;
		}
	}
	
	return input;
}

public Node DeleteANode(Node input)
{
	if (input == null || input.NextNode == null)
	{
		return input;
	}

	Node nextNode = input.NextNode;
	input.Data = nextNode.Data;
	input.NextNode = nextNode.NextNode;

	return input;
}