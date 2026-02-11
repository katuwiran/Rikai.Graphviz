namespace Rikai.Graphviz;


public class Node
{
	// private _edge
	public string? Id { get; set; }
	public string? Label { get; set; }

	public Node(string label)
	{
		Label = label;
	}
	
	public Node(string id, string label)
	{
		Id = id;
		Label = label;
	}
}	