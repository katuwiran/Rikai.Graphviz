namespace Rikai.Graphviz.Builders;

public class EdgeAttributeBuilder
{
	private readonly EdgeAttributes _attr;
	public EdgeAttributeBuilder() => _attr = new EdgeAttributes();
	public EdgeAttributeBuilder(EdgeAttributes attr) => _attr = attr;

	// @formatter:off
	public EdgeAttributeBuilder ArrowHead(ArrowType value)  { _attr.ArrowHead     = value; return this; }
	public EdgeAttributeBuilder ArrowTail(ArrowType value)  { _attr.ArrowTail     = value; return this; }
	public EdgeAttributeBuilder Constraint(bool value)      { _attr.Constraint    = value; return this; }
	public EdgeAttributeBuilder Style(EdgeStyle value)      { _attr.Style         = value; return this; }
	public EdgeAttributeBuilder FontName(string value)      {_attr.FontName       = value; return this; }
	public EdgeAttributeBuilder Label(string value)         { _attr.Label         = value; return this; }
	public EdgeAttributeBuilder TailLabel(string value)     { _attr.TailLabel     = value; return this; }
	public EdgeAttributeBuilder HeadLabel(string value)     { _attr.HeadLabel     = value; return this; }
	public EdgeAttributeBuilder Color(string value)         { _attr.Color         = value; return this; }
	public EdgeAttributeBuilder OutlineColor(string value)  { _attr.OutlineColor  = value; return this; }
	public EdgeAttributeBuilder LabelDistance(double value) { _attr.LabelDistance = value; return this; }
	public EdgeAttributeBuilder LabelAngle(double value)    { _attr.LabelAngle    = value; return this; }
	public EdgeAttributeBuilder FontSize(double value)      { _attr.FontSize      = value; return this; }
	public EdgeAttributeBuilder Length(double value)        { _attr.Length        = value; return this; }
	public EdgeAttributeBuilder MinLength(double value)     { _attr.MinLength     = value; return this; }
	public EdgeAttributeBuilder PenWidth(double value)      { _attr.PenWidth      = value; return this; }
	public EdgeAttributeBuilder Decorate(bool value)        { _attr.Decorate      = value; return this; }
	// @formatter:on

	public EdgeAttributes Build()
	{
		return _attr;
	}
}
