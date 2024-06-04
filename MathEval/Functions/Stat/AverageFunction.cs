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
    /// average(1,2,3) -> 2
    /// new Afe_Evaluator('average(abc)').bind('abc',new List<Decimal>{1,2,3}).eval() -> 2
    /// </summary>
    public class AverageFunction : IFunction
    {
        /// <summary>Get Information</summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetDefs()
        {
            return new List<FunctionDef>{
                new FunctionDef(Consts.Average, typeof(decimal), -1, new Type[] { typeof(decimal) }),
                new FunctionDef(Consts.Average, typeof(decimal), 1, new Type[] { typeof(object) })};
        }

        /// <summary>Execute</summary>
        /// <param name="args">args</param>
        /// <param name="dc">expression context</param>
        /// <param name="funcName">function name</param>
        /// <returns>Value</returns>
        public object Execute(List<object> args, ExpressionContext dc, string funcName = "")
        {
            if (args.Count == 1 && Common.IsList(args[0]))
                return this.AvgList((IEnumerable)args[0], dc);
            return this.Avg(args, dc);
        }

        /// <summary>Avg</summary>
        private decimal Avg(List<object> args, ExpressionContext dc)
        {
            decimal sum = 0;
            foreach (Object item in args)
            {
                if(!Common.IsNumber(item))
                    throw new Exception(string.Format("{0} {1}", Consts.ShowMessage, "AVG"));
                sum += Common.ToDecimal(item, dc.Culture);
            }
            return sum / args.Count;
        }

        /// <summary>Average</summary>
        private decimal AvgList(IEnumerable arg, ExpressionContext dc)
        {
            decimal sum = 0;
            int elementCount = 0;

            foreach (Object item in arg)
            {
                if (Common.IsNumber(item))
                {
                    sum += Common.ToDecimal(item, dc.Culture);
                    elementCount++;
                }
            }
            return sum / elementCount;
        }
    }
}
