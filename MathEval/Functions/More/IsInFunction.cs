/*
    The MIT License
    surfsky@sina.com 2024-05
*/
using Org.MathEval;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Org.MathEval.Functions
{
    /// <summary>
    /// Judge whether first item is in the subsequency items.
    /// IsIn("A","A","B","C") -> true
    /// IsIn("A", ["A", "B", "C"]) -> true
    /// IsIn("A", "A,B,C") -> true
    /// </summary>
    public class IsInFunction : IFunction
    {
        /// <summary>Get Information</summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetDefs()
        {
            return new List<FunctionDef> { new FunctionDef("IsIn", typeof(bool), -1, new Type[] { typeof(object) }) };
        }

        /// <summary>Execute</summary>
        public object Execute(List<object> args, ExpressionContext dc, string funcName = "")
        {
            string first = args[0].ToString();


            /// IsIn("A", ["A", "B", "C"]) -> true
            if (args.Count == 2 && args[1] is IList)
            {
                foreach (object o in args[1] as IList)
                {
                    if (first == o.ToString())
                        return true;
                }
            }
            /// IsIn("A", "A,B,C") -> true
            else if (args.Count == 2 && args[1] is string)
            {
                var sperators = new char[] { ',', ';', ' ', '\t', '，', '、' };
                var texts = args[1].ToString().Split(sperators, StringSplitOptions.RemoveEmptyEntries);
                foreach (var text in texts)
                {
                    if (first == text)
                        return true;
                }
            }
            /// IsIn("A","A","B", "C") -> true
            else
            {
                for (int i = 1; i < args.Count; i++)
                {
                    if (first == args[i].ToString())
                        return true;
                }
            }
            return false;
        }
    }
}
