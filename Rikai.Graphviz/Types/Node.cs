namespace Rikai.Graphviz;

public class Node
{
	public NodeAttributes Attributes { get; set; }
	public string         Id         { get; set; }
	public string?        Label      { get; set; }

	public Node(string id, NodeAttributes? attributes = null)
	{
		Id = id;
		Attributes = attributes ?? new NodeAttributes();
	}

	public Node(string id, string label, NodeAttributes? attributes = null)
	{
		Id    = id;
		Label = label;
		Attributes = attributes ?? new NodeAttributes();
	}
}