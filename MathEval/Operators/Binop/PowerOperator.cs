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
using static Org.MathEval.Common;

namespace Org.MathEval.Operators.Binop
{
    /// <summary>
    /// Definition for power operator
    /// Examples:
    /// -2^2 -> -4
    /// -2^3^-4 -> -1.008594
    /// 3^2 -> 9
    /// </summary>
    public class PowerOperator : AbstractBinOperator
    {
        /// <summary>
        /// Initializes a new instance structure to a specified type string value and type int value and value assoc
        /// </summary>
        /// <param name="op">op</param>
        /// <param name="precedence">precedence</param>
        /// <param name="assoc">assoc</param>
        public PowerOperator(string op, int precedence, Assoc assoc) : base(op, precedence, assoc)
        {
        }

        /// <summary>
        /// Calculate result
        /// </summary>
        /// <param name="left">left</param>
        /// <param name="right">right</param>
        /// <param name="dc">dc</param>
        /// <returns>value Calculate</returns>
        public override object Calculate(object left, object right, ExpressionContext dc)
        {
            //if (left is decimal && right is decimal)
            if (Common.IsNumber(left) && Common.IsNumber(right))
                {
                // double result = Math.Pow(Convert.ToDouble(left), Convert.ToDouble(right));
                // return Math.Round(Convert.ToDecimal(result), dc.Scale, dc.Rd);
                Double result = Math.Pow(Convert.ToDouble(left, dc.Culture), Convert.ToDouble(right, dc.Culture));
                return Convert.ToDecimal(result, dc.Culture);
            }

            throw new Exception(string.Format(Consts.MSG_WRONG_OP_PARAM_EX, new string[] { "POWER", "numeric" }));
        }

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="typeLeft">typeLeft</param>
        /// <param name="typeRight">typeRight</param>
        /// <returns>Type</returns>
        public override Type Validate(Type typeLeft, Type typeRight)
        {
            if (
                (typeLeft.Equals(typeof(decimal)) || typeLeft.Equals(typeof(object)))
                &&
                (typeRight.Equals(typeof(decimal)) || typeRight.Equals(typeof(object)))
                )
            {
                return typeof(decimal);
            }
            return null;
        }
    }
}
