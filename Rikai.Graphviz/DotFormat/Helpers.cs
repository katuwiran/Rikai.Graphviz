using System.Text;

namespace Rikai.Graphviz.DotFormat;

internal static class Helpers
{
	static string _indentChar = "    ";

	internal static string FormatAttribute(string name, bool? value)
	{
		return value == null ? "" : ParseAttribute(name, $"{value}");
	}

	internal static string FormatAttribute(string name, double? value)
	{
		return value == null ? "" : ParseAttribute(name, $"{value}");
	}

	internal static string FormatAttribute(string name, string? value)
	{
		return value == null ? "" : ParseAttribute(name, value);
	}

	internal static string Indent(int indentLevel)
	{
		return new StringBuilder().Insert(0, _indentChar, indentLevel).ToString();
	}

	internal static string ParseAttribute(string name, string value)
	{
		return $"\"{name}\" = \"{value}\"\n";
	}

	internal static string FormatAttributeEnum<T>(string name, T value)
	{
		if (value == null) return string.Empty;

		string valueStr = value.ToString() ?? "";

		return valueStr == "" ? "" : ParseAttribute(name, valueStr);
	}
}