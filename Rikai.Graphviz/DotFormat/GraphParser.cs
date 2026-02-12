using System.Text;

namespace Rikai.Graphviz;

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
		a.AppendLine(ParseEnumAttribute("splines", attributes.Splines));
		a.AppendLine(ParseEnumAttribute("rankdir", attributes.RankDir));
		a.AppendLine(ParseEnumAttribute("overlap", attributes.Overlap));
		a.AppendLine(ParseEnumAttribute("layout",  attributes.LayoutEngine));

		string result = $"""
		                 graph [
		                 {RemoveTrailingLine(a)}
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
		a.AppendLine(ParseEnumAttribute("shape", attributes.Shape));

		string result = $"""
		                 node [
		                 {RemoveTrailingLine(a)}
		                 ]
		                 """;
		return IndentLines(result, 1);
	}

	internal string ParseGraphEdgeAttributes(EdgeAttributes attributes)
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
		a.AppendLine(ParseEnumAttribute("arrowhead", attributes.ArrowHead));
		a.AppendLine(ParseEnumAttribute("arrowtail", attributes.ArrowTail));

		string result = $"""
		                 edge [ 
		                 {RemoveTrailingLine(a)}
		                 ]
		                 """;
		return IndentLines(result, 1);
	}

	internal string ParseGraphEdges(GraphEdges edges)
	{
		StringBuilder result = new();
		foreach (Edge edge in edges.Edges)
		{
			result.AppendLine($"{Indent(1)}{ParseEdge(edge)}");
		}

		return RemoveTrailingLine(result);
	}

	internal string ParseEdge(Edge edge)
	{
		return $$"""
		         { {{ParseIds(edge.FromNodeIds)}}} {{_edgeSymbol}} { {{ParseIds(edge.ToNodeIds)}}}
		         """;
	}
}