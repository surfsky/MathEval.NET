﻿/*
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
    /// Extracts a given number of characters 
    /// from the middle of a supplied text string
    /// MID("abcd",1,2) -> ab
    /// </summary>
    public class MidFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetDefs()
        {
            return new List<FunctionDef> { new FunctionDef(Consts.MID, typeof(string), new System.Type[] { typeof(string), typeof(decimal), typeof(decimal) }, 3) };
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="args">args</param>
        /// <param name="dc">dc</param>
        /// <returns>Value</returns>
        public Object Execute(Dictionary<int, Object> args, ExpressionContext dc)
        {
            
            return this.Mid(
                Common.ToString(args[1], dc.Culture),
                decimal.ToInt32(Common.ToDecimal(args[2], dc.Culture)),
                decimal.ToInt32(Common.ToDecimal(args[3], dc.Culture))
                );
        }

        /// <summary>
        /// Formula Mid
        /// </summary>
        /// <param name="stringValue">stringValue</param>
        /// <param name="index">index</param>
        /// <param name="length">length</param>
        /// <returns>Value get at mid</returns>
        private string Mid(string stringValue, int index, int length)
        {
            if (!string.IsNullOrEmpty(stringValue) && index > 0 && index <= stringValue.Length)
            {
                int len = index + length > stringValue.Length ? stringValue.Length - index + 1 : length;
                return stringValue.Substring(index - 1, len);
            }
            return string.Empty;
        }
    }
}
