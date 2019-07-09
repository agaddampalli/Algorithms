<Query Kind="Program" />

void Main()
{
	var source = new string[] {"main() {", "   func(1);", "   /** / more comments here", "   float f = 2.0", "   f += f;", "   cout << f; */", "}"};

	RemoveComments(source).Dump();
}

public IList<string> RemoveComments(string[] source)
{
	var output = new List<string>();

	if (source == null || source.Length == 0)
	{
		return output;
	}

	bool isBlock = false;
	bool isLine = false;
	StringBuilder sb = null;
	Stack<char> stack = null;
	for (int i = 0; i < source.Length; i++)
	{
		if (!isBlock)
		{
			sb = new StringBuilder();
			stack = new Stack<char>();
		}

		var temp = source[i];
		for (int j = 0; j < temp.Length; j++)
		{
			if (!isBlock && !isLine && temp[j] == '/')
			{
				if(j + 1 < temp.Length)
				{
					if (temp[j + 1] == '/')
					{
						isLine = true;
						j++;
					}
					else if (temp[j + 1] == '*')
					{
						isBlock = true;
						stack.Push(temp[j]);
						stack.Push(temp[j + 1]);
						j++;
					}
					else
					{
						sb.Append(temp[j]);
					}
				}
				else
				{
					sb.Append(temp[j]);
				}
			}
			else
			{
				if (isBlock && stack.Count != 0)
				{
					var character = stack.Peek();
					if (character == '*' && character == temp[j])
					{
						if (j + 1 < temp.Length && temp[j + 1] == '/')
						{
							stack.Pop();
							stack.Pop();
							j++;
						}
					}

				}

				if (!isLine && !isBlock)
				{
					sb.Append(temp[j]);
				}

				if (stack.Count == 0)
				{
					isBlock = false;
				}
			}
		}

		if(!isLine && !isBlock && !string.IsNullOrEmpty(sb.ToString()))
		{
			output.Add(sb.ToString());
		}
		
		if (isLine)
		{
			if(!string.IsNullOrEmpty(sb.ToString()))
				output.Add(sb.ToString());
			isLine = false;
		}

		if (isBlock && stack.Count == 0)
		{
			if (!string.IsNullOrEmpty(sb.ToString()))
				output.Add(sb.ToString());
			isBlock = false;
		}
	}

	return output;
}

public IList<string> RemoveComments1(string[] source)
{
	IList<string> result = new List<string>();
	if (source == null || source.Length == 0)
		return result;

	bool comment = false;
	StringBuilder sb = new StringBuilder();

	for (int i = 0; i < source.Length; i++)
	{
		string line = source[i];
		int j = 0;
		for (; j < line.Length; j++)
		{
			if (!comment && (j < line.Length - 1 && line.Substring(j, 2) == "/*"))
			{
				comment = true; ++j;
				continue;
			}

			if (comment && (j < line.Length - 1 && line.Substring(j, 2) == "*/"))
			{
				comment = false; ++j;
				continue;
			}

			if (!comment && (j < line.Length - 1 && line.Substring(j, 2) == "//"))
				break;

			if (comment) continue;
			else sb.Append(line[j]);
		}

		if (sb.Length > 0 && !comment)
		{
			result.Add(sb.ToString());
			sb.Length = 0;
		}
	}

	return result;
}

