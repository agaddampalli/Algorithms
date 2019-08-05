<Query Kind="Program" />

void Main()
{
	var head = new Node(1);
	head.Next = new Node(3);
	head.Next.Next = new Node(2);
	
	MergerSortLL(head).Dump();
}

public class Node
{
	public int val { get; set; }
	public Node Next { get; set; }
	public Node Arbitary { get; set; }
	
	public Node()
	{
		
	}
	
	public Node(int val)
	{
		this.val = val;
	}
}

// 1 -- 3 -- 2

public Node MergerSortLL(Node head)
{
	if(head?.Next == null)
	{
		return head;
	}
	
	var middle = FindMiddle(head);
	var nextHalf = middle.Next;
	middle.Next = null;	
	
	var firstHalf = MergerSortLL(head);
	var secondHalf = MergerSortLL(nextHalf);
	
	return Merge(firstHalf, secondHalf);
}

public Node FindMiddle(Node node)
{
	if(node == null)
	{
		return null;
	}
	
	var slow = node;
	var fast = node;
	
	while(fast != null && fast.Next != null)
	{
		fast = fast.Next.Next;
		
		if(fast != null)
		{
			slow = slow.Next;
		}
	}
	
	return slow;
}

public Node Merge(Node a, Node b)
{
	if (a == null) return b;
	if (b == null) return a;
	
	Node result = new Node();
	var temp = result;
	
	while(a != null || b!=null)
	{
		if(a == null)
		{
			result.Next = b;
			b = b.Next;
		}
		else if(b == null)
		{
			result.Next = a;
			a = a.Next;
		}
		else if (a.val < b.val)
		{
			result.Next = a;
			a = a.Next;
		}
		else
		{
			result.Next = b;
			b = b.Next;
		}
		
		result = result.Next;
	}

	return temp.Next;
}