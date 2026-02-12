using System.Text;

namespace Rikai.Graphviz.DotFormat;

// parts of this parser, in order of appearance
// graph type
// graph attributes
// graph node attributes
// graph edge attributes
// nodes (all nodes with additional attributes except label)
// edges
// node
// edge
internal partial class GraphParser
{
	private        string _edgeSymbol = "";
	private static string _indentChar = "   "; // todo: make this a setting

	internal string ParseGraphType(GraphType type)
	{
		if (type == GraphType.Directed)
		{
			_edgeSymbol = "--";
			return "graph";
		}
		else
		{
			_edgeSymbol = "->";
			return "digraph";
		}
	}

	internal string ParseGraphAttributes(GraphAttributes attributes)
	{
		if (attributes.IsEmpty)
		{
			return "";
		}

		StringBuilder a = new();
		a.AppendLine(ParseAttribute("label",     attributes.Label));
		a.AppendLine(ParseAttribute("fontname",  attributes.FontName));
		a.AppendLine(ParseAttribute("fontcolor", attributes.FontColor));
		a.AppendLine(ParseAttribute("bgcolor",   attributes.BackgroundColor));

		string cleaned = string.Join(Environment.NewLine,
		                             a.ToString().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
		string result = $"""
		                 graph [
		                 {cleaned}
		                 ]
		                 """;
		return IndentLines(result, 1);
	}

	internal string ParseGraphNodeAttributes(NodeAttributes attributes)
	{
		if (attributes.IsEmpty)
		{
			return "";
		}

		StringBuilder a = new();
		a.AppendLine(ParseAttribute("label",     attributes.Label));
		a.AppendLine(ParseAttribute("fontname",  attributes.FontName));
		a.AppendLine(ParseAttribute("fontcolor", attributes.FontColor));
		a.AppendLine(ParseAttribute("fillcolor", attributes.FillColor));
		a.AppendLine(Parse("shape", attributes.Shape));

		string cleaned = string.Join(Environment.NewLine,
		                             a.ToString().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
		string result = $"""
		                 node [
		                 {cleaned}
		                 ]
		                 """;
		return IndentLines(result, 1);
	}

	internal string ParseGraphEdgeAttributes(EdgeAttributes attributes)
	{
	{
		StringBuilder result = new();
		foreach (Edge edge in edges.Edges)
		{
			result.AppendLine($"{Indent(1)}{Parse(edge)}");
		}

		return result.ToString();
	}

	internal string ParseEdge(Edge edge)
	{
		return $$"""
		         { {{ParseIds(edge.FromNodeIds)}}} {{_edgeSymbol}} { {{ParseIds(edge.ToNodeIds)}}}
		         """;
	}

	internal string Parse(EdgeAttributes attributes)
	{
		return null;
	}

	internal string ParseIds(IEnumerable<string> ids)
	{
		StringBuilder result = new();

		foreach (var id in ids)
		{
			result.Append($"{id} ");
		}

		return result.ToString();
	}

	internal static string? ParseAttributeValue(string? label)
	{
		return label == null ? null : label;
	}

	internal static string ParseShape(string name, Shape? value)
		return ParseAttributeValue(value) == null ? "" : $"{Indent(1)}\"{attribute}\" = \"{value}\"";
	}
	
	internal static string Parse(string attribute, Shape? shape)
	{
		if (shape == null)
		{
			return "";	
		}
		string value = Parse((Shape)shape);
		return ParseAttributeValue(value) == null ? "" : $"{Indent(1)}\"{attribute}\" = \"{value}\"";
	}

	internal static string ParseArrowType(string name, ArrowType? value)
	{
		return ParseEnum(shape);
	}

	internal static string ParseLayout(string name, LayoutEngine? value)
	{
		return input.ToString().ToLower();
	}
}