namespace Rikai.Graphviz;

public class HtmlCell
{
	public string             Id         { get; set; }
	public HtmlCellAttributes Attributes { get; set; } = new();

	public HtmlCell(string id)
	{
		Id = id;
	}
}