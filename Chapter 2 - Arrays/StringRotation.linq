<Query Kind="Program" />

void Main()
{
	StringRotation("waterbottle", "elwaterbott").Dump();
}

public bool StringRotation(string input, string rotatedString)
{
	if (input.Length != rotatedString.Length)
	{
		return false;
	}

	int len = input.Length;
	/* Check that sl and s2 are equal length and not empty*/
	if (len == rotatedString.Length && len > 0)
	{
		/* Concatenate sl and sl within new buffer */
		string slsl = input + input;
		return slsl.Contains(rotatedString);
	}
	return false;
}