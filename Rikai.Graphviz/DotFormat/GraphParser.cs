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

		string result = $$"""
		                  graph [
		                  {{ParseAttribute("label", attributes.Label)}}
		                  {{ParseAttribute("fontname", attributes.FontName)}}
		                  {{ParseAttribute("fontcolor", attributes.FontColor)}}
		                  {{ParseAttribute("bgcolor", attributes.BackgroundColor)}}
		                  {{ParseEnumAttribute("splines", attributes.Splines)}}
		                  {{ParseEnumAttribute("rankdir", attributes.RankDir)}}
		                  {{ParseEnumAttribute("overlap", attributes.Overlap)}}
		                  {{ParseEnumAttribute("layout", attributes.LayoutEngine)}}
		                  ]
		                  """;

		return IndentLines(RemoveEmptyLines(result), 1);
	}

	internal string ParseGraphNodeAttributes(NodeAttributes attributes)
	{
		if (attributes.IsEmpty)
		{
			return "";
		}

		string result = $$"""
		                  node [
		                  {{ParseAttribute("label", attributes.Label)}}
		                  {{ParseAttribute("fontname", attributes.FontName)}}
		                  {{ParseAttribute("fontcolor", attributes.FontColor)}}
		                  {{ParseAttribute("fillcolor", attributes.FillColor)}}
		                  {{ParseAttribute("color", attributes.Color)}}
		                  {{ParseEnumAttribute("shape", attributes.Shape)}}
		                  ]
		                  """;
		return IndentLines(RemoveEmptyLines(result), 1);
	}

	internal string ParseGraphEdgeAttributes(EdgeAttributes attributes)
	{
		if (attributes.IsEmpty)
		{
			return "";
		}

		string result = $$"""
		                  edge [ 
		                  {{ParseAttribute("label", attributes.Label)}}
		                  {{ParseAttribute("fontname", attributes.FontName)}}
		                  {{ParseAttribute("fontcolor", attributes.FontColor)}}
		                  {{ParseAttribute("color", attributes.Color)}}
		                  {{ParseEnumAttribute("arrowhead", attributes.ArrowHead)}}
		                  {{ParseEnumAttribute("arrowtail", attributes.ArrowTail)}}
		                  ]
		                  """;
		return IndentLines(RemoveEmptyLines(result), 1);
	}
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

		return RemoveEmptyLines(result);
	}

	internal string ParseEdge(Edge edge)
	{
		return $$"""
		         { {{ParseIds(edge.FromNodeIds)}}} {{_edgeSymbol}} { {{ParseIds(edge.ToNodeIds)}}}
		         """;
	}
}