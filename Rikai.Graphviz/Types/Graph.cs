namespace Rikai.Graphviz;

public class Graph
{
	public GraphType Type { get; set; } = GraphType.Directed;

	public GraphAttributes Attributes { get; set; } = new();

	public GraphNodes Nodes { get; } = new();
	public GraphEdges Edges { get; }


	public Graph()
	{
		Edges = new(this);
	}

	public Node GetNodeById(string id)
	{
		Nodes.Nodes.Select(n => n.Id == id).FirstOrDefault(n => n != null);
		return Nodes.Nodes.FirstOrDefault(n => n.Id == id);
	}
}