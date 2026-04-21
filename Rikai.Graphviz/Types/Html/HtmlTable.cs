namespace Rikai.Graphviz;

public class HtmlTable
{
	public string              Id             { get; set; }
	public HtmlTableAttributes Attributes     { get; set; } = new();
	public NodeAttributes      NodeAttributes { get; set; } = new();
	public List<HtmlRow>       Rows           { get; set; } = new();

	public HtmlTable(string id)
	{
		Id = id;
	}

	public HtmlTable(string id, bool isPlain)
	{
		Id = id;

		if (isPlain)
		{
			NodeAttributes.Shape = Shape.Plain;
		}
	}

	public HtmlTable(string id, NodeAttributes nodeAttributes, bool isPlain)
	{
		Id             = id;
		NodeAttributes = nodeAttributes;

		if (isPlain)
		{
			NodeAttributes.Shape = Shape.Plain;
		}
	}

	public HtmlTable(string id, HtmlTableAttributes? attributes = null, NodeAttributes? nodeAttributes = null, bool isPlain = true)
	{
		Id = id;
		if (attributes is not null)
		{
			Attributes = attributes;
		}
		else
		{
			Attributes = new HtmlTableAttributes();
		}

		if (nodeAttributes is not null)
		{
			NodeAttributes = nodeAttributes;
		}
		else
		{
			NodeAttributes = new NodeAttributes();
		}

		if (isPlain)
		{
			NodeAttributes.Shape = Shape.Plain;
		}
	}
}
