namespace Rikai.Graphviz.Samples;

public class Program
{
	public static void Main()
	{
		string choice;
		int    choiceInt;

		Graph graph;

		while (true)
		{
			Console.WriteLine("Press a number to choose a graph");
			Console.WriteLine("1. Fluent");
			Console.WriteLine("2. Library Structure");
			Console.WriteLine("3. Syntax");
			Console.WriteLine("4. Readme");
			Console.WriteLine("5. Meta");
			Console.Write("Choose a number: ");

			choice = Console.ReadKey().KeyChar.ToString();

			if (Int32.TryParse(choice, out choiceInt))
			{
				switch (choiceInt)
				{
					case 1: graph = Graphs.Fluent(); break;
					case 2: graph = Graphs.LibraryStructure(); break;
					case 3: graph = Graphs.Syntax(); break;
					case 4: graph = Graphs.ReadMe(); break;
					case 5: graph = Graphs.Meta(); break;
					default:
						graph = Graphs.Mikotoba(); 
						break;
				}

				Console.WriteLine(graph);
				File.WriteAllText("out.dot", graph.ToString());
				break;
			}
			else
			{
				Console.WriteLine("Invalid input.");
			}
		}
	}
}
