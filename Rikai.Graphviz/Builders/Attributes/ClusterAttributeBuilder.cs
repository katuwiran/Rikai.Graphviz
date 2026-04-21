namespace Rikai.Graphviz.Builders;

public class ClusterAttributeBuilder
{
	private readonly ClusterAttributes _attr;
	public ClusterAttributeBuilder() => _attr = new ClusterAttributes();
	public ClusterAttributeBuilder(ClusterAttributes attr) => _attr = attr;

	// @formatter:off
	public ClusterAttributeBuilder IsCluster(bool value)         { _attr.IsCluster       = value; return this; }
	public ClusterAttributeBuilder Label(string   value)         { _attr.Label           = value; return this; }
	public ClusterAttributeBuilder LabelLoc(LabelLocation value) { _attr.LabelLoc        = value; return this; }
	public ClusterAttributeBuilder FontColor(string value)       { _attr.FontColor       = value; return this; }
	public ClusterAttributeBuilder FontName(string value)        { _attr.FontName        = value; return this; }
	public ClusterAttributeBuilder Color(string value)           { _attr.Color           = value; return this; }
	public ClusterAttributeBuilder FillColor(string value)       { _attr.FillColor       = value; return this; }
	public ClusterAttributeBuilder BgColor(string value)         { _attr.BackgroundColor = value; return this; }
	public ClusterAttributeBuilder PenColor(string value)        { _attr.PenColor        = value; return this; }
	public ClusterAttributeBuilder PenWidth(double value)        { _attr.PenWidth        = value; return this; }
	// @formatter:on

	public ClusterAttributes Build() => _attr;
}
