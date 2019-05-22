<Query Kind="Program" />

void Main()
{
	var node1 = new ListNode(1);
	node1.next = new ListNode(2);
	node1.next.next = new ListNode(3);

	var node2 = new ListNode(0);
	node2.next = new ListNode(1);
	node2.next.next = new ListNode(2);

	MergeTwoListsIterative(node1, node2).Dump();
}

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}

public ListNode MergeTwoLists(ListNode l1, ListNode l2)
{
	ListNode output = new ListNode(0);

	MergeTwoListsRecursive(l1,l2,output);
	return output.next;
}

public ListNode MergeTwoListsRecursive(ListNode l1, ListNode l2, ListNode output)
{
	if(l1 == null && l2 == null)
	{
		return output;
	}
	
	if (l1 == null)
	{
		output.next = l2;
		l2 = l2.next;
	}
	else if (l2 == null)
	{
		output.next = l1;
		l1 = l1.next;
	}
	else if (l1.val < l2.val)
	{
		output.next = l1;
		l1 = l1.next;
	}
	else
	{
		output.next = l2;
		l2 = l2.next;
	}

	MergeTwoListsRecursive(l1, l2, output.next);
	
	return output;
}


public ListNode MergeTwoListsIterative(ListNode l1, ListNode l2)
{
	ListNode output = new ListNode(0);
	ListNode output1 = null;
	output1 = output;
	while (l1 != null || l2 != null)
	{
		if (l1 == null)
		{
			output.next = l2;
			output = output.next;
			l2 = l2.next;
		}
		else if (l2 == null)
		{
			output.next = l1;
			output = output.next;
			l1 = l1.next;
		}
		else if (l1.val < l2.val)
		{
			output.next = l1;
			output = output.next;
			l1 = l1.next;
		}
		else
		{
			output.next = l2;
			output = output.next;
			l2 = l2.next;
		}
	}

	return output1.next;
}

public void Add(ListNode head, int value)
{
	var node = head;

	while (node.next != null)
	{
		node = node.next;
	}

	node.next = new ListNode(value);
}