using System.Text;

namespace Rikai.Graphviz;

internal partial class GraphParser
{
	internal string ParseIds(IEnumerable<string> ids)
	{
		StringBuilder result = new();

		foreach (var id in ids)
		{
			result.Append($"\"{id}\" ");
		}

		return result.ToString();
	}

	internal static string ParseAttribute(string name, string? value)
	{
		return value == null ? "" : FormatAttribute(name, value);
	}
	
	internal static string Indent(int indentLevel)
	{
		return new StringBuilder().Insert(0, _indentChar, indentLevel).ToString();
	}

	internal string IndentLines(string input, int level)
	{
		// 1. Split by '\n'
		// 2. Append "lol " to each line using LINQ's Select()
		// 3. Join them back together with '\n'
		return string.Join('\n', input.Split('\n').Select(line => Indent(level) + line));
	}

	internal static string FormatAttribute(string name, string value)
	{
		return $"{Indent(1)}\"{name}\" = \"{value}\"";
	}

	internal string RemoveTrailingLine(StringBuilder sb)
	{
		return string.Join(Environment.NewLine,
		                   sb.ToString().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
	}

	internal List<Node> NodesWithAttributes(IEnumerable<Node> nodes)
	{
		nodes.Where(n => n.Attributes != null);
		return nodes.ToList();
	}
}