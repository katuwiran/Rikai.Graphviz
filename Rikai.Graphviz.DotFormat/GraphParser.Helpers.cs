using System.Text;

namespace Rikai.Graphviz.DotFormat;

internal partial class GraphParser
{
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
}