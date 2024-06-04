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
    /// Count(1,2,3) -> 3
    /// new Evaluator('count(abc)').bind('abc',new List<decimal>{1,2,3}).eval() -> 3
    /// </summary>
    public class CountFunction : IFunction
    {
        /// <summary>Get Information</summary>
        public List<FunctionDef> GetDefs()
        {
            return new List<FunctionDef>{
                new FunctionDef(Consts.Count, typeof(int), -1, typeof(object) ),
                new FunctionDef(Consts.Count, typeof(int), 1,  typeof(object)  )
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
                return CountList((IEnumerable)args[0]);

            return args.Count;
        }


        /// <summary>Sum</summary>
        private int CountList(IEnumerable args)
        {
            int n = 0;
            foreach (object item in args)
                n++;
            return n;
        }

    }
}
