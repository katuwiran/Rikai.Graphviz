namespace Rikai.Graphviz.Builders;

/// <summary>
/// Class to build a Graph
/// </summary>
public class GraphBuilder
{
	private readonly Graph _graph;

	/// <summary>
	/// Instantiates an empty GraphBuilder. Requires to pass the <c>GraphType</c> in the signature.
	/// </summary>
	/// <param name="type"></param>
	public GraphBuilder(GraphType type)
	{
		_graph = new Graph { Type = type };
	}

	/// <summary>
	/// Instantiates GraphBuilder from a predefined grah. Requires to pass the <c>GraphType</c> in the signature.
	/// </summary>
	/// <param name="graph"></param>
	public GraphBuilder(Graph graph)
	{
		_graph = graph;
	}

	/// <summary>
	/// Allows the user to configure the Graph Attributes.
	/// This is the <c>graph [attr=value]</c> syntax on the dot language.
	/// </summary>
	/// <param name="configure"></param>
	/// <returns></returns>
	public GraphBuilder WithAttributes(Action<GraphAttributeBuilder> configure)
	{
		var builder = new GraphAttributeBuilder(_graph.Attributes);
		configure(builder);
		return this;
	}

	/// <summary>
	/// Allows the user to configure the Default Node Attributes.
	/// This is the <c>node [attr=value]</c> syntax on the dot language.
	/// </summary>
	/// <param name="configure"></param>
	/// <returns></returns>
	public GraphBuilder WithNodeAttributes(Action<NodeAttributeBuilder> configure)
	{
		// instantiates NodeAttributes
		var builder = new NodeAttributeBuilder(_graph.Nodes.Attributes);

		// allows the user to configure this from the method call
		configure(builder);
		return this;
	}

	/// <summary>
	/// Allows the user to configure the Default Edge Attributes.
	/// This is the `edge [attr=value]` syntax on the dot language.
	/// </summary>
	/// <param name="configure"></param>
	/// <returns></returns>
	public GraphBuilder WithEdgeAttributes(Action<EdgeAttributeBuilder> configure)
	{
		var builder = new EdgeAttributeBuilder(_graph.Edges.Attributes);
		configure(builder);
		return this;
	}

	// adding Nodes, refer to Types/Collections/GraphNodes for details
	public GraphBuilder AddNode(string id, NodeAttributes? attr = null)
	{
		if (attr is not null)
		{
			_graph.Nodes.Add(new Node(id, attr));
		}

		_graph.Nodes.Add(new Node(id));
		return this;
	}

	public GraphBuilder AddNode(Node node, NodeAttributes? attr = null)
	{
		if (attr is not null)
		{
			node.Attributes = attr;
			_graph.Nodes.Add(node);
		}

		_graph.Nodes.Add(node);
		return this;
	}

	// node creator fully with fluent api
	public GraphBuilder AddNode(string id, Action<NodeBuilder> configure)
	{
		NodeBuilder node;
		node = new NodeBuilder(id);
		configure(node);

		return this;
	}

	// node creator fully with fluent api
	public GraphBuilder AddNode(string id, string label, Action<NodeBuilder> configure)
	{
		NodeBuilder node;
		node = new NodeBuilder(id, label);
		configure(node);
		return this;
	}

	public GraphBuilder AddNodes(IEnumerable<string> ids)
	{
		_graph.Nodes.AddIdRange(ids);
		return this;
	}

	public GraphBuilder AddNodes(IEnumerable<Node> nodes)
	{
		_graph.Nodes.AddRange(nodes);
		return this;
	}

	// adding Edges, refer to Types/Collections/GraphEdges for details
	public GraphBuilder AddEdge(Node from, Node to)
	{
		_graph.Edges.Add(new Edge(from, to));
		return this;
	}

	public GraphBuilder AddEdge(Node from, IEnumerable<Node> to)
	{
		_graph.Edges.Add(new Edge(from, to));
		return this;
	}

	public GraphBuilder AddEdge(IEnumerable<Node> from, IEnumerable<Node> to)
	{
		_graph.Edges.Add(new Edge(from, to));
		return this;
	}

	public GraphBuilder AddEdge(IEnumerable<Node> from, Node to)
	{
		_graph.Edges.Add(new Edge(from, to));
		return this;
	}

	public GraphBuilder AddEdge(string from, string to)
	{
		_graph.Edges.Add(new Edge(from, to));
		return this;
	}

	public GraphBuilder AddEdge(string from, IEnumerable<string> to)
	{
		_graph.Edges.Add(new Edge(from, to));
		return this;
	}

	public GraphBuilder AddEdge(IEnumerable<string> from, IEnumerable<string> to)
	{
		_graph.Edges.Add(new Edge(from, to));
		return this;
	}

	public GraphBuilder AddEdge(IEnumerable<string> from, string to)
	{
		_graph.Edges.Add(new Edge(from, to));
		return this;
	}

	public GraphBuilder AddEdge(Edge edge)
	{
		_graph.Edges.Add(edge);
		return this;
	}

	public GraphBuilder AddEdges(IEnumerable<Edge> edges)
	{
		_graph.Edges.AddRange(edges);
		return this;
	}

	public GraphBuilder AddCluster(string id, string label, bool isCluster = true, Action<ClusterBuilder>? configure = null)
	{
		var builder = new ClusterBuilder(id, label, isCluster);

		if (configure is not null)
		{
			configure(builder);
		}

		_graph.Clusters.Add(builder.Build());
		return this;
	}

	public GraphBuilder AddCluster(Cluster cluster)
	{
		_graph.Clusters.Add(cluster);
		return this;
	}

	public GraphBuilder AddClusters(List<Cluster> clusters)
	{
		_graph.Clusters.AddRange(clusters);
		return this;
	}

	public GraphBuilder AddHtml(HtmlTable htmlTable)
	{
		_graph.Tables.Add(htmlTable);

		return this;
	}

	/// <summary>
	/// Returns the Graph.
	/// </summary>
	/// <returns>Graph</returns>
	public Graph Build()
	{
		return _graph;
	}
}
