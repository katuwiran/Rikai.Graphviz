namespace Rikai.Graphviz;

public class Edge
{
	public List<string> FromNodeIds { get; set; } = new();
	public List<string> ToNodeIds   { get; set; } = new();
	public List<Node>   FromNodes   { get; set; } = new();
	public List<Node>   ToNodes     { get; set; } = new();

	public EdgeAttributes Attributes { get; set; }

	public Edge(Node from, Node to, EdgeAttributes? attributes = null)
	{
		FromNodes.Add(from);
		FromNodeIds.Add(to.Id);
		ToNodes.Add(to);
		ToNodeIds.Add(to.Id);
		Attributes = attributes is null ? new EdgeAttributes() : attributes;
	}

	public Edge(IEnumerable<Node> from, IEnumerable<Node> to, EdgeAttributes? attributes = null)
	{
		FromNodes.AddRange(from);
		FromNodeIds.AddRange(from.Select(n => n.Id).ToList());
		ToNodes.AddRange(to);
		Attributes = attributes is null ? new EdgeAttributes() : attributes;
	}

	public Edge(Node from, IEnumerable<Node> to, EdgeAttributes? attributes = null)
	{
		FromNodes.Add(from);
		FromNodeIds.Add(from.Id);
		ToNodes.AddRange(to);
		ToNodeIds.AddRange(to.Select(n => n.Id).ToList());
		Attributes = attributes is null ? new EdgeAttributes() : attributes;
	}

	public Edge(IEnumerable<Node> from, Node to, EdgeAttributes? attributes = null)
	{
		FromNodes.AddRange(from);
		FromNodeIds.AddRange(from.Select(n => n.Id).ToList());
		ToNodes.Add(to);
		ToNodeIds.Add(to.Id);
		Attributes = attributes is null ? new EdgeAttributes() : attributes;
	}

	public Edge(string from, string to, EdgeAttributes? attributes = null)
	{
		FromNodeIds.Add(from);
		ToNodeIds.Add(to);
		Attributes = attributes is null ? new EdgeAttributes() : attributes;
	}

	public Edge(IEnumerable<string> from, IEnumerable<string> to, EdgeAttributes? attributes = null)
	{
		FromNodeIds.AddRange(from);
		ToNodeIds.AddRange(to);
		Attributes = attributes is null ? new EdgeAttributes() : attributes;
	}

	public Edge(string from, IEnumerable<string> to, EdgeAttributes? attributes = null)
	{
		FromNodeIds.Add(from);
		ToNodeIds.AddRange(to);
		Attributes = attributes is null ? new EdgeAttributes() : attributes;
	}

	public Edge(IEnumerable<string> from, string to, EdgeAttributes? attributes = null)
	{
		FromNodeIds.AddRange(from);
		ToNodeIds.Add(to);
		Attributes = attributes is null ? new EdgeAttributes() : attributes;
	}

	public Edge()
	{
		Attributes = new EdgeAttributes();
	}
}
