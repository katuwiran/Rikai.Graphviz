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
			.WithGraphAttributes(a => a
				.FontName("Libertinus Sans")
				.FontColor("cccccc")
				.RankDir(RankDir.BT)
				.LayoutEngine(LayoutEngine.Dot))

			// define the Graph Node attributes
			// this will be `node [attr=value]`
			.WithDefaultNodeAttributes(a => a
				.FontName("Libertinus Sans")
				.FontColor("orange")
				.Shape(Shape.Rectangle)
				.FillColor("pink"))

			// define the Graph Node attributes
			// this will be `node [attr=value]`
			.WithDefaultEdgeAttributes(a => a
				.Color("green"))

			// builds the graph object
			.Build();

		// You can define nodes like this
		Node n1   = new(id: "UNIQUE");
		Node n2   = new(id: "TEEHEE");
		Node solo = new(id: "I'm alone!");

		// You can instantiate another builder using a different graph and extend it
		Graph continuation = new GraphBuilder(graph)
			
			// Adding a node using only ids
			.AddNode("This is a node")
			
			// Adding a node using the node builder
			.AddNode(new NodeBuilder("another node")
				.WithAttributes(a => a
					.Color("pink")
					.Shape(Shape.Septagon))
				.Build())
			
			// Adding multiple nodes at once
			.AddNodes([n1, n2, solo])
			
			// Adding edges
			.AddEdge("A", "B")
			.AddEdge(n1,  n2)
			.AddEdge("A", ["C", "D", "E"])
			
			// Multiple edges at once
			.AddEdges([
				new(from: ["B", "C"], to: ["D", "E", "F"]),
				new("C", "F")
			])
			.Build();
		
		return continuation;
	}
}