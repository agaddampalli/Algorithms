<Query Kind="Program" />

void Main()
{
	generateParenthesis(3).Dump();
}

public List<String> generateParenthesis(int n)
{
	List<String> ans = new List<String>();
	backtrack(ans, "", 0, 0, n);
	return ans;
}

public void backtrack(List<String> ans, String cur, int open, int close, int max)
{
	if (cur.Length == max * 2)
	{
		ans.Add(cur);
		return;
	}

	if (open < max)
	{
		backtrack(ans, cur + "(", open + 1, close, max);
		
	}
	if (close < open)
		backtrack(ans, cur + ")", open, close + 1, max);
}
