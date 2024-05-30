using Org.MathEval.Operators;

namespace Org.MathEval.Nodes
{
    /// <summary>
    /// Create class UnaryNode implements node
    /// Unary node, used to hold unary operator
    /// </summary>
    public class UnaryNode : Node
    {
        /// <summary>
        /// Expr
        /// </summary>
        public Node Expr;

        /// <summary>
        /// Iop
        /// </summary>
        public IOperator Iop;

        /// <summary>
        /// Initializes a new instance structure to a specified type IOperator iop and type Node expr
        /// </summary>
        /// <param name="iop">iop</param>
        /// <param name="expr">expr</param>
        public UnaryNode(IOperator iop, Node expr) : base(typeof(decimal))
        {
            this.Iop = iop;
            this.Expr = expr;
        }
    }
}
