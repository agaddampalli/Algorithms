<Query Kind="Program" />

void Main()
{
	var requests = new List<Request>();

	requests.Add(new Request("Alex", 1, 2));
	requests.Add(new Request("Ben", 2, 1));
	requests.Add(new Request("Chris", 1, 2));
	requests.Add(new Request("David", 2, 3));
	requests.Add(new Request("Ellen", 3, 1));
	requests.Add(new Request("Frank", 4, 5));

	requests.Sort((x, y) => x.From - y.From);

	requests.Dump();
	MoveRequests(requests).Dump();
}


public List<IList<string>> MoveRequests(List<Request> requests)
{
	var output = new List<IList<string>>();

	var graph = new Graph();
	for (int i = 0; i < requests.Count; i++)
	{
		graph.AddDirectedEdge(requests[i].From, requests[i]);
	}

	graph.Dump();

	graph.DFS(requests[0].From, new List<string>(), output, new HashSet<int>());

	return output;
}


public class Request
{
	public string EmployeeName { get; set; }
	public int From { get; set; }
	public int To { get; set; }
	public bool IsVisited { get; set; }

	public Request(string emloyeeName, int from, int to)
	{
		EmployeeName = emloyeeName;
		From = from;
		To = to;
	}
}

public class Graph
{
	public Dictionary<int, List<Request>> AdjacencyList { get; set; }

	public Graph()
	{
		AdjacencyList = new Dictionary<int, List<Request>>();
	}

	public void AddDirectedEdge(int src, Request dest)
	{
		if (AdjacencyList.ContainsKey(src))
		{
			AdjacencyList[src].Add(dest);
		}
		else
		{
			var list = new List<Request>();
			list.Add(dest);
			AdjacencyList.Add(src, list);
		}
	}

	public void DFS(int src, List<string> temp, List<IList<string>> output, HashSet<int> visited)
	{
		if (visited.Contains(src))
		{
			output.Add(new List<string>(temp));
			return;
		}

		if (AdjacencyList.ContainsKey(src))
		{
			var values = AdjacencyList[src];
			foreach (var element in values)
			{
				if (!visited.Contains(element.To))
				{
					element.IsVisited = true;
					visited.Add(src);
					temp.Add(element.EmployeeName);
					DFS(element.To, temp, output, visited);
					temp.Remove(element.EmployeeName);
				}
			}
		}
	}
}