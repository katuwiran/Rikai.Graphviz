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
				.BgColor("white")
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

			// Cluster: Rikai.Graphviz
			.AddCluster(id: "gv", label: "Rikai.Graphviz", configure: cluster => cluster
					.WithAttributes(clusterAttr => clusterAttr
						.BgColor("white")
						.PenColor(colors.Blue)
					)
					.WithNodeAttributes(nodeAttr => nodeAttr
						.Color("skyblue")
					)
					// Cluster: Attributes
					.AddCluster(id: "gv_attr", label: "Attributes", configure: cluster2 => cluster2
						.WithAttributes(clusterAttr => clusterAttr
							.BgColor("white")
							.PenColor(colors.Blue)
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
								.Color(colors.Cyan)
							)
							.WithNodeAttributes(node => node
								.Shape(Shape.Plain)
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
					)

					// Cluster: Attribute Types
					.AddCluster(id: "gv_attrTypes", label: "Attribute Types", configure: cluster2 => cluster2
						.WithAttributes(cellAttr => cellAttr
							.BgColor("white")
							.PenColor(colors.Cyan)
						)
						.WithNodeAttributes(nodeAttr => nodeAttr
							.Shape(Shape.Plain)
							.Color("skyblue")
						)
						// Table: Attribute Types
						.AddHtml("t_attrTypes", html => html
							.WithAttributes(htmlAttr => htmlAttr
								.Border(1)
								.CellBorder(1)
								.CellSpacing(0)
								.CellPadding(5)
								.Color(colors.Cyan)
							)
							.WithNodeAttributes(node => node.Shape(Shape.Plain)
							)
							// Row: ArrowType
							.AddRow(row => row
								.AddCell("", "enum", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "ArrowType", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
							// Row: EdgeStyle
							.AddRow(row => row
								.AddCell("enum", "enum", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "EdgeStyle", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
							// Row: EdgeStyle
							.AddRow(row => row
								.AddCell("enum", "enum", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "EdgeStyle", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
							// Row: GraphType
							.AddRow(row => row
								.AddCell("enum", "enum", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "GraphType", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
							// Row: LabelLocation
							.AddRow(row => row
								.AddCell("enum", "enum", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "LabelLocation", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
							// Row: LayoutEngine
							.AddRow(row => row
								.AddCell("enum", "enum", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "LayoutEngine", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
							// Row: NodeStyle
							.AddRow(row => row
								.AddCell("enum", "enum", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "NodeStyle", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
							// Row: Overlap
							.AddRow(row => row
								.AddCell("enum", "enum", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "Overlap", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
							// Row: PortPos
							.AddRow(row => row
								.AddCell("enum", "enum", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "PortPos", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
							// Row: RankDir
							.AddRow(row => row
								.AddCell("enum", "enum", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "RankDir", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
							// Row: Shape
							.AddRow(row => row
								.AddCell("enum", "enum", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "Shape", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
							// Row: Splines
							.AddRow(row => row
								.AddCell("enum", "enum", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "Splines", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
						)
					)
					// Cluster: DotFormat
					.AddCluster(id: "gv_dot", label: "DotFormat", configure: cluster2 => cluster2
						.WithAttributes(clusterAttr => clusterAttr
							.BgColor("white")
							.PenColor(colors.Blue)
						)
						.WithNodeAttributes(nodeAttr => nodeAttr
							.Color("skyblue")
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
					)
					// Cluster: Builders
					.AddCluster(id: "gv_builders", label: "Builders", configure: cluster2 => cluster2
						.WithAttributes(cellAttr => cellAttr
							.BgColor("white")
							.PenColor(colors.Cyan)
						)
						.WithNodeAttributes(nodeAttr => nodeAttr
							.Color("skyblue")
						)
						// Table: Types
						.AddHtml("t_builders", html => html
							.WithAttributes(htmlAttr => htmlAttr
								.Border(1)
								.CellBorder(1)
								.CellSpacing(0)
								.CellPadding(5)
								.Color(colors.Cyan)
							)
							.WithNodeAttributes(htmlNodeAttr => htmlNodeAttr.Shape(Shape.Plain))
							// Row: ClusterBuilder
							.AddRow(row => row
								.AddCell("", "class", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "ClusterBuilder", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
							// Row: EdgeBuilder
							.AddRow(row => row
								.AddCell("", "class", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "EdgeBuilder", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
							// Row: GraphBuilder
							.AddRow(row => row
								.AddCell("", "class", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "GraphBuilder", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
							// Row: NodeBuilder
							.AddRow(row => row
								.AddCell("", "class", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Left)
									)
								)
								.AddCell("", "NodeBuilder", cell => cell
									.WithAttributes(cellAttr => cellAttr
										.ColSpan(1)
										.Align(HtmlAlign.Right)
									)
								)
							)
						)
						// Cluster: Builders.Attributes
						// Cluster: Types
						.AddCluster(id: "gw_builders_attr", label: "Attributes", configure: cluster3 => cluster3
							.WithAttributes(cellAttr => cellAttr
								.BgColor("white")
								.PenColor(colors.Cyan)
							)
							.WithNodeAttributes(nodeAttr => nodeAttr
								.Color("skyblue")
							)
							// Table: Types
							.AddHtml("t_builders_attr", html => html
								.WithAttributes(htmlAttr => htmlAttr
									.Border(1)
									.CellBorder(1)
									.CellSpacing(0)
									.CellPadding(5)
									.Color(colors.Cyan)
								)
								.WithNodeAttributes(node => node.Shape(Shape.Plain))
								// Row: ClusterAttributeBuilder
								.AddRow(row => row
									.AddCell("", "class", cell => cell
										.WithAttributes(cellAttr => cellAttr
											.ColSpan(1)
											.Align(HtmlAlign.Left)
										)
									)
									.AddCell("", "ClusterAttributeBuilder", cell => cell
										.WithAttributes(cellAttr => cellAttr
											.ColSpan(1)
											.Align(HtmlAlign.Right)
										)
									)
								)
								// Row: EdgeAttributeBuilder
								.AddRow(row => row
									.AddCell("", "class", cell => cell
										.WithAttributes(cellAttr => cellAttr
											.ColSpan(1)
											.Align(HtmlAlign.Left)
										)
									)
									.AddCell("", "EdgeAttributeBuilder", cell => cell
										.WithAttributes(cellAttr => cellAttr
											.ColSpan(1)
											.Align(HtmlAlign.Right)
										)
									)
								)
								// Row: GraphAttributeBuilder
								.AddRow(row => row
									.AddCell("", "class", cell => cell
										.WithAttributes(cellAttr => cellAttr
											.ColSpan(1)
											.Align(HtmlAlign.Left)
										)
									)
									.AddCell("", "GraphAttributeBuilder", cell => cell
										.WithAttributes(cellAttr => cellAttr
											.ColSpan(1)
											.Align(HtmlAlign.Right)
										)
									)
								)
								// Row: NodeAttributeBuilder
								.AddRow(row => row
									.AddCell("", "class", cell => cell
										.WithAttributes(cellAttr => cellAttr
											.ColSpan(1)
											.Align(HtmlAlign.Left)
										)
									)
									.AddCell("", "NodeAttributeBuilder", cell => cell
										.WithAttributes(cellAttr => cellAttr
											.ColSpan(1)
											.Align(HtmlAlign.Right)
										)
									)
								)
							)
						)
						// Cluster: Builders Html
						.AddCluster(id: "gw_builders_html", label: "Html", configure: cluster4 => cluster4
							.WithAttributes(cellAttr => cellAttr
								.BgColor("white")
								.PenColor(colors.Cyan)
							)
							.WithNodeAttributes(nodeAttr => nodeAttr
								.Color("skyblue")
							)
							// Table: Html
							.AddHtml("t_builders_html", html => html
								.WithAttributes(htmlAttr => htmlAttr
									.Border(1)
									.CellBorder(1)
									.CellSpacing(0)
									.CellPadding(5)
									.Color(colors.Cyan)
								)
								.WithNodeAttributes(node => node.Shape(Shape.Plain))
								// Row: HtmlCellBuilder
								.AddRow(row => row
									.AddCell("", "class", cell => cell
										.WithAttributes(cellAttr => cellAttr
											.ColSpan(1)
											.Align(HtmlAlign.Left)
										)
									)
									.AddCell("", "HtmlCellBuilder", cell => cell
										.WithAttributes(cellAttr => cellAttr
											.ColSpan(1)
											.Align(HtmlAlign.Right)
										)
									)
								)
								// Row: HtmlRowBuilder
								.AddRow(row => row
									.AddCell("", "class", cell => cell
										.WithAttributes(cellAttr => cellAttr
											.ColSpan(1)
											.Align(HtmlAlign.Left)
										)
									)
									.AddCell("", "HtmlRowBuilder", cell => cell
										.WithAttributes(cellAttr => cellAttr
											.ColSpan(1)
											.Align(HtmlAlign.Right)
										)
									)
								)
								// Row: HtmlTableBuilder
								.AddRow(row => row
									.AddCell("", "class", cell => cell
										.WithAttributes(cellAttr => cellAttr
											.ColSpan(1)
											.Align(HtmlAlign.Left)
										)
									)
									.AddCell("", "HtmlTableBuilder", cell => cell
										.WithAttributes(cellAttr => cellAttr
											.ColSpan(1)
											.Align(HtmlAlign.Right)
										)
									)
								)
							)
							// Cluster: Builders.Html.Attributes
							.AddCluster("gv_builders_html_attr", "Attributes", configure: cluster5 => cluster5
								.WithAttributes(cellAttr => cellAttr
									.BgColor("white")
									.PenColor(colors.Cyan)
								)
								.WithNodeAttributes(nodeAttr => nodeAttr
									.Color("skyblue")
								)
								// Table: Builders.Html.Attributes
								.AddHtml("t_builders_html_attr", html => html
									.WithAttributes(htmlAttr => htmlAttr
										.Border(1)
										.CellBorder(1)
										.CellSpacing(0)
										.CellPadding(5)
										.Color(colors.Cyan)
									)
									.WithNodeAttributes(htmlNodeAttr => htmlNodeAttr.Shape(Shape.Plain))
									// Row: HtmlCellAttributesBuilder
									.AddRow(row => row
										.AddCell("", "class", cell => cell
											.WithAttributes(cellAttr => cellAttr
												.ColSpan(1)
												.Align(HtmlAlign.Left)
											)
										)
										.AddCell("", "HtmlCellAttributesBuilder", cell => cell
											.WithAttributes(cellAttr => cellAttr
												.ColSpan(1)
												.Align(HtmlAlign.Right)
											)
										)
									)
									// Row: HtmlTableAttributesBuilder
									.AddRow(row => row
										.AddCell("", "class", cell => cell
											.WithAttributes(cellAttr => cellAttr
												.ColSpan(1)
												.Align(HtmlAlign.Left)
											)
										)
										.AddCell("", "HtmlTableAttributesBuilder", cell => cell
											.WithAttributes(cellAttr => cellAttr
												.ColSpan(1)
												.Align(HtmlAlign.Right)
											)
										)
									)
								)
							)
						)
					)
					// Cluster: Types
					.AddCluster(id: "gv_types", label: "Types", configure: cluster2 => cluster2
						.WithAttributes(cellAttr => cellAttr
							.BgColor("white")
							.PenColor(colors.Cyan)
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
								.Color(colors.Cyan)
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
								.Color(colors.Cyan)
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
