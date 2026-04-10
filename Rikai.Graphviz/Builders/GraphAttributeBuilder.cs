namespace Rikai.Graphviz.Builders;

public class GraphAttributeBuilder
{
	private readonly GraphAttributes _attr;
	public GraphAttributeBuilder(GraphAttributes attr) => _attr = attr;

	public GraphAttributeBuilder FontName(string           name)   { _attr.FontName     = name; return this; }
	public GraphAttributeBuilder FontColor(string          color)  { _attr.FontColor    = color; return this; }
	public GraphAttributeBuilder RankDir(RankDir           dir)    { _attr.RankDir      = dir; return this; }
	public GraphAttributeBuilder LayoutEngine(LayoutEngine engine) { _attr.LayoutEngine = engine; return this; }
}