namespace Rikai.Graphviz;

public class Edge
{
	public List<string> FromNodeIds { get; set; } = new();
	public List<string> ToNodeIds   { get; set; } = new();
	public List<Node>   FromNodes   { get; set; } = new();
	public List<Node>   ToNodes     { get; set; } = new();
	
	public EdgeAttributes Attributes { get; set; } = new();

	/// <summary>
	/// Determines the starting point of this Edge. Uses predefined nodes for Ids.
	/// </summary>
	/// <param name="node"></param>
	/// <returns>Edge</returns>
	public Edge From(Node node)
	{
		FromNodes.Add(node);
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
		FromNodes.AddRange(nodes);
		FromNodeIds.AddRange(nodes.Select(n => n.Id).ToList());
		return this;
	}

	/// <summary>
	/// Determines the end point of this Edge. Uses predefined nodes for Ids.
	/// </summary>
	/// <param name="node"></param>
	public void To(Node node)
	{
		FromNodes.Add(node);
		FromNodeIds.Add(node.Id);
	}

	/// <summary>
	/// Determines the starting point of this Edge. Uses predefined nodes for Ids.
	/// </summary>
	/// <param name="nodes"></param>
	public void To(IEnumerable<Node> nodes)
	{
		ToNodes.AddRange(nodes);
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

	public Edge(Node from, Node to)
	{
		FromNodes.Add(from);
		FromNodeIds.Add(to.Id);
		ToNodes.Add(to);
		ToNodeIds.Add(to.Id);
	}

	public Edge(IEnumerable<Node> from, IEnumerable<Node> to)
	{
		FromNodes.AddRange(from);
		FromNodeIds.AddRange(from.Select(n => n.Id).ToList());
		ToNodes.AddRange(to);
	}

	public Edge(Node from, IEnumerable<Node> to)
	{
		FromNodes.Add(from);
		FromNodeIds.Add(from.Id);
		ToNodes.AddRange(to);
		ToNodeIds.AddRange(to.Select(n => n.Id).ToList());
	}

	public Edge(IEnumerable<Node> from, Node to)
	{
		FromNodes.AddRange(from);
		FromNodeIds.AddRange(from.Select(n => n.Id).ToList());
		ToNodes.Add(to);
		ToNodeIds.Add(to.Id);
	}

	public Edge(string from, string to)
	{
		FromNodeIds.Add(from);
		ToNodeIds.Add(to);
	}

	public Edge(IEnumerable<string> from, IEnumerable<string> to)
	{
		FromNodeIds.AddRange(from);
		ToNodeIds.AddRange(to);
	}

	public Edge(string from, IEnumerable<string> to)
	{
		FromNodeIds.Add(from);
		ToNodeIds.AddRange(to);
	}

	public Edge(IEnumerable<string> from, string to)
	{
		FromNodeIds.AddRange(from);
		ToNodeIds.Add(to);
	}

	public List<Edge> ToConsecutively()
	{
		return null;
	}

	public Edge()
	{
	}
}