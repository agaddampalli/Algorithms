<Query Kind="Program" />

void Main()
{
	var head = new ListNode(1);
	head.next = new ListNode(2);
	head.next.next = new ListNode(2);
	head.next.next.next = new ListNode(1);
	
	
	RemoveElements(head, 2).Dump();
}

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}

public ListNode RemoveElements(ListNode head, int val)
{

	if (head == null)
	{
		return head;
	}

	while (head != null && head.val == val)
	{
		head = head.next;
	}

	var node = head;
	var prev = head;

	while (node != null)
	{
		if (node.val == val)
		{
			if(node.next != null)
			{
				prev.next = node.next;
			}
			else
			{
				prev.next = null;
			}
		}
		else
		{
			prev = node;
		}
		
		node = node.next;
	}

	return head;
}
