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
    /// Variance(1,2,3) -> 1
    /// </summary>
    public class VarianceFunction : IFunction
    {
        /// <summary>Get Information</summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetDefs()
        {
            return new List<FunctionDef>{
                new FunctionDef(Consts.Variance, typeof(decimal), -1, typeof(decimal)),
                new FunctionDef(Consts.Variance, typeof(decimal), 1,  typeof(object))};
        }

        /// <summary>Execute</summary>
        /// <param name="args">args</param>
        /// <param name="dc">expression context</param>
        /// <param name="funcName">function name</param>
        /// <returns>Value</returns>
        public object Execute(List<object> args, ExpressionContext dc, string funcName = "")
        {
            if (args.Count == 1 && Common.IsList(args[0]))
                return this.VarianceList((IEnumerable)args[0], dc);
            return this.Variance(args, dc);
        }

        /// <summary>Avg</summary>
        private double Variance(List<object> args, ExpressionContext dc)
        {
            // 计算总和和平均值
            int n = args.Count;
            decimal sum = 0;
            foreach (object item in args)
            {
                if(!Common.IsNumber(item))
                    throw new Exception(string.Format("{0} {1}", Consts.ShowMessage, "AVG"));
                sum += Common.ToDecimal(item, dc.Culture);
            }
            double ave = (double)(sum / n);

            // 计算平方差的和
            double total = 0;
            foreach (object item in args)
            {
                var d = Common.ToDouble(item, dc.Culture);
                total += (d - ave) * (d - ave);
            }

            // 返回方差
            return total/n;
        }

        /// <summary>Average</summary>
        private double VarianceList(IEnumerable args, ExpressionContext dc)
        {
            // 计算总和和平均值
            var n = 0;
            decimal sum = 0;
            foreach (object item in args)
            {
                if (!Common.IsNumber(item))
                    throw new Exception(string.Format("{0} {1}", Consts.ShowMessage, "AVG"));
                sum += Common.ToDecimal(item, dc.Culture);
                n++;
            }
            double ave = (double)(sum / n);

            // 计算平方差的和
            double total = 0;
            foreach (object item in args)
            {
                var d = Common.ToDouble(item, dc.Culture);
                total += (d - ave) * (d - ave);
            }

            // 返回方差
            return total/n;
        }
    }
}
