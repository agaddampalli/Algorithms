<Query Kind="Program" />

void Main()
{
	CompareVersion("1.0","1.10").Dump();
}

public int CompareVersion(string version1, string version2)
{
	var version1Length = version1.Length;
	var version2Length = version2.Length;
	var length = Math.Max(version1Length, version2Length);

	int i = 0, j =0;
	
	while (i < version1Length || j < version2Length)
	{
		int subversion1 = 0;
		int subversion2 = 0;
		string stringVersion1 = null;
		string stringVersion2 =  null;
		while(i<version1Length && version1[i] != '.')
		{
			stringVersion1 += version1[i].ToString();
			i++;
		}
		subversion1 = Convert.ToInt32(stringVersion1);
		


		while (j < version2Length && version2[j] != '.')
		{
			stringVersion2 += version2[j].ToString();
			j++;
		}
		subversion2 = Convert.ToInt32(stringVersion2);
		
		if(subversion1 > subversion2)
		{
			return 1;
		}
		else if(subversion1 < subversion2)
		{
			return -1;
		}
		
		i++;
		j++;
	}

	return 0;
}
