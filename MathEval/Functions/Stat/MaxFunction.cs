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
    /// MAX(1,2,3) -> 3
    /// new Afe_Evaluator('MAX(abc)').bind('abc',new List<Decimal>{1,2,3}).eval() -> 3
    /// </summary>
    public class MaxFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetDefs()
        {
            return new List<FunctionDef>{
                new FunctionDef(Consts.Max, typeof(decimal), -1, new Type[] { typeof(decimal) }),
                new FunctionDef(Consts.Max, typeof(decimal), 1, new Type[] { typeof(Object) })
            };
        }

        /// <summary>Execute</summary>
        /// <param name="args">args</param>
        /// <param name="dc">expression context</param>
        /// <param name="funcName">function name</param>
        /// <returns>Value</returns>
        public object Execute(List<object> args, ExpressionContext dc, string funcName = "")
        {
            if (args.Count == 1 && Common.IsList(args[0]))
            {
                return this.MaxList((IEnumerable)args[0], dc);
            }
            return this.Max(args, dc);
        }

        /// <summary>
        /// Max
        /// </summary>
        /// <param name="args">args</param>
        /// <returns>Value Max</returns>
        private Object Max(List<object> args, ExpressionContext dc)
        {
            Object maxEntry = null;
            foreach (Object item in args)
            {
                if (maxEntry == null || Common.ToDecimal(item, dc.Culture) > (decimal)maxEntry)
                {
                    maxEntry = Common.ToDecimal(item, dc.Culture);
                }
            }
            return maxEntry;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private Object MaxList(IEnumerable arg, ExpressionContext dc)
        {
            Object maxEntry = null;
            foreach (Object item in arg)
            {
                if (!Common.IsNumber(item))
                {
                    continue;
                }
                if (maxEntry == null || Common.ToDecimal(item, dc.Culture) > (decimal)maxEntry)
                {
                    maxEntry = Common.ToDecimal(item, dc.Culture);
                }
            }
            return maxEntry;
        }
    }
}
