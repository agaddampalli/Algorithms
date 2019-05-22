<Query Kind="Program" />

void Main()
{
	var head = new Node();
	head.val = -1;
	
	head.next = new Node();
	head.next.val = 2;
	head.random = head.next;
	
	head.next.random = head.next;
	
	copyRandomList(head).Dump();
}

public class Node
{
	public int val;
	public Node next;
	public Node random;

	public Node() { }
	public Node(int _val, Node _next, Node _random)
	{
		val = _val;
		next = _next;
		random = _random;
	}
}

public Node CopyRandomList(Node head)
{
	var result = new Node();
	var node = result;
	var givenNode = head;
	var dictionary = new Dictionary<int, Node>();
	
	while(givenNode != null)
	{
		node.next = new Node();
		node.next.val = givenNode.val;
		dictionary.Add(givenNode.val, node.next);
		
		node = node.next;
		givenNode = givenNode.next;
	}
	
	node = result;
	node = node.next;
	while(head != null)
	{
		if(head.random != null)
		{
			node.random = dictionary[head.random.val];
		}
		node = node.next;
		head = head.next;	
	}
	
	return result.next;

}

public Node copyRandomList(Node head)
{
	if (head == null)
	{
		return null;
	}
	Node p = head;
	while (p != null)
	{
		Node copy = new Node(p.val, null, null);
		Node t = p.next;
		p.next = copy;
		copy.next = t;

		p = t;
	}

	p = head;
	while (p != null)
	{
		if (p.random != null)
		{
			p.next.random = p.random.next;
		}
		p = p.next.next;
	}


	Node ans = head.next;
	Node pAns = ans;
	p = head;
	while (p != null)
	{
		Node t = p.next.next;
		Node ansT = null;
		if (t != null)
		{
			ansT = t.next;
		}
		p.next = t;
		pAns.next = ansT;

		p = t;
		pAns = ansT;
	}

	return ans;

}
