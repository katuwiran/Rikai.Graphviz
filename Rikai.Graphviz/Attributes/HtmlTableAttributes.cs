using System.Web;

namespace Rikai.Graphviz;

public record HtmlTableAttributes
{
	public HtmlAlign? Align       { get; set; }
	public string?    BgColor     { get; set; }
	public int?       Border      { get; set; }
	public int?       CellBorder  { get; set; }
	public int?       CellPadding { get; set; }
	public int?       CellSpacing { get; set; }
	public string?    Color       { get; set; }
	public string?    Port        { get; set; }
	public HtmlStyle? Style       { get; set; }

	public bool IsEmpty => this == new HtmlTableAttributes();
}
