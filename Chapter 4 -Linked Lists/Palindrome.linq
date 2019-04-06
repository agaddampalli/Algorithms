<Query Kind="Program" />

void Main()
{
	var input1 = new LinkedList(new Node(1));
	input1.Add(1);
	input1.Add(1);
	input1.Add(1);
	input1.Add(1);
	input1.Add(1);
	
	Palindrome(input1.Head).Dump();
}

public bool Palindrome(Node input)
{
	if(input.NextNode == null)
	{
		return true;
	}
	
	var pointer1 = input;
	var pointer2 = input;
	int length = 0;
	Stack<int> valuesStack = new Stack<int>();
	
	while(pointer1 != null)
	{
		pointer1 = pointer1.NextNode;
		length++;
		if(pointer1 != null)
		{
			pointer1 = pointer1.NextNode;
			length++;
		}
		
		valuesStack.Push(pointer2.Data);
		pointer2 = pointer2.NextNode;
	}
	
	if(length % 2 == 1)
	{
		valuesStack.Pop();
	}
	
	while(pointer2 != null)
	{
		var value = valuesStack.Pop();
		if(pointer2.Data != value)
		{
			return false;
		}
		
		pointer2 = pointer2.NextNode;
	}
	
	return true;
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