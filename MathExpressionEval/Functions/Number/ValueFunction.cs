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
    /// Convert text to a numeric value
    /// VALUE("123") -> 123
    /// VALUE(123) -> 123
    /// </summary>
    public class ValueFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetDefs()
        {
            return new List<FunctionDef> { 
                new FunctionDef(Consts.Value, typeof(decimal), new Type[] { typeof(Object) }, 1) 
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
            if (Common.IsNumber(args[1]))
            {
                return Common.Round(Common.ToDecimal(args[1], dc.Culture), dc);
            }

            else if (args[1] is TimeSpan)
            {
                TimeSpan ts = (TimeSpan)args[1];
                return Common.Round(ts.TotalMilliseconds / 1000 / 60 / 60 / 24, dc);
            }

            else if (args[1] is DateTime)
            {
                DateTime dt = (DateTime)args[1];
                long ms = (long)(dt - new DateTime(1970, 1, 1)).TotalMilliseconds;
                return Common.Round(ms / 1000 / 60 / 60 / 24, dc);
            }
            else
            {
                try
                {
                    return Common.Round(Common.ToDecimal(args[1], dc.Culture), dc);
                }
                catch(Exception e)
                {
                    throw new Exception(string.Format(Consts.MSG_METH_PARAM_INVALID, (object[])(new string[] { "value" })));
                }
            }
            
        }
    }
}
