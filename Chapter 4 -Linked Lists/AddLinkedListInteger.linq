<Query Kind="Program" />

void Main()
{
	var input1 = new LinkedList(new Node(7));
	input1.Add(1);
	input1.Add(6);

	var input2 = new LinkedList(new Node(5));
	input2.Add(9);
	input2.Add(2);

	AddLinkedListIntegerReverse(input1, input2).Print();
	"*******************************".Dump();

	var input3 = new LinkedList(new Node(6));
	input3.Add(1);
	input3.Add(7);

	var input4 = new LinkedList(new Node(2));
	input4.Add(9);
	input4.Add(5);
	input4.Add(5);
	
	var output = new LinkedList(new Node(0));
	var carry = AddLinkedListIntegerForward(input3.Head, input4.Head, output.Head);
	if (carry != 0)
	{
		output.Head.Data = carry;
	}
	output.Print();
}

public LinkedList AddLinkedListIntegerReverse(LinkedList input1, LinkedList input2)
{
	var node1 = input1.Head;
	var node2 = input2.Head;
	LinkedList output = new LinkedList(new Node(0));

	int carry = 0;

	while (node1 != null || node2 != null)
	{
		var node1Data = 0;
		if (node1 != null)
		{
			node1Data = node1.Data;
			node1 = node1.NextNode;
		}

		var node2Data = 0;
		if (node2 != null)
		{
			node2Data = node2.Data;
			node2 = node2.NextNode;
		}

		var sum = node1Data + node2Data + carry;
		output.Add(sum % 10);
		carry = sum / 10;
	}

	if (carry != 0)
	{
		output.Add(carry);
	}

	output.Head = output.Head.NextNode;

	return output;
}

public int AddLinkedListIntegerForward(Node input1, Node input2, Node output)
{
	if (input1 == null && input2 == null)
	{
		return 0;
	}

	var carry = AddLinkedListIntegerForward( input1 != null ? input1.NextNode : input1, input2 != null ? input2.NextNode : input2, output);

	var node1Data = 0;
	if (input1 != null)
	{
		node1Data = input1.Data;
	}

	var node2Data = 0;
	if (input2 != null)
	{
		node2Data = input2.Data;
	}
	var sum = node1Data + node2Data + carry;
	if(output.NextNode == null)
	{
		output.NextNode = new Node(sum % 10);
		output = output.NextNode;
	}

	return sum / 10;

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
