using System.Text;

namespace Rikai.Graphviz.DotFormat;

internal static class Helpers
{
	static string _indentChar = "    ";

	internal static string FormatAttribute<T>(string name, T? value)
	{
		return value == null ? "" : ParseAttribute(name, $"{value}");
	}

	internal static string Indent(int indentLevel)
	{
		return new StringBuilder().Insert(0, _indentChar, indentLevel).ToString();
	}

	internal static string ParseAttribute(string name, string value)
	{
		return $"\"{name}\" = \"{value}\"";
	}
	
	// html attributes
	internal static string FormatHtmlAttribute<T>(string name, T? value)
	{
		return value == null ? "" : ParseHtmlAttribute(name, $"{value}");
	}

	internal static string ParseHtmlAttribute(string name, string value)
	{
		return $" {name}=\"{value}\" ";
	}
}
