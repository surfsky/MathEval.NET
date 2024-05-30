﻿using Org.MathEval.Functions;
using System;
using System.Collections.Generic;

namespace Org.MathEval.Nodes
{
    /// <summary>
    /// Create class CallFuncNode implements node
    /// Call function node, used to call function
    /// </summary>
    public class CallFuncNode : Node
    {
        /// <summary>
        /// Function Name
        /// </summary>
        public string FuncName;

        /// <summary>
        /// Excuter
        /// </summary>
        public IFunction Excuter;

        /// <summary>
        /// List node args
        /// </summary>
        public List<Node> Args;

        /// <summary>
        /// Initializes a new instance structure to a specified
        /// 1. Function Name
        /// 2. List Value args
        /// 3. Return type
        /// </summary>
        /// <param name="funcName">funcName</param>
        /// <param name="args">args</param>
        /// <param name="returnType">returnType</param>
        public CallFuncNode(string funcName, List<Nodes.Node> args, Type returnType, IFunction excuter) : base(returnType)
        {
            this.FuncName = funcName;
            this.Args = args;
            this.Excuter = excuter;
        }
    }
}
