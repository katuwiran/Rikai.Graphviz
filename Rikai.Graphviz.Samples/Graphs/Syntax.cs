namespace Rikai.Graphviz.Samples;

public partial class Program
{
	public static Graph SyntaxShowcase
	{
		get
		{
			// Instantiate a new, empty directed graph
			Graph graph = new() { Type = GraphType.Directed };

			// Create new attributes for the graph
			graph.Attributes = new GraphAttributes()
			{
				FontName     = "Test",
				FontColor    = "cccccc",
				RankDir      = RankDir.BT,
				LayoutEngine = LayoutEngine.Circo,
			};

			// Create new attributes for all graph nodes
			graph.Nodes.Attributes = new NodeAttributes()
			{
				FontName  = "Test2",
				FontColor = "cccccc",
				Shape     = Shape.Circle,
				FillColor = "cccccc",
			};

			// Create new attributes for all graph edges
			graph.Edges.Attributes = new EdgeAttributes()
			{
				ArrowHead = ArrowType.Inv,
				ArrowTail = ArrowType.Tee,
			};

			// You can define nodes like this
			Node n1   = new("UNIQUE");
			Node n2   = new("TEEHEE");
			Node solo = new("I'm alone!");

			// You can register nodes to the graph instance, but
			graph.Nodes.Add(solo);

			// You don't have to register them to the graph instance if you register the edge using them
			Edge e1 = new("n1", "n2");
			graph.Edges.Add(e1);

			// this syntax is also allowed, but I don't recommend it.
			Edge e2 = new();
			e2.From("A").To("B");

			// My preferred method is to define all edges like this in one go
			// you can add predefined edges, or create on the fly.
			// 1:N, N:1, and N:N assignment is also supported
			// this is closest to vanilla graphviz's syntax for fast iteration
			// todo: node to labels are not yet allowed ;)
			graph.Edges.Add([
				e2,
				new("A", "B"),
				// new(node, "C"),
				new(n1, n2),
				new("A", ["C", "D", "E"]),
			]);

			// accessibility methods
			// graph.ToString() converts the graph to a dot string.
			// graph.PrintToConsole() wraps that ToString with a WriteLine.

			return graph;
		}
	}
}