using Org.MathEval.Operators;
using System;

namespace Org.MathEval.Nodes
{
    /// <summary>
    /// Create class BinanyNode implements node
    /// </summary>
    public class BinanyNode : Node
    {
        /// <summary>   
        /// Node Left
        /// </summary>
        public Node LHS;

        /// <summary>
        /// Node Right
        /// </summary>
        public Node RHS;

        /// <summary>
        /// iOp
        /// </summary>
        public IOperator iOp;

        /// <summary>
        /// Initializes a new instance structure to a specified
        /// 1. IOperator value
        /// 2. Node left
        /// 3. Node right
        /// 4. Return type
        /// </summary>
        /// <param name="iop">iop</param>
        /// <param name="lhs">lhs</param>
        /// <param name="rhs">rhs</param>
        /// <param name="returnType">returnType</param>
        public BinanyNode(IOperator iop, Node lhs, Node rhs, Type returnType) : base(returnType)
        {
            this.iOp = iop;
            this.LHS = lhs;
            this.RHS = rhs;
        }
    }
}
