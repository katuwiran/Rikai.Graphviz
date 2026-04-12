namespace Rikai.Graphviz;

public class Graph
{
	public required GraphType Type { get; init; }

	public GraphAttributes Attributes { get; set; } = new();

	public GraphNodes      Nodes    { get; } = new();
	public GraphEdges      Edges    { get; }
	public GraphClusters   Clusters { get; } = new();
	public List<HtmlTable> Tables   { get; } = new();


	public Graph()
	{
		// as the logic of Edges has a dependency on the contents of a Graph
		// we inject a reference of the Graph to the instance of Graph Edges
		Edges = new(this);
	}

	public override string ToString()
	{
		DotFormat.DotGenerator generator = new(this);
		return generator.ToString();
	}

	public void PrintToConsole()
	{
		Console.WriteLine(ToString());
	}
}