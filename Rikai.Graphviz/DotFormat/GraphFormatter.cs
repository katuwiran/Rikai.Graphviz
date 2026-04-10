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

	// This local function handles the concatenation, appending, AND empty checks
	void Append(string innerIndent, string formattedAttr)
	{
		if (!string.IsNullOrWhiteSpace(formattedAttr))
		{
			_sb.Append($"{innerIndent}{formattedAttr}");
		}
	}

	public void FormatGraphAttributes()
	{
		var attr = _graph.Attributes;

		if (attr.IsEmpty) return;

		string baseIndent  = Helpers.Indent(_indent);
		string innerIndent = Helpers.Indent(_indent + 1);

		_sb.AppendLine(baseIndent + "graph [");
		Append(innerIndent, Helpers.FormatAttribute("label", attr.Label));
		Append(innerIndent, Helpers.FormatAttributeEnum("labellocation", attr.LabelLocation));
		Append(innerIndent, Helpers.FormatAttribute("fontname",  attr.FontName));
		Append(innerIndent, Helpers.FormatAttribute("fontcolor", attr.FontColor));
		Append(innerIndent, Helpers.FormatAttribute("bgcolor",   attr.BackgroundColor));
		Append(innerIndent, Helpers.FormatAttributeEnum("splines", attr.Splines));
		Append(innerIndent, Helpers.FormatAttributeEnum("rankdir", attr.RankDir));
		Append(innerIndent, Helpers.FormatAttributeEnum("overlap", attr.Overlap).ToLower());
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

	public void FormatGraphNodes()
	{
		// todo include an OR statement, where nodes not in edge definitions are included either way
		// var nodeWithAttributes = nodes.Nodes.Where(n => !n.Attributes.IsEmpty);
		var nodeWithAttributes = _graph.Nodes.Nodes;

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
		var edges = _graph.Edges.Edges;

		if (!edges.Any()) return;

		string baseIndent  = Helpers.Indent(_indent);
		string innerIndent = Helpers.Indent(_indent + 1);

		foreach (var edge in edges)
		{
			FormatEdge(baseIndent, innerIndent, edge);
		}
	}

	internal void FormatEdge(string baseIndent, string innerIndent, Edge edge)
	{
		string edgeStr = "{" + FormatIds(edge.FromNodeIds) + "}"
			+ $" {_edgeSymbol} "
			+ "{" + FormatIds(edge.ToNodeIds) +"}";

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

	internal void FormatNodeAttributes(string innerIndent, NodeAttributes attr)
	{
		Append(innerIndent, Helpers.FormatAttribute("label",     attr.Label));
		Append(innerIndent, Helpers.FormatAttribute("fontname",  attr.FontName));
		Append(innerIndent, Helpers.FormatAttribute("fontcolor", attr.FontColor));
		Append(innerIndent, Helpers.FormatAttribute("fillcolor", attr.FillColor));
		Append(innerIndent, Helpers.FormatAttribute("color",     attr.Color));
		Append(innerIndent, Helpers.FormatAttributeEnum("shape", attr.Shape).ToLower());
	}

	internal void FormatEdgeAttributes(string innerIndent, EdgeAttributes attr)
	{
		Append(innerIndent, Helpers.FormatAttribute("label",     attr.Label));
		Append(innerIndent, Helpers.FormatAttribute("fontname",  attr.FontName));
		Append(innerIndent, Helpers.FormatAttribute("fontcolor", attr.FontColor));
		Append(innerIndent, Helpers.FormatAttribute("color",     attr.Color));
		Append(innerIndent, Helpers.FormatAttributeEnum("arrowhead", attr.ArrowHead).ToLower());
		Append(innerIndent, Helpers.FormatAttributeEnum("arrowtail", attr.ArrowTail).ToLower());
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
}