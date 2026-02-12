namespace Rikai.Graphviz;

internal partial class GraphParser
{
	internal static string ParseEnumAttribute(string name, Shape? value)
	{
		return value == null ? "" : FormatAttribute(name, value.ToString().ToLower());
	}

	internal static string ParseEnumAttribute(string name, ArrowType? value)
	{
		return value == null ? "" : FormatAttribute(name, value.ToString().ToLower());
	}
	
	internal static string ParseEnumAttribute(string name, Splines? value)
	{
		return value == null ? "" : FormatAttribute(name, value.ToString().ToLower());
	}

	internal static string ParseEnumAttribute(string name, LayoutEngine? value)
	{
		return value == null ? "" : FormatAttribute(name, value.ToString().ToLower());
	}
	
	internal static string ParseEnumAttribute(string name, Overlap? value)
	{
		return value == null ? "" : FormatAttribute(name, value.ToString().ToLower());
	}
		
	internal static string ParseEnumAttribute(string name, RankDir? value)
	{
		return value == null ? "" : FormatAttribute(name, value.ToString().ToLower());
	}
}