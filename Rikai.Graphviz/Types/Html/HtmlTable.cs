namespace Rikai.Graphviz;

public class HtmlTable
{
	public string              Id         { get; set; }
	public HtmlTableAttributes Attributes { get; set; } = new();
	public List<Row>           Rows       { get; set; } = new();

	public HtmlTable(string id)
	{
		Id = id;
	}
}