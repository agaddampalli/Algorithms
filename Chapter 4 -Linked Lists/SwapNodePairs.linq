<Query Kind="Program" />

void Main()
{
	var head = new ListNode(1);
	head.next = new ListNode(2);
	head.next.next = new ListNode(3);
	head.next.next.next = new ListNode(4);
	
	SwapPairs(head).Dump();
}

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}

public ListNode SwapPairs(ListNode head)
{
	if(head == null || head.next == null)
	{
		return head;
	}
	
	var temp = head.val;
	head.val = head.next.val;
	head.next.val = temp;
	
	SwapPairs(head.next.next);
	
	return head;
}