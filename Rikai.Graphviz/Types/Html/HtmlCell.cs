namespace Rikai.Graphviz;

public class HtmlCell
{
	public string             Port       { get; set; }
	public string?            Text       { get; set; }
	public HtmlCellAttributes Attributes { get; set; } = new();

	public HtmlCell(string port, string? text = null)
	{
		Port = port;
		Text = text;
	}

	public HtmlCell(string port, string text,  HtmlCellAttributes attributes)
	{
		Port = port;
		Text = text;
		Attributes = attributes;
	}
}
