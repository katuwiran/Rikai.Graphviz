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

	public HtmlTableBuilder AddRow(Action<HtmlRowBuilder> configure)
	{
		var builder = new HtmlRowBuilder();
		configure(builder);
		return this;
	}

	public HtmlTableBuilder AddRow(Row row)
	{
		_table.Rows.Add(row);
		
		return this;
	}

	// A helper method specifically for standard 2-column header rows
	public HtmlTableBuilder AddHeaderRow(string title, string bgColor = "#E8EDF2")
	{
		var row = new Row();
		row.Cells.Add(new HtmlCell
		{
			Label   = title,
			ColSpan = 2,
			BgColor = bgColor,
			Align   = HtmlAlign.Left
		});

		_table.Rows.Add(row);
		return this;
	}

	// A helper method for a standard data row (left port, right type)
	public HtmlTableBuilder AddDataRow(string port, string columnName, string dataType)
	{
		var row = new Row();

		// Left Cell (Column Name)
		row.Cells.Add(new HtmlCell { Label = columnName, Port = port, Align = HtmlAlign.Left });

		// Right Cell (Data Type)
		row.Cells.Add(new HtmlCell { Label = dataType, Align = HtmlAlign.Right });

		_table.Rows.Add(row);
		return this;
	}

	// Returns the finalized, strictly typed object
	public HtmlTable Build()
	{
		return _table;
	}
}