namespace Rikai.Graphviz.Builders;

public class HtmlTableBuilder
{
	private readonly HtmlTable _table;
	private readonly bool      _isPlain;

	public HtmlTableBuilder(string id, bool isPlain = true)
	{
		_table   = new HtmlTable(id, isPlain);
		_isPlain = isPlain;
	}

	public HtmlTableBuilder WithAttributes(Action<HtmlTableAttributeBuilder> configure)
	{
		var builder = new HtmlTableAttributeBuilder(_table.Attributes);
		configure(builder);

		_table.Attributes = builder.Build();

		return this;
	}

	public HtmlTableBuilder WithNodeAttributes(Action<NodeAttributeBuilder> configure)
	{
		var builder = new NodeAttributeBuilder(_table.NodeAttributes);
		configure(builder);

		_table.NodeAttributes = builder.Build();

		if (_isPlain)
		{
			_table.NodeAttributes.Shape = Shape.Plain;
		}
		
		return this;
	}

	public HtmlTableBuilder AddRow(Action<HtmlRowBuilder> configure)
	{
		var builder = new HtmlRowBuilder();
		configure(builder);
		_table.Rows.Add(builder.Build());
		return this;
	}

	public HtmlTableBuilder AddRow(HtmlRow row)
	{
		_table.Rows.Add(row);

		return this;
	}

	// Returns the finalized, strictly typed object
	public HtmlTable Build()
	{
		return _table;
	}
}
