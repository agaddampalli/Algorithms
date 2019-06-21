<Query Kind="Program" />

void Main()
{
	var node = new ListNode(1);
	node.next = new ListNode(1);
	node.next.next = new ListNode(1);
	node.next.next.next = new ListNode(2);
	node.next.next.next.next = new ListNode(3);
	node.next.next.next.next.next = new ListNode(3);
	
	DeleteDuplicates(node).Dump();
}

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}

public ListNode DeleteDuplicates(ListNode head)
{
	if(head == null)
	{
		return head;
	}
	
	var node = head;
	
	while(node.next != null)
	{
		if(node.val == node.next.val)
		{
			node.next = node.next.next;
		}
		else
		{
			node = node.next;
		}
	}
	
	return head;
}
