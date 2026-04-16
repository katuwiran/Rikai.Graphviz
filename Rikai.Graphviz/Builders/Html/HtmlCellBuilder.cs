namespace Rikai.Graphviz.Builders;

public class HtmlCellBuilder
{
	private readonly HtmlCell _cell;

	public HtmlCellBuilder(string id, string? text)
	{
		_cell = new HtmlCell(id, text);
	}

	public HtmlCellBuilder WithAttributes(HtmlCellAttributes attributes)
	{
		_cell.Attributes = attributes;
		return this;
	}

	public HtmlCellBuilder WithAttributes(Action<HtmlCellAttributeBuilder> configure)
	{
		var builder = new HtmlCellAttributeBuilder(_cell.Attributes);
		configure(builder);

		_cell.Attributes = builder.Build();
		return this;
	}

	public HtmlCell Build()
	{
		return _cell;
	}
}
