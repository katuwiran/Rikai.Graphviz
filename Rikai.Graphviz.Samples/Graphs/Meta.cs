namespace Rikai.Graphviz.Samples;

public partial class Graphs
{
	public static Graph Meta
	{
		get
		{
			Graph graph = new() { Type = GraphType.Directed };

			EdgeAttributes done = new()
			{
				Color = "green"
			};

			graph.Edges.AddRange([
					new Edge("Start",    "Planning") { Attributes = done with { Label = "prioritizing" } },
					new Edge("Planning", "Domain"),
					new Edge("Domain",   ["Attributes", "Types"]),
					new Edge("Planning", "DotFormat"),
					new Edge("Format",   "Graphs"),
					new Edge("Format",   "Graph Nodes"),
					new Edge("Format",   "Graph Edges"),
					new Edge("Format",   "Nodes"),
					new Edge("Format",   "Edges"),
					new Edge("Format",   "Node Attributes"),
					new Edge("Format",   "Edge Attributes")
				]
			);

			return graph;
		}
	}
}
