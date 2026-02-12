namespace Rikai.Graphviz;

public class Node
{
	public NodeAttributes Attributes { get; set; } = new();
	public string         Id         { get; set; }
	public string?        Label      { get; set; }

	public Node(string id)
	{
		Id = id;
	}

	public Node(string id, string label)
	{
		Id    = id;
		Label = label;
	}
}