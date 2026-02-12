namespace Rikai.Graphviz;

public class GraphEdges
{
	public   EdgeAttributes Attributes { get; set; }  = new();
	public   List<Edge>     Edges      { get; init; } = new();
	internal GraphNodes     Nodes; // constructor DI

	public GraphEdges(Graph graph)
	{
		Nodes = graph.Nodes;
	}

	// Add one edge
	public void Add(Edge edge)
	{
		Edges.Add(edge);
		Nodes.AddNodesToCollectionIfNotExists(edge.FromNodes);
		Nodes.AddNodesToCollectionIfNotExists(edge.ToNodes);
	}

	// Add edges
	public void Add(IEnumerable<Edge> edges)
	{
		Edges.AddRange(edges);
		foreach (var edge in edges)
		{
			Nodes.AddNodesToCollectionIfNotExists(edge.FromNodes);
			Nodes.AddNodesToCollectionIfNotExists(edge.ToNodes);
		}
	}
}