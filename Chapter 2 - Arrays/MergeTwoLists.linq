<Query Kind="Program" />

void Main()
{
	var ListNode1 = new ListNode(1);
	ListNode1.next = new ListNode(2);
	ListNode1.next.next = new ListNode(4);

	var ListNode2 = new ListNode(1);
	ListNode2.next = new ListNode(3);
	ListNode2.next.next = new ListNode(5);
	
	MergeTwoLists(ListNode1, ListNode2).Dump();
}

public ListNode MergeTwoLists(ListNode l1, ListNode l2)
{
	var result = new ListNode(0);
	
	while(l1 != null || l2 != null)
	{
		if(l1 == null)
		{
			Add(result, l2.val);
			l2 = l2.next;
		}
		else if(l2 == null)
		{
			Add(result, l1.val);
			l1 = l1.next;
		}
		else if(l1.val <= l2.val)
		{
			Add(result, l1.val);
			l1 = l1.next;
		}
		else
		{
			Add(result, l2.val);
			l2 = l2.next;
		}
	}
	
	return result.next;
}

public ListNode Add(ListNode node, int value)
{
	if (node == null)
	{
		return new ListNode(value);
	}

	while (node.next != null)
	{
		node = node.next;
	}

	node.next = new ListNode(value);
	
	return node;
}

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}