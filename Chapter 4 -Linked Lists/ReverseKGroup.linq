<Query Kind="Program" />

void Main()
{
	var node = new ListNode(1);
	node.next = new ListNode(2);
	node.next.next = new ListNode(3);
	node.next.next.next = new ListNode(4); 
	
	ReverseKGroup(node, 2).Dump();
}

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}

public ListNode ReverseKGroup(ListNode head, int k)
{
	if(head == null)
	{
		return head;
	}


	var result = new ListNode(0);
	result.next = head;
	var node = head;
	var current = node;
	int count = 1;
	while(node != null)
	{
		if(count == k)
		{
			var next = node.next;
			node.next = null;
			result.next = Reverse(head);
			count = 0;
		}
		node = node.next;
		count++;
	}
	
	return head;
}

public ListNode Reverse(ListNode head)
{
	if(head == null || head.next == null)
	{
		return head;
	}
	
	var nextNode = head.next;
	var newHead = Reverse(nextNode);
	nextNode.next = head;
	head.next = null;
	return newHead;
}

