namespace Rikai.Graphviz;

public class ClusterEdges
{
	public   EdgeAttributes Attributes { get; set; }  = new();
	public   List<Edge>     Collection { get; init; } = new();
	internal ClusterNodes   Nodes; // constructor DI

	public ClusterEdges(Cluster cluster)
	{
		Nodes      = cluster.Nodes;
	}

	// Add one edge
	public void Add(Edge edge)
	{
		Collection.Add(edge);
		Nodes.AddNodesToCollectionIfNotExists(edge.FromNodes);
		Nodes.AddNodesToCollectionIfNotExists(edge.ToNodes);
	}

	// Add edges
	public void AddRange(IEnumerable<Edge> edges)
	{
		Collection.AddRange(edges);
		foreach (var edge in edges)
		{
			Nodes.AddNodesToCollectionIfNotExists(edge.FromNodes);
			Nodes.AddNodesToCollectionIfNotExists(edge.ToNodes);
		}
	}
}