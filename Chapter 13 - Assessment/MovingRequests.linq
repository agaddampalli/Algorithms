<Query Kind="Program" />

void Main()
{
	var requests = new List<Request> { };
	requests.Add(new Request("Alex", 1, 2));
	requests.Add(new Request("Ben", 2, 1));
	requests.Add(new Request("Chris", 1, 2));
	requests.Add(new Request("David", 2, 3));
	requests.Add(new Request("Ellen", 3, 1));
	requests.Add(new Request("Frank", 4, 5));
	
	requests.Sort((x,y) =>x.FromBuilding-y.FromBuilding);
	
	requests.Dump();


	var requests1 = new List<Request> { };
	requests1.Add(new Request("Adam", 1, 2));
	requests1.Add(new Request("Brian", 2, 1));
	requests1.Add(new Request("Carl", 4, 5));
	requests1.Add(new Request("Dan", 5, 1));
	requests1.Add(new Request("Eric", 2, 3));
	requests1.Add(new Request("Fred", 3, 4));

	requests1.Sort((x, y) => x.FromBuilding - y.FromBuilding);

	requests1.Dump();
}

public class Request
{
	public string EmployeeName { get; set; }
	public int FromBuilding { get; set; }
	public int ToBuilding { get; set; }

	public Request(string employeeName, int from, int to)
	{
		EmployeeName = employeeName;
		FromBuilding = from;
		ToBuilding = to;
	}
}
