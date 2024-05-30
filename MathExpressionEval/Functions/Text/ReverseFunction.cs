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
    /// Reverse a string
    /// REVERSE("abcd") -> dcba
    /// </summary>
    public class ReverseFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetDefs()
        {
            return new List<FunctionDef> { 
                new FunctionDef(Consts.Reverse, typeof(string), new Type[] { typeof(string) }, 1) 
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
            return this.Reverse(Common.ToString(args[1], dc.Culture));
        }

        /// <summary>
        /// Formula Reverse
        /// </summary>
        /// <param name="str">str</param>
        /// <returns>Value Reverse</returns>
        private string Reverse(string str)
        {
            if (str.Length > 0)
            {
                return str[str.Length - 1] + Reverse(str.Substring(0, str.Length - 1));
            }
            else
            {
                return str;
            }
        }
    }
}
