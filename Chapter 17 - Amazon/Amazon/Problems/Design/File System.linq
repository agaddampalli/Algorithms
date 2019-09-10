<Query Kind="Program" />

void Main()
{
	var fileSystem = new FileSystem();
	
	fileSystem.Ls("/").Dump();
	fileSystem.Mkdir("/a/b/c");
	fileSystem.Ls("a/b").Dump();
}

public class File
{
	public bool IsFile { get; set; }
	public StringBuilder Content { get; set; }
	public SortedDictionary<string, File> Nodes {get; set;}
	
	public File()
	{
		IsFile = false;
		Content = new StringBuilder();
		Nodes = new SortedDictionary<string, File>();
	}
}

public class FileSystem
{
	private File root;
	
	public FileSystem()
	{
		root = new File();
	}

	public IList<string> Ls(string path)
	{
		if(path == "/")
		{
			return root.Nodes.Keys.ToList();
		}

		var dirs = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
		var node = root;
			
		for (int i = 0; i < dirs.Length; i++)
		{
			node = node.Nodes[dirs[i]];
		}
		
		if(node.IsFile)
		{
			return new List<string>{dirs[dirs.Length-1]};
		}
		
		return node.Nodes.Keys.ToList();
	}	

	public void Mkdir(string path)
	{
		var dirs = path.Split(new char[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
		var node = root;
		
		for (int i = 0; i < dirs.Length; i++)
		{
			if(!node.Nodes.ContainsKey(dirs[i]))
			{
				node.Nodes.Add(dirs[i], new File());
			}
			
			node = node.Nodes[dirs[i]];
		}
	}

	public void AddContentToFile(string filePath, string content)
	{
		var dirs = filePath.Split(new char[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
		var node = root;
		
		for (int i = 0; i < dirs.Length-1; i++)
		{
			node = node.Nodes[dirs[i]];
		}
		
		var fileName = dirs[dirs.Length-1];
		if(!node.Nodes.ContainsKey(fileName))
		{
			node.Nodes.Add(fileName, new File());
		}
		
		node = node.Nodes[fileName];
		node.IsFile = true;
		node.Content.Append(content);
	}

	public string ReadContentFromFile(string filePath)
	{
		var dirs = filePath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
		var node = root;

		for (int i = 0; i < dirs.Length; i++)
		{
			node = node.Nodes[dirs[i]];
		}
		
		return node.Content.ToString();
	}
}