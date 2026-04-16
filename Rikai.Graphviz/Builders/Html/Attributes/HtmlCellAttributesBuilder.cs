namespace Rikai.Graphviz.Builders;

public class HtmlCellAttributeBuilder
{
	private readonly HtmlCellAttributes _attr;

	public HtmlCellAttributeBuilder(HtmlCellAttributes attr) => _attr = attr;

	// @formatter:off
	public HtmlCellAttributeBuilder Align(HtmlAlign value) { _attr.Align       = value; return this; }
	public HtmlCellAttributeBuilder BgColor(string  value) { _attr.BgColor     = value; return this; }
	public HtmlCellAttributeBuilder Border(int      value) { _attr.Border      = value; return this; }
	public HtmlCellAttributeBuilder CellBorder(int  value) { _attr.CellBorder  = value; return this; }
	public HtmlCellAttributeBuilder CellPadding(int value) { _attr.CellPadding = value; return this; }
	public HtmlCellAttributeBuilder CellSpacing(int value) { _attr.CellSpacing = value; return this; }
	public HtmlCellAttributeBuilder Color(string    value) { _attr.Color       = value; return this; }
	public HtmlCellAttributeBuilder ColSpan(int     value) { _attr.ColSpan     = value; return this; }
	public HtmlCellAttributeBuilder Height(double   value) { _attr.Height      = value; return this; }
	public HtmlCellAttributeBuilder Port(PortPos    value) { _attr.Port        = value; return this; }
	public HtmlCellAttributeBuilder RowSpan(int     value) { _attr.RowSpan     = value; return this; }
	public HtmlCellAttributeBuilder Style(HtmlStyle value) { _attr.Style       = value; return this; }
	public HtmlCellAttributeBuilder Width(double    value) { _attr.Width       = value; return this; }
	// @formatter:on 

	public HtmlCellAttributes Build() => _attr;
}
