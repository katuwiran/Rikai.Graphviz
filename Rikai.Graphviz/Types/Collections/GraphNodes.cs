namespace Rikai.Graphviz;

/// <summary>
/// This class represents the nodes included in graph. Unique ids are expected for all nodes included. Repeated ids are ignored by default.
/// </summary>
public class GraphNodes
{
	/// <summary>
	/// This represents the default attributes for all graph nodes.
	/// </summary>
	public NodeAttributes Attributes { get; set; } = new();

	/// <summary>
	/// This contains all the nodes in a graph that is defined with attributes and logic, e.g. not just by its id or labels.
	/// </summary>
	internal List<Node> Collection { get; set; } = new();

	/// <summary>
	/// This contains the ids of all nodes in a graph, regardless whether they are defined with attributes or not.  
	/// </summary>
	internal List<string> NodeIds { get; set; } = new();

	/// <summary>
	/// Adds a `Node` class to the collection.
	/// </summary>
	/// <param name="node"></param>
	/// <returns></returns>
	public GraphNodes Add(Node node)
	{
		AddNodeToCollectionIfNotExists(node);
		return this;
	}

	/// <summary>
	/// Adds a collection of `Node`s to the graph nodes.
	/// </summary>
	/// <param name="node"></param>
	/// <returns></returns>
	public void AddRange(IEnumerable<Node> nodes)
	{
		foreach (var node in nodes)
		{
			AddNodeToCollectionIfNotExists(node);
		}
	}

	/// <summary>
	/// Adds a via `string` Id a Node to the graph nodes.
	/// </summary>
	/// <param name="node"></param>
	/// <returns></returns>
	public void AddId(string id)
	{
		var node = new Node(id);
		AddNodeToCollectionIfNotExists(node);
	}

	/// <summary>
	/// Adds a via `string` Ids a collection of Nodes to the graph nodes.
	/// </summary>
	/// <param name="node"></param>
	/// <returns></returns>
	public void AddIdRange(IEnumerable<string> ids)
	{
		foreach (var label in ids)
		{
			var node = new Node(label);
			AddNodeToCollectionIfNotExists(node);
		}
	}

	/// <summary>
	/// Helper fucntion that add a collection of `Node` if and only if they are not yet in the collection.
	/// </summary>
	/// <param name="nodes"></param>
	internal void AddNodesToCollectionIfNotExists(params Node[] nodes)
	{
		foreach (var node in nodes)
		{
			var id = node.Id;
			if (!NodeIds.Contains(id))
			{
				Collection.Add(node);
				NodeIds.Add(node.Id);
			}
		}
	}

	/// <summary>
	/// Helper fucntion that add a collection of `Node` if and only if they are not yet in the collection.
	/// </summary>
	/// <param name="nodes"></param>
	internal void AddNodesToCollectionIfNotExists(IEnumerable<Node> nodes)
	{
		foreach (var node in nodes)
		{
			if (!Collection.Contains(node))
			{
				Collection.Add(node);
				NodeIds.Add(node.Id);
			}
		}
	}

	/// <summary>
	/// Helper fucntion that adds a `Node` if and only if it is not yet in the collection.
	/// </summary>
	/// <param name="nodes"></param>
	internal void AddNodeToCollectionIfNotExists(Node node)
	{
		if (!Collection.Contains(node))
		{
			Collection.Add(node);
			NodeIds.Add(node.Id);
		}
	}
}