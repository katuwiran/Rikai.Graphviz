namespace Rikai.Graphviz.Builders;

/// <summary>
/// Class to build a Subgraph
/// </summary>
public class ClusterBuilder
{
	private readonly Cluster _cluster;
	private          string? _label;
	private          bool    _isCluster;

	public ClusterBuilder(string id, bool isCluster = false)
	{
		_cluster   = new Cluster(id);
		_isCluster = isCluster;

		_cluster.Attributes.IsCluster = _isCluster;
	}

	public ClusterBuilder(string id, string label, bool isCluster = false)
	{
		_cluster   = new Cluster(id, label);
		_label     = label;
		_isCluster = isCluster;

		_cluster.Attributes.Label     = _label;
		_cluster.Attributes.IsCluster = _isCluster;
	}

	public ClusterBuilder(Cluster cluster)
	{
		_cluster = cluster;
	}

	public ClusterBuilder WithAttributes(ClusterAttributes attributes)
	{
		_cluster.Attributes = attributes with { };

		if (_label is not null)
		{
			_cluster.Attributes.Label = _label;
		}

		if (_isCluster)
		{
			_cluster.Attributes.IsCluster = _isCluster;
		}

		return this;
	}

	public ClusterBuilder WithAttributes(Action<ClusterAttributeBuilder> configure)
	{
		var builder = new ClusterAttributeBuilder(_cluster.Attributes);
		configure(builder);

		if (_label is not null)
		{
			_cluster.Attributes.Label = _label;
		}

		if (_isCluster)
		{
			_cluster.Attributes.IsCluster = _isCluster;
		}

		return this;
	}

	public ClusterBuilder WithNodeAttributes(Action<NodeAttributeBuilder> configure)
	{
		// instantiates NodeAttributes
		var builder = new NodeAttributeBuilder(_cluster.Nodes.Attributes);

		// allows the user to configure this from the method call
		configure(builder);
		return this;
	}

	public ClusterBuilder WithEdgeAttributes(Action<EdgeAttributeBuilder> configure)
	{
		var builder = new EdgeAttributeBuilder(_cluster.Edges.Attributes);
		configure(builder);
		return this;
	}

	// adding Nodes, refer to Types/Collections/GraphNodes for details
	public ClusterBuilder AddNode(string id, NodeAttributes? attr = null)
	{
		if (attr is not null)
		{
			_cluster.Nodes.Add(new Node(id, attr));
		}

		_cluster.Nodes.Add(new Node(id));
		return this;
	}

	public ClusterBuilder AddNode(Node node, NodeAttributes? attr = null)
	{
		if (attr is not null)
		{
			node.Attributes = attr;
			_cluster.Nodes.Add(node);
		}

		_cluster.Nodes.Add(node);
		return this;
	}

	// node creator fully with fluent api
	public ClusterBuilder AddNode(string id, Action<NodeBuilder> configure)
	{
		NodeBuilder node;
		node = new NodeBuilder(id);
		configure(node);

		return this;
	}

	// node creator fully with fluent api
	public ClusterBuilder AddNode(string id, string label, Action<NodeBuilder> configure)
	{
		NodeBuilder node;
		node = new NodeBuilder(id, label);
		configure(node);
		return this;
	}


	public ClusterBuilder AddNodes(IEnumerable<string> ids)
	{
		_cluster.Nodes.AddIdRange(ids);
		return this;
	}

	public ClusterBuilder AddNodes(IEnumerable<Node> nodes)
	{
		_cluster.Nodes.AddRange(nodes);
		return this;
	}

	// adding Edges, refer to Types/Collections/GraphEdges for details
	public ClusterBuilder AddEdge(Node from, Node to)
	{
		_cluster.Edges.Add(new Edge(from, to));
		return this;
	}

	public ClusterBuilder AddEdge(Node from, IEnumerable<Node> to)
	{
		_cluster.Edges.Add(new Edge(from, to));
		return this;
	}

	public ClusterBuilder AddEdge(IEnumerable<Node> from, IEnumerable<Node> to)
	{
		_cluster.Edges.Add(new Edge(from, to));
		return this;
	}

	public ClusterBuilder AddEdge(IEnumerable<Node> from, Node to)
	{
		_cluster.Edges.Add(new Edge(from, to));
		return this;
	}

	public ClusterBuilder AddEdge(string from, string to)
	{
		_cluster.Edges.Add(new Edge(from, to));
		return this;
	}

	public ClusterBuilder AddEdge(string from, IEnumerable<string> to)
	{
		_cluster.Edges.Add(new Edge(from, to));
		return this;
	}

	public ClusterBuilder AddEdge(IEnumerable<string> from, IEnumerable<string> to)
	{
		_cluster.Edges.Add(new Edge(from, to));
		return this;
	}

	public ClusterBuilder AddEdge(IEnumerable<string> from, string to)
	{
		_cluster.Edges.Add(new Edge(from, to));
		return this;
	}

	public ClusterBuilder AddEdge(Edge edge)
	{
		_cluster.Edges.Add(edge);
		return this;
	}

	public ClusterBuilder AddEdges(IEnumerable<Edge> edges)
	{
		_cluster.Edges.AddRange(edges);
		return this;
	}

	public ClusterBuilder AddCluster(Cluster cluster)
	{
		_cluster.Clusters.Add(cluster);
		return this;
	}

	public ClusterBuilder AddClusters(IEnumerable<Cluster> clusters)
	{
		_cluster.Clusters.AddRange(clusters);
		return this;
	}

	public ClusterBuilder AddCluster(string id, string label, Action<ClusterBuilder>? configure = null, bool isCluster = true)
	{
		var builder = new ClusterBuilder(id, label, isCluster);

		if (configure is not null)
		{
			configure(builder);
			_cluster.Clusters.Add(builder.Build());
		}

		return this;
	}

	public ClusterBuilder AddHtml(string id, Action<HtmlTableBuilder> configure)
	{
		if (String.IsNullOrWhiteSpace(id))
		{
			throw new ArgumentNullException(nameof(id), "Html Tables must have an id.");
		}

		var builder = new HtmlTableBuilder(id);
		configure(builder);

		_cluster.HtmlTables.Add(builder.Build());
		return this;
	}

	/// <summary>
	/// Returns the Graph.
	/// </summary>
	/// <returns>Graph</returns>
	public Cluster Build()
	{
		return _cluster;
	}
}
