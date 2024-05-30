namespace Org.MathEval.Nodes
{
    /// <summary>
    /// Create class IfElseNode implements node
    /// Condition node, used to hold condition
    /// </summary>
    public class IfElseNode : Node
    {
        /// <summary>
        /// Node Condition
        /// </summary>
        public Node Condition;

        /// <summary>
        /// Node have value is true
        /// </summary>
        public Node IfTrue;

        /// <summary>
        /// Node have value is false
        /// </summary>
        public Node IfFalse;

        /// <summary>
        /// Initializes a new instance structure to a specified
        /// 1. Node Condition
        /// 2. Node have value is true
        /// 3. Node have value is false
        /// 4. Type return
        /// </summary>
        /// <param name="condition">condition</param>
        /// <param name="ifTrue">ifTrue</param>
        /// <param name="ifFalse">ifFalse</param>
        /// <param name="returnType">returnType</param>
        public IfElseNode(Node condition, Node ifTrue, Node ifFalse, System.Type returnType) : base(returnType)
        {
            this.Condition = condition;
            this.IfTrue = ifTrue;
            this.IfFalse = ifFalse;
        }
    }
}
