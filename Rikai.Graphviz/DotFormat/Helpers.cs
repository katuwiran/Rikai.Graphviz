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
internal partial class Helpers
{



	internal string ParseNodeAttributes(NodeAttributes attributes)
	{
		if (attributes.IsEmpty)
		{
			return "";
		}

		string a = $"""
			{FormatAttribute("label", attributes.Label)}
			{FormatAttributeEnum("style", attributes.Style)}
			{FormatAttributeEnum("shape", attributes.Shape).ToLower()}
			{FormatAttribute("fontname", attributes.FontName)}
			{FormatAttribute("fontcolor", attributes.FontColor)}
			{FormatAttribute("fillcolor", attributes.FillColor)}
			{FormatAttribute("color", attributes.Color)}
			{FormatAttribute("width", attributes.Width)}
			{FormatAttribute("fontsize", attributes.FontSize)}
			]
			""";

		string b = $"""
			[ 
			{IndentLines(RemoveEmptyLines(a), 1)}
			""";
		return b;
	}
}