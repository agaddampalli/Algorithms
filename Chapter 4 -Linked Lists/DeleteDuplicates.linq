<Query Kind="Program" />

void Main()
{
	var input = new LinkedList(new Node(1));
	input.Add(2);
	input.Add(2);
	input.Add(3);
	input.Add(1);
	input.Add(5);
	input.Add(2);
	input.Add(3);
	input.Add(4);
	
	input.Print();
	"*******************************".Dump();
	DeleteDuplicateNodes(input).Print();
	"*******************************".Dump();
	DeleteDuplicateNodes1(input).Print();
}

public class Node
{
	public int Data;
	
	public Node NextNode {get; set;}
	
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
		Head  = node;
	}
	
	public void Add(int data)
	{
		var node = this.Head;
		
		while(node.NextNode != null)
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

public LinkedList DeleteDuplicateNodes(LinkedList input)
{
	if(input == null || input.Head == null || input.Head.NextNode == null)
	{
		return input;
	}
	
	Node previousNode = input.Head;
	var inputHashSet = new HashSet<int>();
	var nextNode = input.Head.NextNode;
	inputHashSet.Add(previousNode.Data);
	
	while(nextNode != null)
	{
		if(inputHashSet.Contains(nextNode.Data))
		{
			previousNode.NextNode = nextNode.NextNode;
		}
		else
		{
			inputHashSet.Add(nextNode.Data);
			previousNode = nextNode;
		}
		nextNode = nextNode.NextNode;
	}
	
	return input;
}

public LinkedList DeleteDuplicateNodes1(LinkedList input)
{
	if (input == null || input.Head == null || input.Head.NextNode == null)
	{
		return input;
	}

	Node pointer1 = input.Head;


	while (pointer1 != null)
	{
		Node pointer2 = pointer1.NextNode;
		Node previousNode = pointer1;
		while(pointer2 != null)
		{
			if(pointer1.Data == pointer2.Data)
			{
				previousNode.NextNode = pointer2.NextNode;
			}
			else
			{
				previousNode = pointer2;
			}
			
			pointer2 = pointer2.NextNode;
		}
		
		pointer1 = pointer1.NextNode;
	}

	return input;
}