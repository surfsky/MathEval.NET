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
    /// Replaces characters specified by location 
    /// in a given text string with another text string
    /// REPLACE("ABC123",4,3,"456") -> ABC456
    /// REPLACE("ABC123",1,3,"45") -> 45123
    /// REPLACE("123-455-3321","-","") -> 1234553321
    /// </summary>
    public class ReplaceFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetDefs()
        {
            return new List<FunctionDef>{
                new FunctionDef(Consts.Replace, typeof(string), 3, new System.Type[] { typeof(string), typeof(string), typeof(string) }),
                new FunctionDef(Consts.Replace, typeof(string), 4, new System.Type[] { typeof(string), typeof(decimal), typeof(decimal), typeof(string) })
            };
        }

        /// <summary>Execute</summary>
        /// <param name="args">args</param>
        /// <param name="dc">expression context</param>
        /// <param name="funcName">function name</param>
        /// <returns>Value</returns>
        public object Execute(List<object> args, ExpressionContext dc, string funcName = "")
        {
            if (args.Count == 3)
            {
                return Common.ToString(args[0], dc.Culture).Replace(Common.ToString(args[1], dc.Culture), Common.ToString(args[2], dc.Culture));
            }
            else
            {
                string text = Common.ToString(args[0], dc.Culture);
                string left = text.Substring(0, decimal.ToInt32(Common.ToDecimal(args[1], dc.Culture)) - 1);
                string right = text.Substring(decimal.ToInt32(Common.ToDecimal(args[1], dc.Culture)) - 1 + decimal.ToInt32(Common.ToDecimal(args[2], dc.Culture)));
                return left + args[3].ToString() + right;
            }
        }
    }
}
