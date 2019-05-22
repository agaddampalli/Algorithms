<Query Kind="Program" />

void Main()
{
	var node1 = new ListNode(5);
//	node1.next = new ListNode(4);
//	node1.next.next = new ListNode(3);

	var node2 = new ListNode(5);
//	node2.next = new ListNode(6);
//	node2.next.next = new ListNode(4);
	
	AddTwoNumbers(node1, node2).Dump();
}

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}

public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
{
	return AddTwoNumbers(l1,l2,0);
}

public ListNode AddTwoNumbers(ListNode l1, ListNode l2, int carry)
{
	if (l1 == null && l2 == null)
	{
		return null;
	}
	
	var sum = (l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0) + carry;
	carry = sum/10;
	if(l1 != null)
	{
		l1.val = sum % 10;
	}
	else
	{
		l1 = new ListNode(sum % 10);	
	}
	
	if(l1.next == null && (l2?.next != null || carry > 0))
	{
		l1.next = new ListNode(0);
	}
	
	AddTwoNumbers(l1.next, l2 != null ? l2.next : null, carry);
	
	return l1;
}
