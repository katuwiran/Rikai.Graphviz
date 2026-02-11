namespace Rikai.Graphviz;

public class Edge
{
	public List<string>? FromNodeIds { get; set; }
	public List<string>? ToNodeIds   { get; set; }

	/// <summary>
	/// Determines the starting point of this Edge
	/// </summary>
	/// <param name="node"></param>
	/// <returns>Edge</returns>
	public Edge From(Node node)
	{
		FromNodeIds.Add(node.Id);
		return this;
	}

	/// <summary>
	/// Determines the starting point of this Edge
	/// </summary>
	/// <param name="node"></param>
	/// <returns>Edge</returns>
	public Edge From(IEnumerable<Node> nodes)
	{
		FromNodeIds = nodes.Select(n => n.Id).ToList();
		return this;
	}

	/// <summary>
	/// Determines the end point of this Edge
	/// </summary>
	/// <param name="node"></param>
	public void To(Node node)
	{
		FromNodeIds.Add(node.Id);
	}

	/// <summary>
	/// Determines the starting point of this Edge
	/// </summary>
	/// <param name="node"></param>
	public void To(IEnumerable<Node> nodes)
	{
		ToNodeIds = nodes.Select(n => n.Id).ToList();
	}

	public List<Edge> ToConsecutively()
	{
		return null;
	}
}