namespace Org.MathEval.Nodes
{
    /// <summary>
    /// Stringnode, used to hold string value
    /// </summary>
    public class StringNode : Node
    {
        /// <summary>
        /// Value
        /// </summary>
        public string Value;

        /// <summary>
        /// Initializes a new instance structure to a specified type string value
        /// </summary>
        /// <param name="value">value</param>
        public StringNode(string value) : base(typeof(string))
        {
            this.Value = value;
        }
    }
}
