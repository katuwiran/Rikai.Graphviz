namespace Rikai.Graphviz.Builders;

/// <summary>
/// Class to build an Edge
/// </summary>
public class EdgeBuilder
{
	private readonly Edge _edge;

	/// <summary>
	/// Instantiates an empty EdgeBuilder.
	/// </summary>
	public EdgeBuilder()
	{
		_edge = new Edge();
	}

	public EdgeBuilder From(string nodeId)
	{
		_edge.FromNodeIds.Add(nodeId);
		return this;
	}

	public EdgeBuilder From(Node node)
	{
		_edge.FromNodes.Add(node);
		return this;
	}

	public EdgeBuilder From(IEnumerable<string> nodeIds)
	{
		_edge.FromNodeIds.AddRange(nodeIds);
		return this;
	}

	public EdgeBuilder From(IEnumerable<Node> nodes)
	{
		_edge.FromNodes.AddRange(nodes);
		return this;
	}

	public EdgeBuilder To(string nodeId)
	{
		_edge.ToNodeIds.Add(nodeId);
		return this;
	}

	public EdgeBuilder To(Node node)
	{
		_edge.ToNodes.Add(node);
		return this;
	}

	public EdgeBuilder To(IEnumerable<string> nodeIds)
	{
		_edge.ToNodeIds.AddRange(nodeIds);
		return this;
	}

	public EdgeBuilder To(IEnumerable<Node> nodes)
	{
		_edge.ToNodes.AddRange(nodes);
		return this;
	}

	/// <summary>
	/// Allows the user to configure the Node's  Attributes.
	/// This is the <c>id [attr=value]</c> syntax on the dot language.
	/// </summary>
	/// <param name="configure"></param>
	/// <returns></returns>
	public EdgeBuilder WithAttributes(Action<EdgeAttributeBuilder> configure)
	{
		var builder = new EdgeAttributeBuilder(_edge.Attributes);
		configure(builder);
		return this;
	}

	/// <summary>
	/// Returns the Edge.
	/// </summary>
	/// <returns>Edge</returns>
	public Edge Build()
	{
		if (!_edge.FromNodes.Any() && !_edge.FromNodeIds.Any())
		{
			throw new NullReferenceException("An edge was built but doesn't have any `from` nodes");
		}

		if (!_edge.ToNodes.Any() && !_edge.ToNodeIds.Any())
		{
			throw new NullReferenceException("An edge was built but doesn't have any `to` nodes");
		}

		return _edge;
	}
}

// --- SUB-BUILDERS FOR ATTRIBUTES ---
// These abstract away direct property assignment into chainable methods.

// (You would create a similar EdgeAttributeBuilder here)
