<Query Kind="Program" />

void Main()
{
	SimplifyPath("/home//foo/").Dump();
}

public string SimplifyPath(string path)
{
	if(string.IsNullOrWhiteSpace(path))
	{
		return null;
	}

	var directories = path.Split(new char[] { '/'}, StringSplitOptions.RemoveEmptyEntries);
	var stack = new Stack<string>();
	
	foreach (var element in directories)
	{
		if(element == ".")
		{
			continue;
		}
		
		if(element == "..")
		{
			if(stack.Count != 0)
			{
				stack.Pop();
			}
			
			continue;
		}
		
		stack.Push(element);
	}
	
	var output = new StringBuilder();
	while(stack.Count != 0)
	{
		output.Append(stack.Pop());
		
		if(stack.Count != 0)
		{
			output.Append("/");
		}
	}
	
	return output.ToString();
}