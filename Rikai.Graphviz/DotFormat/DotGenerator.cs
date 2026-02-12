using System.Text;

namespace Rikai.Graphviz;

public class DotGenerator
{
	Graph               _graph  { get; init; }
	private GraphParser _parser { get; init; } = new();


	string GraphAttributes { get; set; }
	string GraphNodes      { get; set; }
	string GraphEdges      { get; set; }

	public DotGenerator(Graph graph)
	{
		_graph = graph;
	}

	public override string ToString()
	{
		return
			$$"""
			  {{_parser.ParseGraphType(_graph.Type)}} {
			  {{_parser.ParseGraphAttributes(_graph.Attributes)}}
			  {{_parser.ParseGraphNodeAttributes(_graph.Nodes.Attributes)}}
			  {{_parser.ParseGraphEdgeAttributes(_graph.Edges.Attributes)}}
			  {{_parser.ParseGraphEdges(_graph.Edges)}}
			  }
			  """;
	}
	
	public void Print()
	{
		Console.WriteLine(this.ToString());
	}

}