<Query Kind="Program" />

public class Node
{
	public Node(int value)
	{
		Value = value;
	}

	public int Value { get; set; }

	public Node NextNode { get; set; }
}

public class LinkedList
{
	public Node Head { get; set; }

	public Node Node { get; set; }

	public void Add(int value)
	{
		var node = Head;

		if (node == null)
		{
			Head = new Node(value);
			Node = Head;
			return;
		}

		while (node.NextNode != null)
		{
			node = node.NextNode;
		}

		node.NextNode = new Node(value);
	}



	public void AddAtStart(int value)
	{
		var node = new Node(value);
		node.NextNode = this.Head;
		this.Head = node;
	}



	public void Get()
	{
		if (Head == null)
		{
			return;
		}

		Print(Head);
	}

	public void Print(Node node)
	{
		int counter = 1;
		while (node != null)
		{
			Console.WriteLine($"Element at Node {counter}: {node.Value}");
			node = node.NextNode;
			counter++;
		}
	}

}

public static void Main()
{
	var linkedList = new LinkedList();
	linkedList.Add(7);
	linkedList.Add(5);
	linkedList.Add(9);
	linkedList.Add(4);
	linkedList.Add(6);

	var linkedList1 = new LinkedList();
	linkedList1.Add(8);
	linkedList1.Add(4);

	"*****First Linked List*****".Dump();
	linkedList.Get();

	"*****Second Linked List*****".Dump();
	linkedList1.Get();

	"*****Result Linked List*****".Dump();
	var resultNode = Sum(linkedList1.Head, linkedList.Head);
	linkedList.Print(resultNode);
}

private static Node Sum(Node node1, Node node2)
{
	Node resultNode = null;
	int carry = 0;
	while (node1 != null || node2 != null)
	{
		var sum = (node1 != null ? node1.Value : 0) + (node2 != null ? node2.Value : 0) + carry;
		if (sum / 10 > 0)
		{
			carry = sum / 10;
		}
		else
		{
			carry = 0;
		}

		if (resultNode == null)
		{
			resultNode = new Node(sum % 10);
		}
		else
		{
			Add(resultNode, sum % 10);
		}
		
		if (node1 != null)
		{
			node1 = node1.NextNode;
		}

		if (node2 != null)
		{
			node2 = node2.NextNode;
		}
	}

	if (carry > 0)
	{
		Add(resultNode, carry);
	}

	return resultNode;
}

private static void Add(Node node, int value)
{
	while (node.NextNode != null)
	{
		node = node.NextNode;
	}

	node.NextNode = new Node(value);
}

