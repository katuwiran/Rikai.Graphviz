namespace Rikai.Graphviz;

public class Edge
{
	public List<string?> FromNodeIds { get; set; } = new();
	public List<string?> ToNodeIds   { get; set; } = new();

	/// <summary>
	/// Determines the starting point of this Edge. Uses predefined nodes for Ids.
	/// </summary>
	/// <param name="node"></param>
	/// <returns>Edge</returns>
	public Edge From(Node node)
	{
		FromNodeIds.Add(node.Id);
		return this;
	}

	/// <summary>
	/// Determines the starting point of this Edge. Uses predefined nodes for Ids.
	/// </summary>
	/// <param name="nodes"></param>
	/// <returns>Edge</returns>
	public Edge From(IEnumerable<Node> nodes)
	{
		FromNodeIds.AddRange(nodes.Select(n => n.Id).ToList());
		return this;
	}

	/// <summary>
	/// Determines the end point of this Edge. Uses predefined nodes for Ids.
	/// </summary>
	/// <param name="node"></param>
	public void To(Node node)
	{
		FromNodeIds.Add(node.Id);
	}

	/// <summary>
	/// Determines the starting point of this Edge. Uses predefined nodes for Ids.
	/// </summary>
	/// <param name="nodes"></param>
	public void To(IEnumerable<Node> nodes)
	{
		ToNodeIds.AddRange(nodes.Select(n => n.Id).ToList());
	}

	/// <summary>
	/// Determines the starting point of this Edge. Uses labels only for reference.
	/// </summary>
	/// <param name="label"></param>
	/// <returns>Edge</returns>
	public Edge From(String label)
	{
		FromNodeIds.Add(label);
		return this;
	}

	/// <summary>
	/// Determines the starting point of this Edge. Uses labels only for reference.
	/// </summary>
	/// <param name="labels"></param>
	/// <returns>Edge</returns>
	public Edge From(IEnumerable<String> labels)
	{
		FromNodeIds.AddRange(labels);
		return this;
	}

	/// <summary>
	/// Determines the end point of this Edge. Uses labels only for reference.
	/// </summary>
	/// <param name="label"></param>
	public void To(String label)
	{
		ToNodeIds.Add(label);
	}

	/// <summary>
	/// Determines the starting point of this Edge. Uses labels only for reference.
	/// </summary>
	/// <param name="labels"></param>
	public void To(IEnumerable<String> labels)
	{
		ToNodeIds.AddRange(labels);
	}


	public List<Edge> ToConsecutively()
	{
		return null;
	}
}