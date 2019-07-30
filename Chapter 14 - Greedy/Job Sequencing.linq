<Query Kind="Program" />

void Main()
{
	var jobs = new List<Job>();
	jobs.Add(new Job("a", 2, 100));
	jobs.Add(new Job("b", 1, 19));
	jobs.Add(new Job("c", 2, 27));
	jobs.Add(new Job("d", 1, 25));
	jobs.Add(new Job("e", 3, 15));


	GetJobScheduling(jobs, 5).Dump();
}

public List<string> GetJobScheduling(List<Job> jobs, int n)
{
	var output = new List<string>();
	
	jobs.Sort((x,y) => y.Profit- x.Profit);
	
	jobs.Dump();
	
	var scheduler = new bool[n];
	var maxProfit = 0;
	for (int i = 0; i < n; i++)
	{
		var job = jobs[i];
		for (int j = job.DeadLine-1; j >= 0; j--)
		{
			if(!scheduler[j])
			{
				scheduler[j] = true;
				output.Add(job.JobId);
				maxProfit += job.Profit;
				break;
			}
		}
	}
	
	maxProfit.Dump();
	
	return output;
}


public class Job
{
	public string JobId { get; set; }
	
	public int DeadLine { get; set; }
	
	public int Profit { get; set; }
	
	
	public Job(string jobId, int deadLine, int profit)
	{
		JobId = jobId;
		DeadLine = deadLine;
		Profit = profit;
	}
}