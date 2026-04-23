using Rikai.Graphviz.Builders;
using Rikai.Graphviz.Extensions;

namespace Rikai.Graphviz.Samples;

public partial class Graphs
{
	public static Graph Meta()
	{
		string font = "Cochineal";

		string label = $"""
			Some cool stuff to do.
			""";

		ArrowType arrowHead = ArrowType.Vee;

		// light colors
		// var colors = (
		// 	BgColor: "#eaeef1",
		// 	BgEdges: "#e2ebf2",
		// 	BgOverlay: "#dde6ee",
		// 	Text: "#4f5789",
		// 	Magenta: "#e153b3",
		// 	Plum: "#dd6e96",
		// 	Purple: "#9e55dd",
		// 	Blue: "#4d5de5",
		// 	Cyan: "#4897e8",
		// 	Orange: "#f28a70",
		// 	Transparent: "transparent"
		// );

		// dark colors
		var colors = (
			BgColor: "#2a2840",
			BgEdges: "#332e51",
			BgOverlay: "#3d375f",
			Text: "#c0c0ff",
			Magenta: "#ef5abf",
			Plum: "#ec93c1",
			Purple: "#c188ef",
			Blue: "#848bf4",
			Cyan: "#80b5f7",
			Orange: "#ff8c4f",
			Green: "#c8e899",
			Transparent: "transparent"
		);

		// node attributes
		var nodes = (
			Default: new NodeAttributeBuilder()
				.Shape(Shape.Rectangle)
				.Color(colors.Text)
				.FontColor(colors.Text)
				.FontName(font)
				.Build(),
			Table: new NodeAttributeBuilder()
				.FontColor(colors.Text)
				.FontName(font)
				.Build(),
			Hidden: new NodeAttributeBuilder()
				.Shape(Shape.Point)
				.Width(0)
				.Height(0)
				.Color(colors.Transparent)
				.Style(NodeStyle.Invis)
				.Label("")
				.Build(),
			Normal: new NodeAttributeBuilder()
				.Shape(Shape.Rectangle)
				.Color(colors.Text)
				.FontColor(colors.Text)
				.Build(),
			Finished: new NodeAttributeBuilder()
				.Shape(Shape.Rectangle)
				.Color(colors.Green)
				.FontColor(colors.Green)
				.Build(),
			Ongoing: new NodeAttributeBuilder()
				.Shape(Shape.Rectangle)
				.Color(colors.Plum)
				.FontColor(colors.Plum)
				.Build()
		);

		// edge attributes
		var edges = (
			Reversed: new EdgeAttributeBuilder()
				.Dir(EdgeDirection.Back)
				.Build(),
			Unconstrained: new EdgeAttributeBuilder()
				.Constraint(false)
				.Build(),
			Hidden: new EdgeAttributeBuilder()
				.Color(colors.Transparent)
				.Style(EdgeStyle.Invis)
				.Build(),
			Done: new EdgeAttributeBuilder()
				.Color(colors.Green)
				.FontColor(colors.Green)
				.Build(),
			Ongoing: new EdgeAttributeBuilder()
				.Color(colors.Plum)
				.FontColor(colors.Plum)
				.Build()
		);

		HtmlTableAttributes tableAttr = new HtmlTableAttributeBuilder()
			.Border(1)
			.CellPadding(2)
			.CellSpacing(0)
			.Color(colors.Text)
			.Build();

		var cells = (
			Default: new HtmlCellAttributeBuilder()
				.Color(colors.Text)
				.BgColor(colors.BgOverlay)
				.Align(HtmlAlign.Text)
				.CellSpacing(0)
				.CellPadding(5)
				.Build(),
			Finished: new HtmlCellAttributeBuilder()
				.Color(colors.Green)
				.BgColor(colors.BgOverlay)
				.Align(HtmlAlign.Text)
				.CellSpacing(0)
				.CellPadding(5)
				.Build(),
			Ongoing: new HtmlCellAttributeBuilder()
				.Color(colors.Plum)
				.BgColor(colors.BgOverlay)
				.Align(HtmlAlign.Text)
				.CellSpacing(0)
				.CellPadding(5)
				.Build()
		);

		var clusters = (
			Outer: new ClusterAttributeBuilder()
				.PenColor(colors.BgEdges)
				.FillColor(colors.BgColor)
				.PenWidth(2)
				.FontName(font)
				.Style(ClusterStyle.Filled)
				.Build(),
			Inner: new ClusterAttributeBuilder()
				.PenColor(colors.Purple)
				.FillColor(colors.BgColor)
				.FontColor(colors.Purple)
				.PenWidth(2)
				.FontName(font)
				.Style(ClusterStyle.Filled)
				.Build()
		);

		var fontColors = (
			Finished: colors.Green,
			Ongoing: colors.Plum
		);

		var graph = new GraphBuilder()
				.WithAttributes(graph => graph
					.Label(label)
					.LabelLocation(LabelLocation.Top)
					.RankDir(RankDir.LR)
					.LayoutEngine(LayoutEngine.Neato)
					.BgColor(colors.BgColor)
					.FontColor(colors.Text)
					// .Splines(Splines.Curved)
					.FontName(font)
				)
				.WithNodeAttributes(nodes.Default)
				.WithEdgeAttributes(graphEdges => graphEdges
					.Color(colors.Text)
					.ArrowHead(arrowHead)
				)
				// Projects
				.AddCluster("projects", "Projects", configure: project => project
					.WithAttributes(clusters.Outer with { PenColor = colors.Cyan, FontColor = colors.Cyan })
					// Mikotoba
					.AddCluster("graphviz", "Graphviz", configure: mikotoba => mikotoba
						.WithAttributes(clusters.Outer with { PenColor = colors.Cyan, FontColor = colors.Cyan })
						.AddNode("graphviz_hidden", nodes.Hidden)
						.AddHtml("t_graphviz", html => html
							.WithAttributes(tableAttr, nodes.Table)
							.AddRow(row => row.AddCell("visualization", "Visualization".FontColor(fontColors.Finished), cells.Finished))
						)
					)
					// Mikotoba
					.AddCluster("mikotoba", "Mikotoba", configure: mikotoba => mikotoba
						.WithAttributes(clusters.Outer with { PenColor = colors.Cyan, FontColor = colors.Cyan })
						.AddNode("mikotoba_hidden", nodes.Hidden)
						.AddHtml("t_mikotoba", html => html
							.WithAttributes(tableAttr, nodes.Table)
							.AddRow(row => row.AddCell("todo",     "To Do List".FontColor(fontColors.Ongoing), cells.Ongoing))
							.AddRow(row => row.AddCell("priority", "Triaging",                                 cells.Default))
							.AddRow(row => row.AddCell("kanban",   "Kanban",                                   cells.Default))
							.AddRow(row => row.AddCell("projects", "Projects",                                 cells.Default))
						)
					)
					// Tomoya
					.AddCluster("tomoya", "Tomoya", configure: tomoya => tomoya
						.WithAttributes(clusters.Outer with { PenColor = colors.Cyan, FontColor = colors.Cyan })
						.AddNode("tomoya_hidden", nodes.Hidden)
						.AddHtml("t_tomoya", html => html
							.WithAttributes(tableAttr, nodes.Table)
							.AddRow(row => row.AddCell("alarms",    "Alarms",    cells.Default))
							.AddRow(row => row.AddCell("deadlines", "Deadlines", cells.Default))
							.AddRow(row => row.AddCell("reminders", "Reminders", cells.Default))
							.AddRow(row => row.AddCell("projects",  "Projects",  cells.Default))
						)
					)
					.AddNode("projects_hidden",  nodes.Hidden)
					.AddNode("projects_hidden2", nodes.Hidden)
					.AddNode("projects_hidden3", nodes.Hidden)
					.AddEdge("projects_hidden",  "projects_hidden2", edges.Hidden)
					.AddEdge("projects_hidden2", "projects_hidden3", edges.Hidden)
				)

				// Systems
				.AddCluster("systems", "Systems", configure: systems => systems
					.WithAttributes(clusters.Outer with { PenColor = colors.Purple, FontColor = colors.Purple })
					.AddNode("systems_hidden", nodes.Hidden)
					.AddHtml("t_tomoya", html => html
						.WithAttributes(tableAttr, nodes.Table)
						.AddRow(row => row.AddCell("alarms",    "Alarms",    cells.Default))
						.AddRow(row => row.AddCell("deadlines", "Deadlines", cells.Default))
						.AddRow(row => row.AddCell("reminders", "Reminders", cells.Default))
						.AddRow(row => row.AddCell("projects",  "Projects",  cells.Default))
					)
					// Expression
					.AddCluster("expression", "Expression", configure: tomoya => tomoya
						.WithAttributes(clusters.Inner)
						.AddNode("expression_hidden", nodes.Hidden)
						.AddHtml("t_expression", html => html
							.WithAttributes(tableAttr, nodes.Table)
							.AddRow(row => row.AddCell("ouvre",    "Ouvre",    cells.Default))
							.AddRow(row => row.AddCell("art",      "Art",      cells.Default))
							.AddRow(row => row.AddCell("writing",  "Writing",  cells.Default))
							.AddRow(row => row.AddCell("projects", "Projects", cells.Default))
							.AddRow(row => row.AddCell("tools",    "Tools",    cells.Default))
						)
					)
					.AddCluster("intellectual", "Intellectual", configure: tomoya => tomoya
						.WithAttributes(clusters.Inner)
						.AddNode("intellectual_hidden", nodes.Hidden)
						.AddHtml("t_intellectual", html => html
							.WithAttributes(tableAttr, nodes.Table)
							.AddRow(row => row.AddCell("studying",   "Studying",   cells.Default))
							.AddRow(row => row.AddCell("practicing", "Practicing", cells.Default))
							.AddRow(row => row.AddCell("expertise",  "Expertise",  cells.Default))
							.AddRow(row => row.AddCell("research",   "Research",   cells.Default))
						)
					)
					.AddCluster("thoughts", "Thoughts", configure: tomoya => tomoya
						.WithAttributes(clusters.Inner)
						.AddNode("thoughts_hidden", nodes.Hidden)
						.AddHtml("t_thoughts", html => html
							.WithAttributes(tableAttr, nodes.Table)
							.AddRow(row => row.AddCell("ideas_insights", "Ideas, insights", cells.Default))
							.AddRow(row => row.AddCell("biography",      "Biography",       cells.Default))
							.AddRow(row => row.AddCell("knowledge",      "Knowledge",       cells.Default))
							.AddRow(row => row.AddCell("philosophy",     "Philosophy",      cells.Default))
						)
					)
					.AddCluster("time_awareness", "Time-awareness", configure: tomoya => tomoya
						.WithAttributes(clusters.Inner)
						.AddNode("time_awareness_hidden", nodes.Hidden)
						.AddHtml("t_time_awareness", html => html
							.WithAttributes(tableAttr, nodes.Table)
							.AddRow(row => row.AddCell("scheduling", "Scheduling", cells.Default))
							.AddRow(row => row.AddCell("deadlines",  "Deadlines",  cells.Default))
						)
					)
					.AddCluster("self_direction", "Self-direction", configure: tomoya => tomoya
						.WithAttributes(clusters.Inner)
						.AddNode("self_direction_hidden", nodes.Hidden)
						.AddHtml("t_self_direction", html => html
							.WithAttributes(tableAttr, nodes.Table)
							.AddRow(row => row.AddCell("motivations", "Motivations", cells.Default))
							.AddRow(row => row.AddCell("desires",     "Desires",     cells.Default))
							.AddRow(row => row.AddCell("goals",       "Goals",       cells.Default))
						)
					)
					.AddCluster("finances", "Finances", configure: tomoya => tomoya
						.WithAttributes(clusters.Inner)
						.AddNode("finances_hidden", nodes.Hidden)
						.AddHtml("t_finances", html => html
							.WithAttributes(tableAttr, nodes.Table)
							.AddRow(row => row.AddCell("payments",    "Payments",    cells.Default))
							.AddRow(row => row.AddCell("tracking",    "Tracking",    cells.Default))
							.AddRow(row => row.AddCell("savings",     "Savings",     cells.Default))
							.AddRow(row => row.AddCell("investments", "Investments", cells.Default))
						)
					)
					.AddCluster("health", "Health", configure: tomoya => tomoya
						.WithAttributes(clusters.Inner)
						.AddNode("health_hidden", nodes.Hidden)
						.AddHtml("t_health", html => html
							.WithAttributes(tableAttr, nodes.Table)
							.AddRow(row => row.AddCell("diet_nutrition", "Diet, nutrition", cells.Default))
							.AddRow(row => row.AddCell("exercise",       "Exercise",        cells.Default))
							.AddRow(row => row.AddCell("hygiene",        "Hygiene",         cells.Default))
							.AddRow(row => row.AddCell("check_up",       "Check-up",        cells.Default))
							.AddRow(row => row.AddCell("mindfulness",    "Mindfulness",     cells.Default))
						)
					)
					.AddNode("systems_hidden2", nodes.Hidden)
					.AddNode("systems_hidden3", nodes.Hidden)
					.AddNode("systems_hidden4", nodes.Hidden)
					.AddEdge("systems_hidden",  "systems_hidden2", edges.Hidden)
					.AddEdge("systems_hidden2", "systems_hidden3", edges.Hidden)
					.AddEdge("systems_hidden3", "systems_hidden4", edges.Hidden)
				)
				// Goals
				.AddCluster("goals", "long-term goals", prereq => prereq
					.WithAttributes(clusters.Outer with { PenColor = colors.Plum, FontColor = colors.Plum })
					// .WithNodeAttributes(gNodes => gNodes
					// 	.Style(NodeStyle.Filled)
					// 	.FillColor(colors.Transparent)
					// 	.Color(colors.Text)
					// )
					.AddNode("goals_hidden",            nodes.Hidden)
					.AddNode("Choose a Specialization", nodes.Normal)
					.AddNode("Define success",          nodes.Normal)
					.AddNode("Belongingness",           nodes.Normal)
				)
				// hidden, for placement
				.AddEdge("graphviz_hidden",  "mikotoba_hidden", edges.Hidden)
				.AddEdge("mikotoba_hidden",  "tomoya_hidden",   edges.Hidden)
				.AddEdge("projects_hidden3", "systems_hidden",  edges.Hidden)
				.AddEdge("systems_hidden4",  "goals_hidden",    edges.Hidden)
				// hidden, systems
				.AddEdge("expression_hidden",     "intellectual_hidden",   edges.Hidden)
				.AddEdge("intellectual_hidden",   "thoughts_hidden",       edges.Hidden)
				.AddEdge("thoughts_hidden",       "health_hidden",         edges.Hidden)
				.AddEdge("time_awareness_hidden", "self_direction_hidden", edges.Hidden)
				.AddEdge("self_direction_hidden", "finances_hidden",       edges.Hidden)
				// Graph Edges
				.AddEdge("Start Here",               "t_graphviz:visualization", edges.Done with { Label = "took 4 years\n(2026.04.23)" })
				.AddEdge("t_graphviz:visualization", "t_mikotoba:todo",          edges.Ongoing with { Label = "let's see how long" })
				.AddNode("Start Here", nodes.Finished)
			;

		return graph.Build();
	}
}
