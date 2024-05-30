namespace Org.MathEval.Nodes
{
    /// <summary>
    /// Nullnode, used to hold null value
    /// </summary>
    public class NullNode : Node
    {
        /// <summary>
        /// Initializes a new instance
        /// </summary>
        /// <param name="numberVal">numberVal</param>
       // public NullNode() : base(typeof(int))
        public NullNode() : base(typeof(object))
        {
        }
    }
}
