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


	public void rotate(int k)
	{
		if (k == 0) return;

		// Let us understand the below code for example k = 4 
		// and list = 10->20->30->40->50->60. 
		Node current = Head;

		// current will either point to kth or NULL after this 
		// loop. current will point to node 40 in the above example 
		int count = 1;
		while (count < k && current != null)
		{
			current = current.NextNode;
			count++;
		}

		// If current is NULL, k is greater than or equal to count 
		// of nodes in linked list. Don't change the list in this case 
		if (current == null)
			return;

		// current points to kth node. Store it in a variable. 
		// kthNode points to node 40 in the above example 
		Node kthNode = current;

		// current will point to last node after this loop 
		// current will point to node 60 in the above example 
		while (current.NextNode != null)
			current = current.NextNode;

		// Change next of last node to previous head 
		// Next of 60 is now changed to node 10 

		current.NextNode = Head;

		// Change head to (k+1)th node 
		// head is now changed to node 50 
		Head = kthNode.NextNode;

		// change next of kth node to null 
		kthNode.NextNode = null;

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
	
	"*****First Linked List*****".Dump();
	linkedList.Get();
	
	"*****Result Linked List*****".Dump();
	linkedList.rotate(2);
	linkedList.Get();
}


