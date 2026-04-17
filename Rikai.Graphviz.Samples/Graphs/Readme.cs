using Rikai.Graphviz.Builders;

namespace Rikai.Graphviz.Samples;

public partial class Graphs
{
	public static Graph ReadMe()
	{
		Graph graph = new GraphBuilder(GraphType.Directed)

			// graph attributes 
			.WithAttributes(graph => graph
				.Splines(Splines.Ortho)
				.BgColor("white")
				.RankDir(RankDir.BT)
			)

			// node attributes
			.WithNodeAttributes(graphNodes => graphNodes
				.Shape(Shape.Rectangle)
				.Style(NodeStyle.Filled)
				.Color("white")
				.FontSize(9)
			)

			// edge attributes
			.WithEdgeAttributes(graphEdges => graphEdges
				.ArrowHead(ArrowType.Vee)
				.Style(EdgeStyle.Dashed)
				.FontSize(9)
			)

			// node
			.AddNode("a node")
			.AddNode("another node", node => node
				.WithAttributes(nodeAttr => nodeAttr
					.Color("pink")
					.Shape(Shape.Septagon)
				)
			)

			// edges 
			.AddEdge("A", "B")
			.AddEdge("a node", "another node",  attr => attr.Color("violet"))
			.AddEdge(edge => edge
				.From("Like that")
				.To("But to there")
				.WithAttributes(attr => attr
					.Color("green")
				)
			)
			.Build();

		return graph;
	}
}
