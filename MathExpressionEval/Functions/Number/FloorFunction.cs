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
using System.Collections.Generic;

namespace Org.MathEval.Functions
{
    /// <summary>
    /// Returns the largest integral value less than or equal to the specified number.
    /// FLOOR(3.7) -> 3
    /// FLOOR(3.7,2) -> 2
    /// FLOOR(1.58,0.1) -> 1.5
    /// FLOOR(0.234,0.01) -> 0.23
    /// FLOOR(-2.5,-2) -> -2
    /// </summary>
    public class FloorFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetDefs()
        {
            return new List<FunctionDef>{
                new FunctionDef(Consts.Floor, typeof(decimal), 1, new System.Type[]{ typeof(decimal) }),
                new FunctionDef(Consts.Floor, typeof(decimal), 2, new System.Type[] { typeof(decimal), typeof(decimal) })
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
            return this.Floor(args, dc);
        }

        /// <summary>
        /// Floor
        /// </summary>
        /// <param name="args">args</param>
        /// <returns>Value Floor</returns>
        public decimal Floor(Dictionary<int, Object> args, ExpressionContext dc)
        {
            if (args.Count == 1)
            {
                return Math.Floor(Common.ToDecimal(args[1], dc.Culture));
            }
            else
            {
                return Math.Floor(Common.ToDecimal(args[1], dc.Culture) / Common.ToDecimal(args[2], dc.Culture)) * Common.ToDecimal(args[2], dc.Culture);
            }
        }
    }
}
