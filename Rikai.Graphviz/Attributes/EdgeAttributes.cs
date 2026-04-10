namespace Rikai.Graphviz;

public record EdgeAttributes
{
	public ArrowType? ArrowHead     { get; set; }
	public ArrowType? ArrowTail     { get; set; }
	public EdgeStyle? Style         { get; set; }
	public string?    FontName      { get; set; }
	public string?    Label         { get; set; }
	public string?    TailLabel     { get; set; }
	public string?    HeadLabel     { get; set; }
	public string?    Color         { get; set; }
	public string?    FontColor     { get; set; }
	public string?    OutlineColor  { get; set; }
	public double?    LabelDistance { get; set; }
	public double?    LabelAngle    { get; set; }
	public double?    FontSize      { get; set; }
	public double?    Length        { get; set; }
	public double?    MinLength     { get; set; }
	public double?    PenWidth      { get; set; }
	public bool?      Decorate      { get; set; }

	public bool IsEmpty => this is
	{
		ArrowHead    : null,
		ArrowTail    : null,
		Style        : null,
		FontName     : null,
		Label        : null,
		TailLabel    : null,
		HeadLabel    : null,
		Color        : null,
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