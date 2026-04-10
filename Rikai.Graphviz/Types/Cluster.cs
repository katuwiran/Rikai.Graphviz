namespace Rikai.Graphviz;

public class Cluster
{
	public ClusterAttributes Attributes { get; set; } = new();
	public string            Id         { get; set; }
	public string?           Label      { get; set; }

	public ClusterNodes  Nodes    { get; } = new();
	public ClusterEdges  Edges    { get; }
	public GraphClusters Clusters { get; set; } = new();

	public Cluster(string id)
	{
		Id    = id;
		Edges = new(this);
	}

	public Cluster(string id, string label)
	{
		Id    = id;
		Label = label;
		Edges = new(this);
	}
}