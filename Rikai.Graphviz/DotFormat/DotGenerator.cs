using System.Text;

namespace Rikai.Graphviz.DotFormat;

public partial class DotGenerator
{
	internal int           Indent     { get; set; } = 1;
	internal StringBuilder Sb         { get; set; } = new();
	internal Graph         Graph      { get; init; }
	internal string        Type       { get; init; }
	internal string        EdgeSymbol { get; init; }

	public DotGenerator(Graph graph)
	{
		Graph      = graph;
		Type       = graph.Type == GraphType.Directed ? "digraph" : "graph";
		EdgeSymbol = graph.Type == GraphType.Directed ? "->" : "--";
	}

	public string Generate()
	{
		var formatter = new GraphFormatter(this);

		Sb.AppendLine(Type + "{");
		formatter.FormatGraphAttributes();
		formatter.FormatGraphNodeAttributes();
		formatter.FormatGraphEdgeAttributes();
		formatter.FormatGraphClusters();
		formatter.FormatGraphTables();
		formatter.FormatGraphNodes();
		formatter.FormatGraphEdges();
		Sb.AppendLine("}");

		return Sb.ToString();
	}

	public override string ToString()
	{
		string result = Generate();
		// {{Formatter.ParseGraphAttributes(_graph.Attributes)}}
		// {{Formatter.ParseGraphNodeAttributes(_graph.Nodes.Attributes)}}
		// {{Formatter.ParseGraphEdgeAttributes(_graph.Edges.Attributes)}}
		// {{Formatter.ParseGraphNodes(Graph.Nodes)}}
		// {{Formatter.ParseGraphEdges(Graph.Edges)}}
		// return OldGraphFormatter.RemoveEmptyLines(result);
		return result;
	}

	public void Print()
	{
		Console.WriteLine(ToString());
	}
}
