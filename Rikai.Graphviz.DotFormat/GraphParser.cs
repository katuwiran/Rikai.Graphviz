using System.Text;

namespace Rikai.Graphviz.DotFormat;

// parts of this parser, in order of appearance
// graph type
// graph attributes
// node attributes
// edge attributes
// nodes (all nodes with additional attributes except label)
// edges
// node
// edge
public partial class GraphParser
{
	private string _edgeSymbol  = "->"; // todo: make this a setting
	private string _indentChar  = "\t";
	private int    _indentLevel = 0;

	public string Parse(GraphType type)
	{
		if (type == GraphType.Directed)
		{
			return "graph";
		}
		else return "digraph";
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