<Query Kind="Program" />

void Main()
{
	var input1 = new LinkedList(new Node(1));
	input1.Add(2);
	input1.Add(3);
	input1.Add(4);
	input1.Add(5);

	"**********input1*************".Dump();
	input1.Print();
	
	var input2 = new LinkedList(new Node(5));
	input2.Add(9);
	input2.Add(2);
	input2.Head.NextNode.NextNode.NextNode = input1.Head.NextNode.NextNode;

	"**********input2*************".Dump();
	input2.Print();

	var input3 = new LinkedList(new Node(1));
	input3.Add(2);
	input3.Add(3);
	input3.Add(4);
	input3.Add(5);

	"**********input3*************".Dump();
	input3.Print();
	"**********Output*************".Dump();
	Intersect(input1.Head, input2.Head).Dump();
	Intersect(input1.Head, input3.Head).Dump();
	Intersect(input2.Head, input3.Head).Dump();

}

public bool Intersect(Node input1, Node input2)
{
	HashSet<Node> inputhashSet = new HashSet<Node>();
	
	while(input1 != null)
	{
		inputhashSet.Add(input1);
		input1 = input1.NextNode;
	}
	
	while(input2 != null)
	{
		if(inputhashSet.Contains(input2))
		{
			return true;
		}
		
		input2 = input2.NextNode;
	}
	
	
	return false;
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