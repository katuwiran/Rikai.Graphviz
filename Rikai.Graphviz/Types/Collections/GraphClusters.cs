namespace Rikai.Graphviz;

public class GraphClusters
{
	public List<Cluster> Collection { get; set; }

	public GraphClusters()
	{
		Collection = new List<Cluster>();
	}

	public void Add(Cluster cluster)
	{
		if (Collection.Contains(cluster))
		{
			return;
		}

		Collection.Add(cluster);
	}

	public void AddRange(IEnumerable<Cluster> clusters)
	{
		foreach (Cluster cluster in clusters)
		{
			if (Collection.Contains(cluster))
			{
				continue;
			}

			Collection.Add(cluster);
		}
	}
}
