namespace Rikai.Graphviz.Builders
{
	/// <summary>
	/// Class to build a Node
	/// </summary>
	public class NodeBuilder
	{
		private readonly Node _node;

		/// <summary>
		/// Instantiates an empty GraphBuilder. Requires to pass the <c>GraphType</c> in the signature.
		/// </summary>
		/// <param name="id"></param>
		public NodeBuilder(string id)
		{
			_node = new(id);
		}

		/// <summary>
		/// Allows the user to configure the Node's  Attributes.
		/// This is the <c>id [attr=value]</c> syntax on the dot language.
		/// </summary>
		/// <param name="configure"></param>
		/// <returns></returns>
		public NodeBuilder WithAttributes(Action<NodeAttributeBuilder> configure)
		{
			var builder = new NodeAttributeBuilder(_node.Attributes);
			configure(builder);
			return this;
		}

		/// <summary>
		/// Returns the Graph.
		/// </summary>
		/// <returns>Graph</returns>
		public Node Build()
		{
			return _node;
		}
	}

	// --- SUB-BUILDERS FOR ATTRIBUTES ---
	// These abstract away direct property assignment into chainable methods.

	// (You would create a similar EdgeAttributeBuilder here)
}