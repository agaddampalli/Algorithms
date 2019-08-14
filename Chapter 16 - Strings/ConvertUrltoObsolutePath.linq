<Query Kind="Program" />

void Main()
{
	SimplifyPath("/a/../../b/../c//.//").Dump();
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
	output.Append("/");
	while(stack.Count != 0)
	{
		output.Insert(1,stack.Pop());
		
		if(stack.Count != 0)
		{
			output.Insert(1,"/");
		}
	}
	
	return output.ToString();
}