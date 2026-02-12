using System.Text;

namespace Rikai.Graphviz.DotFormat;

public class DotGenerator
{
	Graph               _graph  { get; init; }
	private GraphParser _parser { get; init; } = new();


	string GraphAttributes { get; set; }
	string GraphNodes      { get; set; }
	string GraphEdges      { get; set; }

	public void Print()
	{
		string dot =
			$$"""
			  {{_parser.Parse(_graph.Type)}} {
			  {{_parser.Parse(_graph.Edges)}}
			  }
			  """;
		Console.WriteLine(dot);
	}


	public DotGenerator(Graph graph)
	{
		_graph = graph;
	}
}