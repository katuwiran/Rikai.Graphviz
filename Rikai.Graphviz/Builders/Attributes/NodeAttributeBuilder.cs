namespace Rikai.Graphviz.Builders;

public class NodeAttributeBuilder
{
	private readonly NodeAttributes _attr;

	public NodeAttributeBuilder()
	{
		_attr = new NodeAttributes();
	}

	public NodeAttributeBuilder(NodeAttributes attr) => _attr = attr;

	public NodeAttributeBuilder Shape(Shape value)
	{
		_attr.Shape = value;
		return this;
	}

	public NodeAttributeBuilder Style(NodeStyle value)
	{
		_attr.Style = value;
		return this;
	}

	public NodeAttributeBuilder FontName(string value)
	{
		_attr.FontName = value;
		return this;
	}

	public NodeAttributeBuilder FontColor(string value)
	{
		_attr.FontColor = value;
		return this;
	}

	public NodeAttributeBuilder FillColor(string value)
	{
		_attr.FillColor = value;
		return this;
	}

	public NodeAttributeBuilder Color(string value)
	{
		_attr.Color = value;
		return this;
	}

	public NodeAttributeBuilder Label(string value)
	{
		_attr.Label = value;
		return this;
	}

	public NodeAttributeBuilder Width(double value)
	{
		_attr.Width = value;
		return this;
	}

	public NodeAttributeBuilder FontSize(double value)
	{
		_attr.FontSize = value;
		return this;
	}

	public NodeAttributes Build()
	{
		return _attr;
	}
}
