namespace Rikai.Graphviz.Samples;

public static partial class ShowCase
{
	public static Graph Meta
	{
		get
		{
			Graph graph = new() { Type = GraphType.Directed };

			EdgeAttributes done = new()
			{
				FillColor = "green"
			};

			graph.Edges.Add([
				new("Start", "Planning") { Attributes = done with { Label = "prioritizing" } },
				new("Planning", "Domain"),
				new("Domain", ["Attributes", "Types"]),
				new("Planning", "DotFormat"),
				new("Format", "Graphs"),
				new("Format", "Graph Nodes"),
				new("Format", "Graph Edges"),
				new("Format", "Nodes"),
				new("Format", "Edges"),
				new("Format", "Node Attributes"),
				new("Format", "Edge Attributes"),
			]);

			return graph;
		}
	}
}