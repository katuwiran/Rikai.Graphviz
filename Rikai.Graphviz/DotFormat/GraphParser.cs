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
		if (type == GraphType.Undirected)
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
		                  {{ParseAttributeEnum("labellocation", attributes.LabelLocation)}}
		                  {{ParseAttribute("fontname", attributes.FontName)}}
		                  {{ParseAttribute("fontcolor", attributes.FontColor)}}
		                  {{ParseAttribute("bgcolor", attributes.BackgroundColor)}}
		                  {{ParseAttributeEnum("splines", attributes.Splines)}}
		                  {{ParseAttributeEnum("rankdir", attributes.RankDir)}}
		                  {{ParseAttributeEnum("overlap", attributes.Overlap)}}
		                  {{(ParseAttributeEnum("layout", attributes.LayoutEngine)).ToLower()}}
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
		                  {{ParseAttributeEnum("shape", attributes.Shape).ToLower()}}
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
		                  {{ParseAttributeEnum("arrowhead", attributes.ArrowHead).ToLower()}}
		                  {{ParseAttributeEnum("arrowtail", attributes.ArrowTail).ToLower()}}
		                  ]
		                  """;
		return IndentLines(RemoveEmptyLines(result), 1);
	}

	internal string ParseGraphNodes(GraphNodes nodes)
	{
		// todo include an OR statement, where nodes not in edge definitions are included either way
		// var nodeWithAttributes = nodes.Nodes.Where(n => !n.Attributes.IsEmpty);
		var nodeWithAttributes = nodes.Nodes;

		StringBuilder result = new();
		foreach (var node in nodeWithAttributes.ToList())
		{
			result.AppendLine($"{Indent(1)}{ParseNode(node)}");
		}

		return result.ToString();
	}

	internal string ParseNode(Node node)
	{
		return $"""
		        "{node.Id}" {ParseNodeAttributes(node.Attributes)}
		        """;
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
		         { {{ParseIds(edge.FromNodeIds)}}} {{_edgeSymbol}} { {{ParseIds(edge.ToNodeIds)}}} {{ParseEdgeAttributes(edge.Attributes)}}
		         """;
	}

	internal string ParseEdgeAttributes(EdgeAttributes attributes)
	{
		if (attributes.IsEmpty)
		{
			return "";
		}

		string a = $"""
		            {ParseAttribute("label", attributes.Label)}
		            {ParseAttribute("fontname", attributes.FontName)}
		            {ParseAttribute("fontcolor", attributes.FontColor)}
		            {ParseAttribute("color", attributes.Color)}
		            {ParseAttributeEnum("arrowhead", attributes.ArrowHead).ToLower()}
		            {ParseAttributeEnum("arrowtail", attributes.ArrowTail).ToLower()}
		            ]
		            """;

		string b = $"""
		            [ 
		            {IndentLines(RemoveEmptyLines(a), 1)}
		            """;
		return b;
	}

	internal string ParseNodeAttributes(NodeAttributes attributes)
	{
		if (attributes.IsEmpty)
		{
			return "";
		}

		string a = $"""
		            {ParseAttribute("label", attributes.Label)}
		            {ParseAttributeEnum("style", attributes.Style)}
		            {ParseAttributeEnum("shape", attributes.Shape).ToLower()}
		            {ParseAttribute("fontname", attributes.FontName)}
		            {ParseAttribute("fontcolor", attributes.FontColor)}
		            {ParseAttribute("fillcolor", attributes.FillColor)}
		            {ParseAttribute("color", attributes.Color)}
		            {ParseAttribute("width", attributes.Width)}
		            {ParseAttribute("fontsize", attributes.FontSize)}
		            ]
		            """;

		string b = $"""
		            [ 
		            {IndentLines(RemoveEmptyLines(a), 1)}
		            """;
		return b;
	}
}