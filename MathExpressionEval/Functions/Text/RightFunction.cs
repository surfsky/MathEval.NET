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
    /// Extracts a given number of characters from 
    /// the right side of a supplied text string
    /// Example:
    /// RIGHT("abcd",3) -> bcd
    /// </summary>
    public class RightFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetDefs()
        {
            return new List<FunctionDef> { new FunctionDef(Consts.RIGHT, typeof(string), new Type[] { typeof(string), typeof(decimal) }, 2) };
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="args">args</param>
        /// <param name="dc">dc</param>
        /// <returns>Value</returns>
        public Object Execute(Dictionary<int, Object> args, ExpressionContext dc)
        {
            return this.Right(Common.ToString(args[1], dc.Culture), decimal.ToInt32(Common.ToDecimal(args[2], dc.Culture)));
        }

        /// <summary>
        /// Formula Right
        /// </summary>
        /// <param name="stringValue">stringValue</param>
        /// <param name="count">count</param>
        /// <returns>Value Right</returns>
        private string Right(string stringValue, int count)
        {
            if (!string.IsNullOrEmpty(stringValue))
            {
                int startIndex = stringValue.Length - count < 0 ? 0 : stringValue.Length - count;
                int endIndex = count > stringValue.Length ? stringValue.Length : count;
                return stringValue.Substring(startIndex, endIndex);
            }
            return string.Empty;
        }
    }
}
