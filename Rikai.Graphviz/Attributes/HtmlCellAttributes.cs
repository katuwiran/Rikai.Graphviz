namespace Rikai.Graphviz;

public record HtmlCellAttributes
{
	public HtmlAlign? Align       { get; set; }
	public string?    BgColor     { get; set; }
	public int?       Border      { get; set; }
	public int?       CellBorder  { get; set; }
	public int?       CellPadding { get; set; }
	public int?       CellSpacing { get; set; }
	public string?    Color       { get; set; }
	public int?       ColSpan     { get; set; }
	public double?    Height      { get; set; }
	public int?       RowSpan     { get; set; }
	public HtmlStyle? Style       { get; set; }
	public double?    Width       { get; set; }

	public bool IsEmpty => this == new HtmlCellAttributes();
}
