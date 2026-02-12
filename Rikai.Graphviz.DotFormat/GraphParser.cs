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

	internal string Parse(GraphType type)
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

	public string Parse(GraphEdges edges)
	{
		StringBuilder result = new();
		foreach (Edge edge in edges.Edges)
		{
			result.AppendLine(Parse(edge));
		}

		return result.ToString();
	}

	internal string Parse(Edge edge)
	{
		_indentLevel = 1;
		return $$"""
		         { {{Parse(edge.FromNodeIds)}}} {{_edgeSymbol}} { {{Parse(edge.ToNodeIds)}}}
		         """;
	}

	internal string Parse(EdgeAttributes attributes)
	{
		return null;
	}

	internal string Parse(IEnumerable<string> ids)
	{
		StringBuilder result = new();
		
		foreach (var id in ids)
		{
			result.Append($"{id} ");
		}
		
		return result.ToString();
	}
}