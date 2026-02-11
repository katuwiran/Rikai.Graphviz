namespace Rikai.Graphviz;

public class Graph
{
	public GraphType Type { get; set; } = GraphType.Directed;

	public NodeCollection  Nodes      { get; }      = new();
	public EdgeCollection  Edges      { get; }      = new();
	public GraphAttributes Attributes { get; set; } = new();
}