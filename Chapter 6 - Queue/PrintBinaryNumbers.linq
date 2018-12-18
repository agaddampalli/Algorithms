<Query Kind="Program" />

void Main()
{
	int n = 10;
	generatePrintBinary(n);
}

public static void generatePrintBinary(int n)
{
	// Create an empty queue of strings  
	LinkedList<string> q = new LinkedList<string>();

	// Enqueue the first binary number  
	q.AddLast("1");

	// This loops is like BFS of a tree  
	// with 1 as root 0 as left child  
	// and 1 as right child and so on  
	while (n-- > 0)
	{
		// print the front of queue  
		string s1 = q.First.Value;
		q.RemoveFirst();
		Console.WriteLine(s1);

		// Store s1 before changing it  
		string s2 = s1;

		// Append "0" to s1 and enqueue it  
		q.AddLast(s1 + "0");

		// Append "1" to s2 and enqueue it.  
		// Note that s2 contains the previous front  
		q.AddLast(s2 + "1");
	}
}
