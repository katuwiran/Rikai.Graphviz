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
		var attr = _graph.Attributes;

		if (attr.IsEmpty) return;

		string baseIndent  = Helpers.Indent(_indent);
		string innerIndent = Helpers.Indent(_indent + 1);

		_sb.AppendLine(baseIndent + "graph [");
		Append(innerIndent, Helpers.FormatAttribute("label", attr.Label));
		Append(innerIndent, Helpers.FormatAttribute("labelloc", attr.LabelLocation).ToLower());
		Append(innerIndent, Helpers.FormatAttribute("fontname",  attr.FontName));
		Append(innerIndent, Helpers.FormatAttribute("fontcolor", attr.FontColor));
		Append(innerIndent, Helpers.FormatAttribute("bgcolor",   attr.BackgroundColor));
		Append(innerIndent, Helpers.FormatAttribute("splines",   attr.Splines).ToLower());
		Append(innerIndent, Helpers.FormatAttribute("rankdir", attr.RankDir));
		Append(innerIndent, Helpers.FormatAttribute("overlap", attr.Overlap).ToLower());
		_sb.AppendLine(baseIndent + "]");
	}

	public void FormatGraphNodeAttributes()
	{
		var attr = _graph.Nodes.Attributes;

		if (attr.IsEmpty) return;

		string baseIndent  = Helpers.Indent(_indent);
		string innerIndent = Helpers.Indent(_indent + 1);

		_sb.AppendLine(baseIndent + "node [");
		FormatNodeAttributes(innerIndent, attr);
		_sb.AppendLine(baseIndent + "]");
	}

	public void FormatGraphEdgeAttributes()
	{
		var attr = _graph.Edges.Attributes;

		if (attr.IsEmpty) return;

		string baseIndent  = Helpers.Indent(_indent);
		string innerIndent = Helpers.Indent(_indent + 1);

		_sb.AppendLine(baseIndent + "edge [");
		FormatEdgeAttributes(innerIndent, attr);
		_sb.AppendLine(baseIndent + "]");
	}

	public void FormatGraphClusters()
	{
		var clusters = _graph.Clusters.Collection;

		if (!clusters.Any()) return;

		foreach (var cluster in clusters)
		{
			FormatCluster(_indent, cluster);
		}
	}

	public void FormatCluster(int currentIndent, Cluster cluster)
	{
		string baseIndent  = Helpers.Indent(currentIndent);
		string innerIndent = Helpers.Indent(currentIndent + 1);

		var attr = cluster.Attributes;

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
		FormatClusterNodes(currentIndent, cluster.Nodes.Collection);
		FormatClusterEdges(currentIndent, cluster.Edges.Collection);
		FormatNestedClusters(currentIndent + 1, cluster.Clusters.Collection);
		_sb.AppendLine(baseIndent          + "}");
	}

	public void FormatNestedClusters(int currentIndent, List<Cluster> clusters)
	{
		if (!clusters.Any()) return;

		// by default, graphviz renders first the last defined subgraph
		// for now, by default the lib will reverse it first
		clusters.Reverse();

		foreach (var cluster in clusters)
		{
			FormatCluster(currentIndent, cluster);
		}
	}

	public void FormatClusterEdges(int currentIndent, List<Edge> edges)
	{
		if (!edges.Any()) return;

		int indentLevel = currentIndent;

		string baseIndent  = Helpers.Indent(indentLevel + 1);
		string innerIndent = Helpers.Indent(indentLevel + 2);

		foreach (var edge in edges)
		{
			FormatEdge(baseIndent, innerIndent, edge);
		}
	}

	public void FormatClusterNodes(int currentIndent, List<Node> nodes)
	{
		if (!nodes.Any()) return;

		int indentLevel = currentIndent;

		string baseIndent  = Helpers.Indent(indentLevel + 1);
		string innerIndent = Helpers.Indent(indentLevel + 2);

		// cluster nodes reversed to appear as they are inputted
		nodes.Reverse();

		foreach (var node in nodes)
		{
			FormatNode(baseIndent, innerIndent, node);
		}
	}

	public void FormatClusterNodeAttributes(int currentIndent, NodeAttributes attr)
	{
		if (attr.IsEmpty) return;

		int indentLevel = currentIndent;

		string baseIndent  = Helpers.Indent(indentLevel + 1);
		string innerIndent = Helpers.Indent(indentLevel + 2);

		_sb.AppendLine(baseIndent + "node [");
		FormatNodeAttributes(innerIndent, attr);
		_sb.AppendLine(baseIndent + "]");
	}

	public void FormatClusterEdgeAttributes(int currentIndent, EdgeAttributes attr)
	{
		if (attr.IsEmpty) return;

		int indentLevel = currentIndent;

		string baseIndent  = Helpers.Indent(indentLevel + 1);
		string innerIndent = Helpers.Indent(indentLevel + 2);

		_sb.AppendLine(baseIndent + "edge [");
		FormatEdgeAttributes(innerIndent, attr);
		_sb.AppendLine(baseIndent + "]");
	}


	public void FormatClusterAttributes(string innerIndent, ClusterAttributes attr)
	{
		if (attr.IsEmpty) return;

		Append(innerIndent, Helpers.FormatAttribute("cluster", attr.IsCluster).ToLower());
		Append(innerIndent, Helpers.FormatAttribute("label",   attr.Label));
		Append(innerIndent, Helpers.FormatAttribute("labelloc", attr.LabelLoc));
		Append(innerIndent, Helpers.FormatAttribute("fontcolor", attr.FontColor));
		Append(innerIndent, Helpers.FormatAttribute("fontname",  attr.FontName));
		Append(innerIndent, Helpers.FormatAttribute("color",     attr.Color));
		Append(innerIndent, Helpers.FormatAttribute("fillcolor", attr.FillColor));
		Append(innerIndent, Helpers.FormatAttribute("bgcolor",   attr.BackgroundColor));
		Append(innerIndent, Helpers.FormatAttribute("pencolor",  attr.PenColor));
		Append(innerIndent, Helpers.FormatAttribute("penwidth", attr.PenWidth));
	}

	public void FormatGraphNodes()
	{
		// todo include an OR statement, where nodes not in edge definitions are included either way
		// var nodeWithAttributes = nodes.Nodes.Where(n => !n.Attributes.IsEmpty);
		var nodeWithAttributes = _graph.Nodes.Collection;

		if (!nodeWithAttributes.Any()) return;

		string baseIndent  = Helpers.Indent(_indent);
		string innerIndent = Helpers.Indent(_indent + 1);

		foreach (var node in nodeWithAttributes)
		{
			FormatNode(baseIndent, innerIndent, node);
		}
	}

	public void FormatGraphEdges()
	{
		var edges = _graph.Edges.Collection;

		if (!edges.Any()) return;

		string baseIndent  = Helpers.Indent(_indent);
		string innerIndent = Helpers.Indent(_indent + 1);

		foreach (var edge in edges)
		{
			FormatEdge(baseIndent, innerIndent, edge);
		}
	}


	internal void FormatNodeAttributes(string innerIndent, NodeAttributes attr)
	{
		Append(innerIndent, Helpers.FormatAttribute("label",     attr.Label));
		Append(innerIndent, Helpers.FormatAttribute("fontname",  attr.FontName));
		Append(innerIndent, Helpers.FormatAttribute("fontcolor", attr.FontColor));
		Append(innerIndent, Helpers.FormatAttribute("fillcolor", attr.FillColor));
		Append(innerIndent, Helpers.FormatAttribute("color",     attr.Color));
		Append(innerIndent, Helpers.FormatAttribute("shape", attr.Shape).ToLower());
	}

	internal void FormatEdgeAttributes(string innerIndent, EdgeAttributes attr)
	{
		Append(innerIndent, Helpers.FormatAttribute("label",     attr.Label));
		Append(innerIndent, Helpers.FormatAttribute("fontname",  attr.FontName));
		Append(innerIndent, Helpers.FormatAttribute("fontcolor", attr.FontColor));
		Append(innerIndent, Helpers.FormatAttribute("color",     attr.Color));
		Append(innerIndent, Helpers.FormatAttribute("arrowhead", attr.ArrowHead).ToLower());
		Append(innerIndent, Helpers.FormatAttribute("arrowtail", attr.ArrowTail).ToLower());
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

			foreach (var id in ids)
			{
				result.Append($"\"{id}\" ");
			}

			return result.ToString();
		}
	}

	// This local function handles the concatenation, appending, AND empty checks
	void Append(string innerIndent, string formattedAttr)
	{
		if (!string.IsNullOrWhiteSpace(formattedAttr))
		{
			_sb.Append($"{innerIndent}{formattedAttr}");
		}
	}
}