using Rikai.Graphviz.Builders;

namespace Rikai.Graphviz.Samples;

public partial class Graphs
{
	public static Graph LibraryStructure()
	{
		// predefined colors
		var colors = (
			BgColor: "#eaeef1",
			Magenta: "#e153b3",
			Plum: "#dd6e96",
			Purple: "#9e55dd",
			Blue: "#4d5de5",
			Cyan: "#4897e8",
			Orange: "#f28a70",
			Transparent: "transparent"
		);

		// predefined node attributes holder
		var nodes = (
			Header: new NodeAttributes
			{
				Color    = "green",
				Label    = "Graphviz Library Structure",
				FontSize = 16
			},
			Project: new NodeAttributes
			{
				Color    = "purple",
				FontSize = 12
			},
			Class: new NodeAttributes
			{
				Color    = "magenta",
				FontSize = 8
			},
			Method: new NodeAttributes
			{
				Color    = "blue",
				FontSize = 8
			},
			Directory: new NodeAttributes
			{
				Color    = "Gray",
				FontSize = 8
			}
		);

		// graph type is required to be passed
		Graph graph = new GraphBuilder(GraphType.Directed)

			// graph attributes
			.WithAttributes(graph => graph
				.Label("Rikai's Graphviz Library Structure!")
				.LabelLocation(LabelLocation.Top)
				.Splines(Splines.Compound)
				.BgColor(colors.Transparent)
			)

			// node attributes
			.WithNodeAttributes(graphNodes => graphNodes
				.Shape(Shape.Rectangle)
				.Style(NodeStyle.Filled)
				.Color(colors.Transparent)
				.FontSize(9)
			)

			// edge attributes
			.WithEdgeAttributes(graphEdges => graphEdges
				.ArrowHead(ArrowType.Vee)
				.Style(EdgeStyle.Dashed)
				.FontSize(9)
			)

			// Cluster: Rikai.Graphviz
			.AddCluster(id: "gv", label: "Rikai.Graphviz", configure: cluster => cluster
					.WithAttributes(clusterAttr => clusterAttr
						.BgColor(colors.Transparent)
						.PenColor(colors.Plum)
					)
					.WithNodeAttributes(nodeAttr => nodeAttr
						.Color("skyblue")
					)
					// Table: Attributes
					.AddHtml("t_attr", html => html
						.WithAttributes(htmlAttr => htmlAttr
							.Border(1)
							.CellBorder(1)
							.CellSpacing(0)
							.CellPadding(5)
							.Color(colors.Plum)
						)
						.WithNodeAttributes(node => node
							.Shape(Shape.Plain)
						)
						// Row: Title
						.AddRow(row => row
							.AddCell("t_attr_title", "Attributes ;)", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(2)
									.Align(HtmlAlign.Center)
								)
							)
						)
						// Row: class | cluster
						.AddRow(row => row
							.AddCell("", "class", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Left)
								)
							)
							.AddCell("", "Cluster Attributes", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Right)
								)
							)
						)
						// Row: class | edge
						.AddRow(row => row
							.AddCell("", "class", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Left)
								)
							)
							.AddCell("", "Edge Attributes", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Right)
								)
							)
						)
						// Row: class | graph
						.AddRow(row => row
							.AddCell("", "class", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Left)
								)
							)
							.AddCell("", "Graph Attributes", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Right)
								)
							)
						)
						// Row: class | htmlcell
						.AddRow(row => row
							.AddCell("", "class", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Left)
								)
							)
							.AddCell("", "Html Cell Attributes", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Right)
								)
							)
						)
						// Row: class | html table
						.AddRow(row => row
							.AddCell("", "class", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Left)
								)
							)
							.AddCell("", "Html Table Attributes", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Right)
								)
							)
						)
						// Row: class | node
						.AddRow(row => row
							.AddCell("", "class", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Left)
								)
							)
							.AddCell("", "Node Attributes", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Right)
								)
							)
						)
						// Row: class | edge
						.AddRow(row => row
							.AddCell("", "class", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Left)
								)
							)
							.AddCell("", "Edge Attributes", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Right)
								)
							)
						)
					)

					// Table: DotFormat
					.AddHtml("t_dot", html => html
						.WithAttributes(htmlAttr => htmlAttr
							.Border(1)
							.CellBorder(1)
							.CellSpacing(0)
							.CellPadding(5)
							.Color(colors.Cyan)
						)
						.WithNodeAttributes(node => node
							.Shape(Shape.Plain)
						)
						// Row: Title
						.AddRow(row => row
							.AddCell("t_attr_title", "DotFormat", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(2)
									.Align(HtmlAlign.Center)
								)
							)
						)
						// Row: DotGenerator
						.AddRow(row => row
							.AddCell("", "class", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Left)
								)
							)
							.AddCell("", "DotGenerator", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Right)
								)
							)
						)
						// Row: GraphFormatter
						.AddRow(row => row
							.AddCell("", "class", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Left)
								)
							)
							.AddCell("", "GraphFormatter", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Right)
								)
							)
						)
						// Row: Helpers
						.AddRow(row => row
							.AddCell("", "class", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Left)
								)
							)
							.AddCell("", "Helpers", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Right)
								)
							)
						)
					)
					// Table: DotFormat
					.AddHtml("t_dot", html => html
						.WithAttributes(htmlAttr => htmlAttr
							.Border(1)
							.CellBorder(1)
							.CellSpacing(0)
							.CellPadding(5)
							.Color(colors.Cyan)
						)
						.WithNodeAttributes(node => node
							.Shape(Shape.Plain)
						)
						// Row: Title
						.AddRow(row => row
							.AddCell("t_attr_title", "DotFormat", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(2)
									.Align(HtmlAlign.Center)
								)
							)
						)
						// Row: DotGenerator
						.AddRow(row => row
							.AddCell("", "class", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Left)
								)
							)
							.AddCell("", "DotGenerator", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Right)
								)
							)
						)
						// Row: GraphFormatter
						.AddRow(row => row
							.AddCell("", "class", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Left)
								)
							)
							.AddCell("", "GraphFormatter", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Right)
								)
							)
						)
						// Row: Helpers
						.AddRow(row => row
							.AddCell("", "class", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Left)
								)
							)
							.AddCell("", "Helpers", cell => cell
								.WithAttributes(cellAttr => cellAttr
									.ColSpan(1)
									.Align(HtmlAlign.Right)
								)
							)
						)
					)
					// Cluster: Types
					.AddCluster(id: "gv_types", label: "Types", configure: cluster2 => cluster2
						.WithAttributes(cellAttr => cellAttr
							.BgColor(colors.Transparent)
							.PenColor(colors.Blue)
						)
						.WithNodeAttributes(nodeAttr => nodeAttr
							.Color("skyblue")
						)
						// Table: Types
						.AddHtml("t_types", html => html
							.WithAttributes(htmlAttr => htmlAttr
								.Border(1)
								.CellBorder(1)
								.CellSpacing(0)
								.CellPadding(5)
								.Color(colors.Plum)
							)
							.WithNodeAttributes(htmlNodeAttr => htmlNodeAttr.Shape(Shape.Plain))
							// Row: Cluster
							.AddRow(row => row
								.AddCell("", "class", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "Cluster", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
							// Row: Edge
							.AddRow(row => row
								.AddCell("", "class", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "Edge", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
							// Row: Graph
							.AddRow(row => row
								.AddCell("", "class", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "Graph", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
							// Row: Node
							.AddRow(row => row
								.AddCell("", "class", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "Node", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
						)

						// Table: Collections
						.AddHtml("t_types_collection", html => html
							.WithAttributes(htmlAttr => htmlAttr
								.Border(1)
								.CellBorder(1)
								.CellSpacing(0)
								.CellPadding(5)
								.Color(colors.Plum)
							)
							.WithNodeAttributes(htmlNodeAttr => htmlNodeAttr.Shape(Shape.Plain))
							// Row: Title
							.AddRow(row => row
								.AddCell("t_attr_title", "Collections", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(2)
										.Align(HtmlAlign.Center)
									)
								)
							)
							// Row: ClusterEdges
							.AddRow(row => row
								.AddCell("", "class", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "ClusterEdges", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
							// Row: ClusterNodes
							.AddRow(row => row
								.AddCell("", "class", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "ClusterNodes", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
							// Row: GraphClusters
							.AddRow(row => row
								.AddCell("", "class", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "GraphClusters", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
							// Row: GraphEdges
							.AddRow(row => row
								.AddCell("", "class", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "GraphEdges", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
							// Row: GraphNodes
							.AddRow(row => row
								.AddCell("", "class", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "GraphNodes", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
						)
						.AddCluster("", "Test", configure: config => config
							.WithNodeAttributes(nodeAttr => nodeAttr
								.Shape(Shape.Plain)
							)
							.AddHtml("kek", html => html
								.AddRow(row => row
									.AddCell("WOAH", "HMM?", cell => cell
										.WithAttributes(attr => attr
											.Align(HtmlAlign.Right)
										)
									)
									.AddCell("KE", "EH", cell => cell
										.WithAttributes(attr => attr
											.Align(HtmlAlign.Right)
										)
									)
								)
							)
						)
					)

				//
				// 	// Builders
				// 	.AddCluster(id: "gv_builders", label: "Builders", configure: c => c
				// 		.WithAttributes(c => c
				// 			.PenColor(colors.Orange)
				// 		)
				//
				// 		// html builders
				// 		.AddCluster(id: "gv_builders_html", label: "Html", configure: c => c
				// 			.WithAttributes(c => c
				// 				.PenColor(colors.Orange)
				// 			)
				// 			.AddNode("WIP")
				// 		)
				// 		.AddNode("Cluster Attr Bldr")
				// 		.AddNode("Cluster Bldr")
				// 		.AddNode("Edge Attr Bldr")
				// 		.AddNode("Edge Attr Bldr")
				// 		.AddNode("Graph Attr Bldr")
				// 		.AddNode("Graph Bldr")
				// 		.AddNode("Node Attr Bldr")
				// 		.AddNode("Node Bldr")
				// 		.AddEdge("Cluster Attr Bldr", "Cluster Bldr")
				// 		.AddEdge("Cluster Bldr",      "Edge Attr Bldr")
				// 	)
				//
				// 	// dotFormat
				// 	.AddCluster(id: "gv_dot", label: "DotFormat", configure: c => c
				// 		.WithAttributes(c => c
				// 			.IsCluster(true)
				// 			.PenColor("pink")
				// 		)
				// 		.AddNode("DotGenerator")
				// 		.AddNode("GraphFormatter")
				// 		.AddNode("Helpers")
				// 	)
				//
				// 	// types
				// 	.AddCluster(id: "gv_types", label: "Types", configure: c => c
				// 		.WithAttributes(c => c
				// 			.IsCluster(true)
				// 			.PenColor("blue")
				// 		)
				//
				// 		// collections
				// 		.AddCluster(id: "gv_types_collection", label: "Collection", configure: c => c
				// 			.WithAttributes(c => c
				// 				.PenColor(colors.Orange)
				// 			)
				// 			.AddNode("Hmph")
				//
				// 			// html types
				// 			.AddCluster(id: "gv_types_html", label: "Html", configure: c => c
				// 				.WithAttributes(c => c
				// 					.PenColor(colors.Orange)
				// 				)
				// 				.AddNode("Hmph")
				// 				.AddNode("Cluster")
				// 				.AddNode("Edge")
				// 				.AddNode("Graph")
				// 				.AddNode("Node")
				// 			)
				// 		)
				// 	)

				// finalize
			)
			.Build();
		return graph;
	}
}
