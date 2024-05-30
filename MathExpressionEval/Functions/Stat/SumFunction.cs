/*
    The MIT License

    Copyright (c) 2021 MathEval.org

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
*/
using Org.MathEval;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Org.MathEval.Functions
{
    /// <summary>
    /// SUM(1,2,3) -> 6
    /// new Evaluator('SUM(abc)').bind('abc',new List<decimal>{1,2,3}).eval() -> 6
    /// </summary>
    public class SumFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetDefs()
        {
            return new List<FunctionDef>{
                new FunctionDef(Consts.Sum, typeof(decimal), -1, new Type[] { typeof(decimal) }),
                new FunctionDef(Consts.Sum, typeof(decimal), 1, new Type[] { typeof(Object) })
            };
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="args">args</param>
        /// <param name="dc">dc</param>
        /// <returns>Value</returns>
        /// <param name="funcName"></param>
        public Object Execute(Dictionary<int, Object> args, ExpressionContext dc, string funcName = "")
        {
            if (args.Count == 1 && Common.IsList(args[1]))
            {
                return this.SumList((IEnumerable)args[1], dc);
            }
            return this.Sum(args, dc);
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="args">args</param>
        /// <returns>Value Sum</returns>
        private decimal Sum(Dictionary<int, Object> args, ExpressionContext dc)
        {
            decimal sum = 0;
            foreach (Object item in args.Values)
            {
                sum += Common.ToDecimal(item, dc.Culture);
            }
            return sum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private decimal SumList(IEnumerable arg, ExpressionContext dc)
        {
            decimal sum = 0;
            foreach (Object item in arg)
            {
                if (Common.IsNumber(item))
                {
                    sum += Common.ToDecimal(item, dc.Culture);
                }
            }
            return sum;
        }

    }
}
