namespace Rikai.Graphviz;

public class EdgeAttributes
{
	public ArrowType? ArrowHead     { get; set; } = null;
	public ArrowType? ArrowTail     { get; set; } = null;
	public EdgeStyle? Style         { get; set; } = null;
	public string?    FontName      { get; set; } = null;
	public string?    Label         { get; set; } = null;
	public string?    TailLabel     { get; set; } = null;
	public string?    HeadLabel     { get; set; } = null;
	public string?    FillColor     { get; set; } = null;
	public string?    FontColor     { get; set; } = null;
	public string?    OutlineColor  { get; set; } = null;
	public double?    LabelDistance { get; set; } = null;
	public double?    LabelAngle    { get; set; } = null;
	public double?    FontSize      { get; set; } = null;
	public double?    Length        { get; set; } = null;
	public double?    MinLength     { get; set; } = null;
	public double?    PenWidth      { get; set; } = null;
	public bool?      Decorate      { get; set; } = null;

	public bool IsEmpty => this is
	{
		ArrowHead    : null,
		ArrowTail    : null,
		Style        : null,
		FontName     : null,
		Label        : null,
		TailLabel    : null,
		HeadLabel    : null,
		FillColor    : null,
		FontColor    : null,
		OutlineColor : null,
		LabelDistance: null,
		LabelAngle   : null,
		FontSize     : null,
		Length       : null,
		MinLength    : null,
		PenWidth     : null,
		Decorate     : null,
	};
}