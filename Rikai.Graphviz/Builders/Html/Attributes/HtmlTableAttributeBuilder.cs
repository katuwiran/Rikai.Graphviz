namespace Rikai.Graphviz.Builders;

public class HtmlTableAttributeBuilder
{
	private readonly HtmlTableAttributes _attr;

	public HtmlTableAttributeBuilder() => _attr = new();
	public HtmlTableAttributeBuilder(HtmlTableAttributes attr) => _attr = attr;

	// @formatter:off
    public HtmlTableAttributeBuilder Align(HtmlAlign value) { _attr.Align       = value; return this; }
    public HtmlTableAttributeBuilder BgColor(string value)  { _attr.BgColor     = value; return this; }
    public HtmlTableAttributeBuilder Border(int value)      { _attr.Border      = value; return this; }
    public HtmlTableAttributeBuilder CellBorder(int value)  { _attr.CellBorder  = value; return this; }
    public HtmlTableAttributeBuilder CellPadding(int value) { _attr.CellPadding = value; return this; }
    public HtmlTableAttributeBuilder CellSpacing(int value) { _attr.CellSpacing = value; return this; }
    public HtmlTableAttributeBuilder Color(string value)    { _attr.Color       = value; return this; }
    public HtmlTableAttributeBuilder Port(string value)     { _attr.Port        = value; return this; }
	public HtmlTableAttributeBuilder Style(HtmlStyle value) { _attr.Style       = value; return this; }
	// @formatter:on

	public HtmlTableAttributes Build()
	{
		return _attr;
	}
}
