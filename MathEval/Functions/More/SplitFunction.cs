/*
    The MIT License
    surfsky@sina.com 2024-05
*/
using Org.MathEval;
using Org.MathEval.Nodes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Org.MathEval.Functions
{
    /// <summary>
    /// Split string with seperator.
    /// split("a,b,c") => string[]{'a', 'b', 'c'}
    /// split("a,b,c", ",") => string[]{'a', 'b', 'c'}
    /// </summary>
    public class SplitFunction : IFunction
    {
        /// <summary>Get function define information</summary>
        public List<FunctionDef> GetDefs()
        {
            return new List<FunctionDef> { 
                new FunctionDef("Split",   typeof(string[]), 1, typeof(string)),
                new FunctionDef("Split",   typeof(string[]), 2, typeof(string), typeof(string)),
            };
        }

        /// <summary>Execute</summary>
        public object Execute(List<object> args, ExpressionContext dc, string funcName = "")
        {
            var seps = new char[] { ',', '|', ';', ' ', '\t', '，', '、' };
            if (args.Count == 2)
                seps = args[1].ToString().ToCharArray();

            return args[0].ToString().Split(seps, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
