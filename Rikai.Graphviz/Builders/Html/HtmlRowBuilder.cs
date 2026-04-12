namespace Rikai.Graphviz.Builders;

public class HtmlRowBuilder
{
	private readonly HtmlRow _row = new();

	public HtmlRowBuilder AddCell(HtmlCell cell)
	{
		_row.Cells.Add(cell);
		return this;
	}

	public HtmlRowBuilder AddCell(string id, Action<HtmlCellBuilder> cellBuilder)
	{
		var builder = new HtmlCellBuilder(id);
		_row.Cells.Add(builder.Build());
		return this;
	}

	public Row Build()
	{
		return _row;
	}
}