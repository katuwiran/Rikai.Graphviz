using System.Text;

namespace Rikai.Graphviz.DotFormat;

internal static class Helpers
{
	private static string _indentChar = "    ";

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

	internal static void CheckEdgeIdForPorts(string id, out string result)
	{
		var  parts   = new List<string>();
		var  current = new StringBuilder();
		bool escape  = false;

		foreach (char c in id)
		{
			if (escape)
			{
				// Add character literally after escape
				current.Append(c);
				escape = false;
			}
			else if (c == '\\')
			{
				escape = true;
			}
			else if (c == ':')
			{
				// Split only on unescaped colon
				parts.Add(current.ToString());
				current.Clear();
			}
			else
			{
				current.Append(c);
			}
		}

		// Add last segment
		parts.Add(current.ToString());

		// Wrap each part in quotes
		for (int i = 0; i < parts.Count; i++)
		{
			parts[i] = $"\"{parts[i]}\"";
		}

		// Join with colon
		result = string.Join(":", parts);
	}
}
