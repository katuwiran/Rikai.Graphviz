namespace Rikai.Graphviz;

public record ClusterAttributes
{
	public bool?   IsCluster { get; set; }
	public string? Label     { get; set; }

	public LabelLocation? LabelLoc { get; set; }

	// labeljust
	// layer
	// margin

	public string? FontColor       { get; set; }
	public string? FontName        { get; set; }
	public string? Color           { get; set; }
	public string? FillColor       { get; set; }
	public string? BackgroundColor { get; set; }
	public string? PenColor        { get; set; }

	public double? PenWidth { get; set; }

	public bool IsEmpty => this is
	{
		IsCluster      : null,
		Label          : null,
		LabelLoc       : null,
		FontColor      : null,
		FontName       : null,
		Color          : null,
		FillColor      : null,
		BackgroundColor: null,
		PenColor       : null
	};
}