using System.Text;

namespace Rikai.Graphviz.DotFormat;

public class GraphFormatter
{
	private StringBuilder _sb;
	private int           _indent;
	private Graph         _graph;
	private string        _edgeSymbol;

	public GraphFormatter(DotGenerator generator)
	{
		_sb         = generator.Sb;
		_indent     = generator.Indent;
		_graph      = generator.Graph;
		_edgeSymbol = generator.EdgeSymbol;
	}

	public void FormatGraphAttributes()
	{
		GraphAttributes attr = _graph.Attributes;

		if (attr.IsEmpty) return;

		string baseIndent  = Helpers.Indent(_indent);
		string innerIndent = Helpers.Indent(_indent + 1);

		_sb.AppendLine(baseIndent + "graph [");
		AppendLine(innerIndent, Helpers.FormatAttribute("label",     attr.Label));
		AppendLine(innerIndent, Helpers.FormatAttribute("labelloc",  attr.LabelLocation).ToLower());
		AppendLine(innerIndent, Helpers.FormatAttribute("fontname",  attr.FontName));
		AppendLine(innerIndent, Helpers.FormatAttribute("fontcolor", attr.FontColor));
		AppendLine(innerIndent, Helpers.FormatAttribute("bgcolor",   attr.BackgroundColor));
		AppendLine(innerIndent, Helpers.FormatAttribute("splines",   attr.Splines).ToLower());
		AppendLine(innerIndent, Helpers.FormatAttribute("rankdir",   attr.RankDir));
		AppendLine(innerIndent, Helpers.FormatAttribute("overlap",   attr.Overlap).ToLower());
		_sb.AppendLine(baseIndent + "]");
	}

	public void FormatGraphNodeAttributes()
	{
		NodeAttributes attr = _graph.Nodes.Attributes;

		if (attr.IsEmpty)
		{
			return;
		}

		string baseIndent  = Helpers.Indent(_indent);
		string innerIndent = Helpers.Indent(_indent + 1);

		_sb.AppendLine(baseIndent + "node [");
		FormatNodeAttributes(innerIndent, attr);
		_sb.AppendLine(baseIndent + "]");
	}

	public void FormatGraphEdgeAttributes()
	{
		EdgeAttributes attr = _graph.Edges.Attributes;

		if (attr.IsEmpty)
		{
			return;
		}

		string baseIndent  = Helpers.Indent(_indent);
		string innerIndent = Helpers.Indent(_indent + 1);

		_sb.AppendLine(baseIndent + "edge [");
		FormatEdgeAttributes(innerIndent, attr);
		_sb.AppendLine(baseIndent + "]");
	}

	public void FormatGraphClusters()
	{
		List<Cluster> clusters = _graph.Clusters.Collection;

		if (!clusters.Any())
		{
			return;
		}

		foreach (Cluster cluster in clusters)
		{
			FormatCluster(_indent, cluster);
		}
	}

	public void FormatGraphTables()
	{
		List<HtmlTable> tables = _graph.Tables;

		FormatTables(_indent, tables);
	}

	public void FormatCluster(int currentIndent, Cluster cluster)
	{
		string baseIndent  = Helpers.Indent(currentIndent);
		string innerIndent = Helpers.Indent(currentIndent + 1);

		ClusterAttributes attr = cluster.Attributes;

		string clusterHeader;

		// subgraph vs cluster header
		if (attr.IsCluster is not null)
		{
			bool isCluster = (bool)attr.IsCluster;
			if (isCluster)
			{
				clusterHeader = baseIndent + "subgraph cluster_" + cluster.Id + " {";
				_sb.AppendLine(clusterHeader);
			}
			else
			{
				clusterHeader = baseIndent + "subgraph " + cluster.Id + " {";
				_sb.AppendLine(clusterHeader);
			}
		}
		else
		{
			clusterHeader = baseIndent + "subgraph " + cluster.Id + " {";
			_sb.AppendLine(clusterHeader);
		}

		FormatClusterAttributes(innerIndent, cluster.Attributes);
		FormatClusterNodeAttributes(currentIndent, cluster.Nodes.Attributes);
		FormatTables(currentIndent, cluster.HtmlTables);
		FormatNestedClusters(currentIndent + 1, cluster.Clusters.Collection);
		FormatClusterNodes(currentIndent, cluster.Nodes.Collection);
		FormatClusterEdges(currentIndent, cluster.Edges.Collection);
		_sb.AppendLine(baseIndent + "}");
	}

	public void FormatNestedClusters(int currentIndent, List<Cluster> clusters)
	{
		if (!clusters.Any())
		{
			return;
		}

		// by default, graphviz renders first the last defined subgraph
		// for now, by default the lib will reverse it first
		clusters.Reverse();

		foreach (Cluster cluster in clusters)
		{
			FormatCluster(currentIndent, cluster);
		}
	}

	public void FormatClusterEdges(int currentIndent, List<Edge> edges)
	{
		if (!edges.Any())
		{
			return;
		}

		int indentLevel = currentIndent;

		string baseIndent  = Helpers.Indent(indentLevel + 1);
		string innerIndent = Helpers.Indent(indentLevel + 2);

		foreach (Edge edge in edges)
		{
			FormatEdge(baseIndent, innerIndent, edge);
		}
	}

	public void FormatClusterNodes(int currentIndent, List<Node> nodes)
	{
		if (!nodes.Any())
		{
			return;
		}

		int indentLevel = currentIndent;

		string baseIndent  = Helpers.Indent(indentLevel + 1);
		string innerIndent = Helpers.Indent(indentLevel + 2);

		// cluster nodes reversed to appear as they are inputted
		nodes.Reverse();

		foreach (Node node in nodes)
		{
			FormatNode(baseIndent, innerIndent, node);
		}
	}

	public void FormatClusterNodeAttributes(int currentIndent, NodeAttributes attr)
	{
		if (attr.IsEmpty)
		{
			return;
		}

		int indentLevel = currentIndent;

		string baseIndent  = Helpers.Indent(indentLevel + 1);
		string innerIndent = Helpers.Indent(indentLevel + 2);

		_sb.AppendLine(baseIndent + "node [");
		FormatNodeAttributes(innerIndent, attr);
		_sb.AppendLine(baseIndent + "]");
	}

	public void FormatClusterEdgeAttributes(int currentIndent, EdgeAttributes attr)
	{
		if (attr.IsEmpty)
		{
			return;
		}

		int indentLevel = currentIndent;

		string baseIndent  = Helpers.Indent(indentLevel + 1);
		string innerIndent = Helpers.Indent(indentLevel + 2);

		_sb.AppendLine(baseIndent + "edge [");
		FormatEdgeAttributes(innerIndent, attr);
		_sb.AppendLine(baseIndent + "]");
	}


	public void FormatClusterAttributes(string innerIndent, ClusterAttributes attr)
	{
		if (attr.IsEmpty)
		{
			return;
		}

		AppendLine(innerIndent, Helpers.FormatAttribute("label",     attr.Label));
		AppendLine(innerIndent, Helpers.FormatAttribute("labelloc",  attr.LabelLoc));
		AppendLine(innerIndent, Helpers.FormatAttribute("fontcolor", attr.FontColor));
		AppendLine(innerIndent, Helpers.FormatAttribute("fontname",  attr.FontName));
		AppendLine(innerIndent, Helpers.FormatAttribute("color",     attr.Color));
		AppendLine(innerIndent, Helpers.FormatAttribute("fillcolor", attr.FillColor));
		AppendLine(innerIndent, Helpers.FormatAttribute("bgcolor",   attr.BackgroundColor));
		AppendLine(innerIndent, Helpers.FormatAttribute("style",     attr.Style).ToLower());
		AppendLine(innerIndent, Helpers.FormatAttribute("pencolor",  attr.PenColor));
		AppendLine(innerIndent, Helpers.FormatAttribute("penwidth",  attr.PenWidth));
	}

	public void FormatGraphNodes()
	{
		// todo include an OR statement, where nodes not in edge definitions are included either way
		// var nodeWithAttributes = nodes.Nodes.Where(n => !n.Attributes.IsEmpty);
		List<Node> nodeWithAttributes = _graph.Nodes.Collection;

		if (!nodeWithAttributes.Any())
		{
			return;
		}

		string baseIndent  = Helpers.Indent(_indent);
		string innerIndent = Helpers.Indent(_indent + 1);

		foreach (Node node in nodeWithAttributes)
		{
			FormatNode(baseIndent, innerIndent, node);
		}
	}

	public void FormatGraphEdges()
	{
		List<Edge> edges = _graph.Edges.Collection;

		if (!edges.Any())
		{
			return;
		}

		string baseIndent  = Helpers.Indent(_indent);
		string innerIndent = Helpers.Indent(_indent + 1);

		foreach (Edge edge in edges)
		{
			FormatEdge(baseIndent, innerIndent, edge);
		}
	}


	internal void FormatNodeAttributes(string innerIndent, NodeAttributes attr)
	{
		AppendLine(innerIndent, Helpers.FormatAttribute("shape",     attr.Shape).ToLower());
		AppendLine(innerIndent, Helpers.FormatAttribute("style",     attr.Style).ToLower());
		AppendLine(innerIndent, Helpers.FormatAttribute("fontname",  attr.FontName));
		AppendLine(innerIndent, Helpers.FormatAttribute("fontcolor", attr.FontColor));
		AppendLine(innerIndent, Helpers.FormatAttribute("fillcolor", attr.FillColor));
		AppendLine(innerIndent, Helpers.FormatAttribute("color",     attr.Color));
		AppendLine(innerIndent, Helpers.FormatAttribute("label",     attr.Label));
		AppendLine(innerIndent, Helpers.FormatAttribute("width",     attr.Width));
		AppendLine(innerIndent, Helpers.FormatAttribute("fontsize",  attr.FontSize));
	}

	internal void FormatEdgeAttributes(string innerIndent, EdgeAttributes attr)
	{
		AppendLine(innerIndent, Helpers.FormatAttribute("arrowhead",     attr.ArrowHead).ToLower());
		AppendLine(innerIndent, Helpers.FormatAttribute("arrowtail",     attr.ArrowTail).ToLower());
		AppendLine(innerIndent, Helpers.FormatAttribute("constraint",    attr.Constraint).ToLower());
		AppendLine(innerIndent, Helpers.FormatAttribute("fontname",      attr.FontName));
		AppendLine(innerIndent, Helpers.FormatAttribute("label",         attr.Label));
		AppendLine(innerIndent, Helpers.FormatAttribute("taillabel",     attr.FontColor));
		AppendLine(innerIndent, Helpers.FormatAttribute("headlabel",     attr.FontColor));
		AppendLine(innerIndent, Helpers.FormatAttribute("color",         attr.Color));
		AppendLine(innerIndent, Helpers.FormatAttribute("fontcolor",     attr.FontColor));
		AppendLine(innerIndent, Helpers.FormatAttribute("outlinecolor",  attr.OutlineColor));
		AppendLine(innerIndent, Helpers.FormatAttribute("labeldistance", attr.LabelDistance));
		AppendLine(innerIndent, Helpers.FormatAttribute("labelangle",    attr.LabelAngle));
		AppendLine(innerIndent, Helpers.FormatAttribute("fontsize",      attr.FontSize));
		AppendLine(innerIndent, Helpers.FormatAttribute("length",        attr.Length));
		AppendLine(innerIndent, Helpers.FormatAttribute("minlength",     attr.MinLength));
		AppendLine(innerIndent, Helpers.FormatAttribute("penwidth",      attr.PenWidth));
		AppendLine(innerIndent, Helpers.FormatAttribute("decorate",      attr.Decorate));
	}

	internal void FormatNode(string baseIndent, string innerIndent, Node node)
	{
		if (node.Attributes.IsEmpty)
		{
			_sb.AppendLine(baseIndent + $"\"{node.Id}\"");
		}
		else
		{
			_sb.AppendLine(baseIndent + $"\"{node.Id}\"" + "[");
			FormatNodeAttributes(innerIndent, node.Attributes);
			_sb.AppendLine(baseIndent + "]");
		}
	}

	internal void FormatEdge(string baseIndent, string innerIndent, Edge edge)
	{
		string edgeStr = "{" + FormatIds(edge.FromNodeIds) + "}"
			+ $" {_edgeSymbol} "
			+ "{" + FormatIds(edge.ToNodeIds) + "}";

		if (edge.Attributes.IsEmpty)
		{
			_sb.AppendLine(baseIndent + edgeStr);
		}

		else
		{
			_sb.AppendLine(baseIndent + edgeStr + "[");
			FormatEdgeAttributes(innerIndent, edge.Attributes);
			_sb.AppendLine(baseIndent + "]");
		}


		string FormatIds(IEnumerable<string> ids)
		{
			StringBuilder result = new();

			foreach (string id in ids)
			{
				if (id.Contains(":"))
				{
					Helpers.CheckEdgeIdForPorts(id, out var parsedId);
					result.Append(parsedId);
				}
				else
				{
					result.Append($"\"{id}\" ");
				}
			}

			return result.ToString();
		}
	}

	internal void FormatTables(int currentIndent, List<HtmlTable> tables)
	{
		tables.Reverse(); // so that tables appear in the order they are defined.
		foreach (HtmlTable table in tables)
		{
			FormatTable(currentIndent, table);
		}
	}

	internal void FormatTable(int currentIndent, HtmlTable table)
	{
		string baseIndent  = Helpers.Indent(currentIndent);
		string innerIndent = Helpers.Indent(currentIndent + 1);

		if (table.NodeAttributes.IsEmpty)
		{
			AppendLine(baseIndent, $"{table.Id} [label=<");
		}
		else
		{
			AppendLine(baseIndent, $"{table.Id} [");
			FormatNodeAttributes(innerIndent, table.NodeAttributes);
			AppendLine(innerIndent, "\"label\" = <");
		}

		Append(innerIndent, "<TABLE");
		FormatTableAttributes(table.Attributes);
		AppendLine(">");

		foreach (HtmlRow row in table.Rows)
		{
			FormatRow(currentIndent + 2, row);
		}

		Append(innerIndent, "</TABLE>");
		AppendLine(">];");
	}

	internal void FormatRow(int currentIndent, HtmlRow row)
	{
		string baseIndent = Helpers.Indent(currentIndent);

		AppendLine(baseIndent, "<TR>");

		foreach (HtmlCell cell in row.Cells)
		{
			FormatCell(currentIndent + 1, cell);
		}

		AppendLine(baseIndent, "</TR>");
	}

	internal void FormatCell(int currentIndent, HtmlCell cell)
	{
		string baseIndent  = Helpers.Indent(currentIndent);
		string innerIndent = Helpers.Indent(currentIndent + 1);

		Append(baseIndent, "<TD");
		Append(Helpers.FormatHtmlAttribute("PORT", cell.Port));
		FormatCellAttributes(innerIndent, cell.Attributes);
		Append(">");
		Append($"{cell.Text}");
		AppendLine("</TD>");
	}

	internal void FormatTableAttributes(HtmlTableAttributes attr)
	{
		Append(Helpers.FormatHtmlAttribute("ALIGN",       attr.Align));
		Append(Helpers.FormatHtmlAttribute("BGCOLOR",     attr.BgColor));
		Append(Helpers.FormatHtmlAttribute("BORDER",      attr.Border));
		Append(Helpers.FormatHtmlAttribute("CELLBORDER",  attr.CellBorder));
		Append(Helpers.FormatHtmlAttribute("CELLPADDING", attr.CellPadding));
		Append(Helpers.FormatHtmlAttribute("CELLSPACING", attr.CellSpacing));
		Append(Helpers.FormatHtmlAttribute("COLOR",       attr.Color));
		Append(Helpers.FormatHtmlAttribute("PORT",        attr.Port));
		Append(Helpers.FormatHtmlAttribute("STYLE",       attr.Style));
	}

	internal void FormatCellAttributes(string currentIndent, HtmlCellAttributes attr)
	{
		Append(Helpers.FormatHtmlAttribute("ALIGN",       attr.Align));
		Append(Helpers.FormatHtmlAttribute("BGCOLOR",     attr.BgColor));
		Append(Helpers.FormatHtmlAttribute("BORDER",      attr.Border));
		Append(Helpers.FormatHtmlAttribute("CELLBORDER",  attr.CellBorder));
		Append(Helpers.FormatHtmlAttribute("CELLPADDING", attr.CellPadding));
		Append(Helpers.FormatHtmlAttribute("CELLSPACING", attr.CellSpacing));
		Append(Helpers.FormatHtmlAttribute("COLOR",       attr.Color));
		Append(Helpers.FormatHtmlAttribute("COLSPAN",     attr.ColSpan));
		Append(Helpers.FormatHtmlAttribute("HEIGHT",      attr.Height));
		Append(Helpers.FormatHtmlAttribute("ROWSPAN",     attr.RowSpan));
		Append(Helpers.FormatHtmlAttribute("STYLE",       attr.Style));
		Append(Helpers.FormatHtmlAttribute("WIDTH",       attr.Width));
	}

	internal void FormatHtmlAttribute()
	{
	}

	// This local function handles the concatenation, appending, AND empty checks
	private void AppendLine(string indent, string? formattedAttr)
	{
		if (!string.IsNullOrWhiteSpace(formattedAttr))
		{
			_sb.Append($"{indent}{formattedAttr}\n");
		}
	}

	private void AppendLine(string? formattedAttr)
	{
		if (!string.IsNullOrWhiteSpace(formattedAttr))
		{
			_sb.Append($"{formattedAttr}\n");
		}
	}

	private void Append(string? formattedAttr)
	{
		if (!string.IsNullOrWhiteSpace(formattedAttr))
		{
			_sb.Append($"{formattedAttr}");
		}
	}

	private void Append(string indent, string? formattedAttr)
	{
		if (!string.IsNullOrWhiteSpace(formattedAttr))
		{
			_sb.Append($"{indent}{formattedAttr}");
		}
	}
}
