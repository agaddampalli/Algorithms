<Query Kind="Program" />

void Main()
{
	var l1 = new ListNode(1)
	{
		next = new ListNode(9)
		{
			next = new ListNode(8)
		}
	};
	
	var l2 = new ListNode(0)
	{
		next = null
	};
	
	AddTwoNumbers(l1,l2).Dump();
}



public class ListNode {
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}

private static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
{
    if (l1 == null)
    {
        return l2;
    }

    if (l2 == null)
    {
        return l2;
    }

    ListNode output = null;
    AddTwoNumbers(l1, l2, ref output, 0);
    return output;
}

public static void AddTwoNumbers(ListNode l1, ListNode l2,ref ListNode output, int carry)
{
    var sum = Convert.ToInt32(l1?.val) + Convert.ToInt32(l2?.val) + carry;
    if (sum >= 10)
    {
        carry = sum / 10;
        AddItem(ref output, sum % 10);
    }
    else
    {
        AddItem(ref output, sum);
		carry = 0;
    }

    if (l1?.next != null || l2?.next != null)
    {
        AddTwoNumbers(l1?.next, l2?.next, ref output, carry);
    }
	else if(carry > 0)
    {
        AddItem(ref output, carry);
    }
}

public static void AddItem(ref ListNode output, int value)
{
    if (output == null)
    {
        output = new ListNode(value);
        return;
    }

    if (output.next != null)
    {
        AddItem(ref output.next, value);
		return;
    }

    output.next = new ListNode(value);
}