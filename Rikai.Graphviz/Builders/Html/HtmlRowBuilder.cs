namespace Rikai.Graphviz.Builders;

public class HtmlRowBuilder
{
	private readonly HtmlRow _row = new();

	public HtmlRowBuilder AddCell(HtmlCell cell)
	{
		_row.Cells.Add(cell);
		return this;
	}

	public HtmlRowBuilder AddCell(string id, Action<HtmlCellBuilder> configure)
	{
		var builder = new HtmlCellBuilder(id, null);
		configure(builder);
		_row.Cells.Add(builder.Build());
		return this;
	}

	public HtmlRowBuilder AddCell(string id, string text, Action<HtmlCellBuilder> configure)
	{
		var builder = new HtmlCellBuilder(id, text);
		configure(builder);
		_row.Cells.Add(builder.Build());
		return this;
	}

	public HtmlRow Build()
	{
		return _row;
	}
}
