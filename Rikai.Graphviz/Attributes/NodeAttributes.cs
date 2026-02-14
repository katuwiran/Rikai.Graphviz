namespace Rikai.Graphviz;

public record NodeAttributes
{
	public Shape?     Shape = null;
	public NodeStyle? Style = null;

	public string? FontName     = null;
	public string? FontColor    = null;
	public string? FillColor    = null;
	public string? Color        = null;
	public string? Label        = null;

	public double? Width    = null;
	public double? FontSize = null;

	public bool IsEmpty => this is
	{
		Shape       : null,
		Style       : null,
		FontName    : null,
		FontColor   : null,
		FillColor   : null,
		Color       : null,
		Width       : null,
		FontSize    : null,
	};
}