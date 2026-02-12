namespace Rikai.Graphviz;

public class GraphAttributes
{
	public string? Label           { get; set; }
	public string? FontColor       { get; set; }
	public string? FontName        { get; set; }
	public string? BackgroundColor { get; set; }

	public Splines? Splines { get; set; }
	public RankDir? RankDir { get; set; }

	public LayoutEngine? LayoutEngine { get; set; }
}