<Query Kind="Program" />

void Main()
{
	var node1 = new ListNode(7);
	node1.next = new ListNode(2);
	node1.next.next = new ListNode(4);
	node1.next.next.next = new ListNode(3);

	var node2 = new ListNode(5);
	node2.next = new ListNode(6);
	node2.next.next = new ListNode(4);
	
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
	var length1 = GetLength(l1);
	var length2 = GetLength(l2);
	
	if(length1 > length2)
	{
		l2 = PadNode(l2, length1-length2);
	}

	if (length2 > length1)
	{
		l1 = PadNode(l1, length2 - length1);
	}
	
	var carry = Add(l1,l2);
	
	if(carry > 0)
	{
		var node = new ListNode(carry);
		node.next = l1;
		l1 = node;
	}
	
	return l1;
}

public int Add(ListNode l1, ListNode l2)
{
	if(l1==null && l2== null)
	{
		return 0;
	}

	var val1 = l1.val;
	var val2 = l2.val;
	
	var carry = Add(l1.next, l2.next);
	
	var sum = val1 + val2 + carry;
	
	l1.val = sum%10;
	
	return sum/10;
}

public int GetLength(ListNode l1)
{
	int count = 0;
	
	var node = l1;
	
	while(node != null)
	{
		++count;
		node = node.next;
	}
	
	return count;
}

public ListNode PadNode(ListNode l1, int length)
{
	for (int i = 0; i < length; i++)
	{
		var temp = new ListNode(0);
		temp.next = l1;
		l1 = temp;
	}
	
	return l1;
}