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
    public class BoolFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetDefs()
        {
            return new List<FunctionDef>{
                new FunctionDef(Consts.Bool, typeof(Boolean), new Type[] { typeof(string) }, 1),
                new FunctionDef(Consts.Bool, typeof(Boolean), new Type[] { typeof(decimal) }, 1)
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
            return this.ToBool(args[1]);
        }

        /// <summary>
        /// ToBool
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>Value ToBool</returns>
        private Boolean ToBool(Object value)
        {
            if (value is decimal)
            {
                return (decimal)value == 1;
            }
            else if (!(value.ToString().Equals("1") || value.ToString().Equals("0")))
            {
                throw new Exception(string.Format("{0} {1}", Consts.ShowMessage, "BOOL(), expect 1 or 0"));
            }
            return value.ToString().Equals("1");
        }
    }
}
