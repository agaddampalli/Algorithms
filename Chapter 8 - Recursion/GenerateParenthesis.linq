<Query Kind="Program" />

void Main()
{
	GenerateParenthesis(3).Dump();
}

public IList<string> GenerateParenthesis(int n)
{
	var output = new List<string>();

	if (n == 0)
	{
		return output;
	}

	Generate(n, 0, 0, "", output);

	return output;
}

public void Generate(int n, int open, int close, string value, List<string> output)
{
	if (value.Length == n * 2)
	{
		output.Add(value);
		return;
	}

	if (open < n)
	{
		Generate(n, ++open, close, value + "(", output);
	}


	if (close < n)
	{
		Generate(n, open, ++close, value + ")", output);
	}
}