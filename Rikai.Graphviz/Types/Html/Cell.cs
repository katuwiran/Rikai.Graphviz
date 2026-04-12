namespace Rikai.Graphviz;

public class Cell
{
	public string? Label   { get; set; }
	public string? Port    { get; set; }
	public HtmlAlign? Align   { get; set; }
	public string? BgColor { get; set; }
	public int?    ColSpan { get; set; }
}