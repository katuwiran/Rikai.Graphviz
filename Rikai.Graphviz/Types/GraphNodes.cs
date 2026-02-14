namespace Rikai.Graphviz;

public class GraphNodes
{
	public NodeAttributes Attributes { get; set; } = new();

	internal List<Node>   Nodes   { get; set; } = new();
	internal List<string> NodeIds { get; set; } = new();
	
	public GraphNodes Add(Node node)
	{
		AddNodeToCollectionIfNotExists(node);
		return this;
	}

	public void Add(IEnumerable<Node> nodes)
	{
		foreach (var node in nodes)
		{
			AddNodeToCollectionIfNotExists(node);
		}
	}

	public void Add(string id)
	{
		var node = new Node(id);
		AddNodeToCollectionIfNotExists(node);
	}

	public void Add(IEnumerable<string> ids)
	{
		foreach (var label in ids)
		{
			var node = new Node(label);
			AddNodeToCollectionIfNotExists(node);
		}
	}
	
	internal void AddNodesToCollectionIfNotExists(params Node[] nodes)
	{
		foreach (var node in nodes)
		{
			var id = node.Id;
			if (!NodeIds.Contains(id))
			{
				Nodes.Add(node);
				NodeIds.Add(node.Id);
			}
		}
	}

	internal void AddNodeToCollectionIfNotExists(Node node)
	{
		if (!Nodes.Contains(node))
		{
			Nodes.Add(node);
			NodeIds.Add(node.Id);
		}
	}

	internal void AddNodesToCollectionIfNotExists(IEnumerable<Node> nodes)
	{
		foreach (var node in nodes)
		{
			if (!Nodes.Contains(node))
			{
				Nodes.Add(node);
				NodeIds.Add(node.Id);
			}
		}
	}
}