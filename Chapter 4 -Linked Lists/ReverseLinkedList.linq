<Query Kind="Program" />

void Main()
{
	var node = new ListNode(1);
	node.next = new ListNode(2);
	node.next.next = new ListNode(3);
	node.next.next.next = new ListNode(4);

	ReverseList(node).Dump();

	ReverseListIterative(node).Dump();
}

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}

public ListNode ReverseList(ListNode head)
{
	if (head == null || head.next == null)
		return head;
		
	ListNode nextNode = head.next;
	ListNode newHead = ReverseList(nextNode);
	nextNode.next = head;
	head.next = null;
	return newHead;
}


public ListNode ReverseListIterative(ListNode head)
{
	if (head == null || head.next == null)
	{
		return head;
	}

	var output = new ListNode(head.val);
	head = head.next;

	while (head != null)
	{
		var temp = new ListNode(head.val);
		temp.next = output;
		output = temp;

		head = head.next;
	}

	return output;
}