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

	public bool IsEmpty => this is
	{
		Label          : null,
		FontColor      : null,
		FontName       : null,
		BackgroundColor: null,
		Splines        : null,
		RankDir        : null,
		LayoutEngine   : null,
	};
}