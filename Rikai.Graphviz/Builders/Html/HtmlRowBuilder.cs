namespace Rikai.Graphviz.Builders;

public class HtmlRowBuilder
{
	private readonly Row _row = new();

	public HtmlRowBuilder AddCell(HtmlCell cell)
	{
		_row.Cells.Add(cell);
		return this;
	}

	public HtmlRowBuilder AddCell(Action<HtmlCellBuilder> cellBuilder)
	{
		_row.Cells.Add(cell);
		return this;
	}

	public Row Build()
	{
		return _row;
	}
}