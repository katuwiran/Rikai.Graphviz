namespace Rikai.Graphviz;

public class HtmlCell
{
	public string             Id         { get; set; }
	public string?            Text       { get; set; }
	public HtmlCellAttributes Attributes { get; set; } = new();

	public HtmlCell(string id,  string? text = null)
	{
		Id = id;
		Text = text;
	}
}