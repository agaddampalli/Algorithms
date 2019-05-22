<Query Kind="Program" />

void Main()
{
	var head = new Node(1);
	head.next = new Node(2);
	head.random = head.next;
	head.next.random = head.next;

	CopyRandomList(head).Dump();
}
public class Node
{
	public int val;
	public Node next;
	public Node random;

	public Node() { }
	public Node(int _val) { val = _val; }
	public Node(int _val, Node _next, Node _random)
	{
		val = _val;
		next = _next;
		random = _random;
	}
}

public Node CopyRandomList(Node head)
{
	if (head == null)
		return null;
	
	// insert copy node after orginal node
	var c = head;
	while (c != null)
	{
		var cNext = c.next;
		c.next = new Node();
		c.next.val = c.val;
		c.next.next = cNext;
		c = cNext;
	}
	
	//copy node point to copy random node
	c = head;
	while (c != null)
	{
		if (c.random != null)
			c.next.random = c.random.next;
		c = c.next.next;
	}
	// separate original linkedlist and copy one
	c = head;
	var copyHead = c.next;
	while (c != null && c.next != null)
	{
		var copy = c.next;
		c.next = copy.next;
		if (c.next != null)
			copy.next = c.next.next;
		c = c.next;
	}
	return copyHead;
}