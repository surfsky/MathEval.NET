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
    /// Combine to text by seperator.
    /// combine(",", [1,2,3]) -> "1,2,3"
    /// combine(",", 1,2,3) -> "1,2,3"
    /// </summary>
    public class SplitCombineFunction : IFunction
    {
        /// <summary>Get function define information</summary>
        public List<FunctionDef> GetDefs()
        {
            return new List<FunctionDef> { 
                new FunctionDef("Combine", typeof(string), -1, typeof(object))
            };
        }

        /// <summary>Execute</summary>
        public object Execute(List<object> args, ExpressionContext dc, string funcName = "")
        {
            var result = "";
            var sep = args[0].ToString();

            /// combine(",", [1,2,3]) -> "1,2,3"
            if (args[1] is IList)
            {
                foreach (string txt in args[1] as IList)
                {
                    result += txt + sep;
                }
            }

            /// combine(",", 1,2,3) -> "1,2,3"
            else
            {
                for (int i = 1; i < args.Count; i++)
                {
                    result += args[i].ToString() + sep;
                }
            }

            // clear tail
            int n = result.LastIndexOf(sep);
            if (n != -1)
                return result.Substring(0, n);
            return result;
        }
    }
}
