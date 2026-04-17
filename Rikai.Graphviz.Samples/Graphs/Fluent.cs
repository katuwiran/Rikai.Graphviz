using System.Runtime.InteropServices;
using Rikai.Graphviz.Builders;

namespace Rikai.Graphviz.Samples;

public partial class Graphs
{
	public static Graph Fluent()
	{
		// instantiate a graph builder
		Graph graph = new GraphBuilder(GraphType.Directed)

			// define the Graph attributes
			// this will be `graph [attr=value]`
			.WithAttributes(a => a
				.FontName("Libertinus Sans")
				.FontColor("cccccc")
				.RankDir(RankDir.LR)
				.LayoutEngine(LayoutEngine.Dot)
			)

			// define the Graph Node attributes
			// this will be `node [attr=value]`
			.WithNodeAttributes(a => a
				.FontName("Libertinus Sans")
				.FontColor("orange")
				.Shape(Shape.Rectangle)
				.FillColor("pink")
			)

			// define the Graph Node attributes
			// this will be `node [attr=value]`
			.WithEdgeAttributes(a => a
				.Color("green")
			)

			// builds the graph object
			.Build();

		// You can define nodes like this
		Node n1   = new(id: "Unique");
		Node n2   = new(id: "tee hee ~");
		Node solo = new(id: "I'm alone!");

		// You can instantiate another builder using a different graph and extend it
		Graph continuation = new GraphBuilder(graph)

			// Adding a node using only ids
			.AddNode("This is a node")

			// Adding a node using the node builder
			.AddNode(new NodeBuilder("another node")
				.WithAttributes(a => a
					.Color("pink")
					.Shape(Shape.Septagon)
				)
				.Build()
			)

			// or alternatively, using the Action<T> syntax
			.AddNode("real node", c => c
				.WithAttributes(a => a
					.Color("pink")
					.Shape(Shape.Septagon)
				)
			)

			// Adding multiple nodes at once
			.AddNodes([n1, n2, solo])

			// Adding edges
			.AddEdge("A", "B")
			.AddEdge(n1,  n2)
			.AddEdge("A", ["C", "D", "E"])

			// Multiple edges at once
			.AddEdges([
					new Edge(from: ["B", "C"], to: ["D", "E", "F"]),
					new Edge("C",              "F")
				]
			)

			// Adding an edge using the fluent builder
			.AddEdge(new EdgeBuilder()
				.From("From this")
				.To("To that")
				.Build()
			)

			// Adding a fluent edge with attributes
			.AddEdge(new EdgeBuilder()
				.From("Like that")
				.To("But to there")
				.WithAttributes(a => a
					.ArrowHead(ArrowType.Vee)
					.Color("pink")
					.Label("test")
				)
				.Build()
			)
			.Build();

		return continuation;
	}
}
