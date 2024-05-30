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
using System.Globalization;
using System.Threading;

namespace Org.MathEval.Functions
{
    /// <summary>
    /// Returns the location of one text string inside another (case insensitive)
    /// SEARCH("A","ABC") -> 1
    /// SEARCH("A","AEHABC",4) -> 4
    /// </summary>
    public class SearchFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetDefs()
        {
            return new List<FunctionDef>{
                new FunctionDef(Consts.Search, typeof(decimal), new Type[] { typeof(string), typeof(string), typeof(decimal)}, 3),
                new FunctionDef(Consts.Search, typeof(decimal), new Type[] { typeof(string), typeof(string)}, 2)
            };
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="args">args</param>
        /// <param name="dc">dc</param>
        /// <returns>Value</returns>
        public Object Execute(Dictionary<int, Object> args, ExpressionContext dc)
        {
            int pos = searchFunc(args, dc);
            return pos >= 0 ? pos + 1 : pos;
        }

        /// <summary>
        /// Search Function
        /// </summary>
        /// <param name="args">args</param>
        /// <returns>Index</returns>
        public int searchFunc(Dictionary<int, Object> args, ExpressionContext dc)
        {
            int result;
            // because IndexOf uses the current culture info for string comparison
            var ci = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = dc.Culture;
            if (args.Count == 2)
            {
                result = Common.ToString(args[2], dc.Culture).ToLower(dc.Culture).IndexOf(Common.ToString(args[1], dc.Culture).ToLower(dc.Culture));
            }
            else
            {
                Decimal paramThree = Convert.ToDecimal(args[3], dc.Culture);
                String paramTwo = Common.ToString(args[2], dc.Culture);
                if (Decimal.ToInt32(paramThree) >= paramTwo.Length)
                {
                    return -1;
                }
                result = paramTwo.ToLower(dc.Culture).IndexOf(
                    Common.ToString(args[1], dc.Culture).ToLower(dc.Culture),
                    decimal.ToInt32(paramThree) - 1
                    );
            }

            Thread.CurrentThread.CurrentCulture = ci;
            return result;
        }
    }
}
