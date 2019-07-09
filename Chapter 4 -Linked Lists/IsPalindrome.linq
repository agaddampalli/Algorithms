<Query Kind="Program" />

void Main()
{

}

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}

public bool IsPalindrome(ListNode head)
{
	if ((head == null) || (head.next == null))
		return true;
		
	var slow = head;
	var fast = head;
	ListNode prev = null;
	
	while(fast != null && fast.next != null)
	{
		prev = slow;
		slow = slow.next;
		fast = fast.next.next;
	}
	
	if(prev != null)
	{
		prev.next = null;
	}
	
	
	var firstHead = Reverse(head);
	var secondHead = fast == null ? slow : slow.next;

	while (firstHead != null)
	{
		if (firstHead.val != secondHead.val)
			return false;
		firstHead = firstHead.next;
		secondHead = secondHead.next;
	}
	
	return true;
}

public ListNode Reverse(ListNode node)
{
	ListNode curr = node;
	ListNode prev = null;
	
	// 1 -- 2 -- 3 --4
	while(curr != null)
	{
		ListNode next = curr.next;
		curr.next = prev;
		prev = curr;
		curr = next;
	}
	
	return prev;
}
