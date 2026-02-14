namespace Rikai.Graphviz;

public class Graph
{
	public required GraphType Type { get; init; }

	public GraphAttributes Attributes { get; set; } = new();

	public GraphNodes Nodes { get; } = new();
	public GraphEdges Edges { get; }


	public Graph()
	{
		Edges = new(this);
	}

	public Node GetNodeById(string id)
	{
		return null;
	}

	public override string ToString()
	{
		DotGenerator generator = new(this);
		return generator.ToString();
	}

	public void PrintToConsole()
	{
		Console.WriteLine(ToString());
	}
}