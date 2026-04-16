namespace Rikai.Graphviz.Builders;

public class GraphAttributeBuilder
{
	private readonly GraphAttributes _attr;
	public GraphAttributeBuilder(GraphAttributes attr) => _attr = attr;

	public GraphAttributeBuilder Label(string value)
	{
		_attr.Label = value;
		return this;
	}

	public GraphAttributeBuilder FontColor(string value)
	{
		_attr.FontColor = value;
		return this;
	}

	public GraphAttributeBuilder FontName(string value)
	{
		_attr.FontName = value;
		return this;
	}

	public GraphAttributeBuilder BgColor(string value)
	{
		_attr.BackgroundColor = value;
		return this;
	}

	public GraphAttributeBuilder RankDir(RankDir value)
	{
		_attr.RankDir = value;
		return this;
	}

	public GraphAttributeBuilder LayoutEngine(LayoutEngine value)
	{
		_attr.LayoutEngine = value;
		return this;
	}

	public GraphAttributeBuilder LabelLocation(LabelLocation value)
	{
		_attr.LabelLocation = value;
		return this;
	}

	public GraphAttributeBuilder Splines(Splines value)
	{
		_attr.Splines = value;
		return this;
	}

	public GraphAttributeBuilder Overlap(Overlap value)
	{
		_attr.Overlap = value;
		return this;
	}
}
