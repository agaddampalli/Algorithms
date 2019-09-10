<Query Kind="Program" />

void Main()
{
	var filters = new List<IFilter> {new AbusiveContentFilter(), new PrepositionsFilter()};
	var system = new FilteringSystem(filters);
	
	system.FilterComments("A good comment").Dump();
}

public interface IFilter
{
	HashSet<string> Words { set;}
	
	IFilter NextFilter {set;}
	
	void SetNextFilter(IFilter filter);
	
	bool Filter(string input);
}

public class AbusiveContentFilter : IFilter
{
	public HashSet<string> Words {get; set; }
	public IFilter NextFilter { get; set; }

	public AbusiveContentFilter()
	{
		Words = new HashSet<string> {"test", "abusive"};
	}
	
	public bool Filter(string input)
	{
		bool isFailed = false;
		
		foreach (var word in Words)
		{
			if(input.Contains(word))
			{
				isFailed = true;
				break;
			}
		}
		
		if(!isFailed &&NextFilter != null)
		{
			return NextFilter.Filter(input);
		}
		
		return !isFailed;
	}

	public void SetNextFilter(IFilter filter)
	{
		NextFilter = filter;
	}
}

public class PrepositionsFilter : IFilter
{
	public HashSet<string> Words { get; set; }
	public IFilter NextFilter { get; set; }

	public PrepositionsFilter()
	{
		Words = new HashSet<string> { "is", "the" };
	}

	public bool Filter(string input)
	{
		bool isFailed = false;
		
		foreach (var word in Words)
		{
			if(input.Contains(word))
			{
				isFailed = true;
				break;
			}
		}

		if (!isFailed && NextFilter != null)
		{
			return NextFilter.Filter(input);
		}

		return !isFailed;
	}

	public void SetNextFilter(IFilter filter)
	{
		NextFilter = filter;
	}
}

public class FilteringSystem
{
	private IFilter baseFilter;

	public FilteringSystem(IList<IFilter> filters)
	{
		baseFilter = filters[0];
		var filter = filters[0];
		for (int i = 1; i < filters.Count; i++)
		{
			filter.SetNextFilter(filters[i]);
			filter = filters[i];
		}
	}
	
	public bool FilterComments(string comment)
	{
		return baseFilter.Filter(comment);
	}
}
