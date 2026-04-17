namespace Rikai.Graphviz.Builders;

public class HtmlTableBuilder
{
	private readonly HtmlTable _table;

	public HtmlTableBuilder(string id)
	{
		_table = new HtmlTable(id);
	}

	public HtmlTableBuilder WithAttributes(Action<HtmlTableAttributeBuilder> configure)
	{
		var builder = new HtmlTableAttributeBuilder(_table.Attributes);
		configure(builder);
		return this;
	}

	public HtmlTableBuilder WithNodeAttributes(Action<NodeAttributeBuilder> configure)
	{
		var builder = new NodeAttributeBuilder(_table.NodeAttributes);
		configure(builder);
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
