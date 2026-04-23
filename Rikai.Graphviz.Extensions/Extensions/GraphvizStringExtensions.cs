namespace Rikai.Graphviz.Extensions;

public static class GraphvizStringExtensions
{
	public static string FontColor(this string text, string hexColor)
	{
		return $"<FONT COLOR=\"{hexColor}\">{text}</FONT>";
	}

	public static string Bold(this string text)
	{
		return $"<B>{text}</B>";
	}
}
