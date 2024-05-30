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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Org.MathEval
{
    #region Enum

    /// <summary>
    /// Create enum Assoc have value is 0.LEFT and 1.RIGHT
    /// </summary>
    public enum Assoc
    {
        LEFT,
        RIGHT
    }

    /// <summary>
    /// Type token
    /// </summary>
    public enum TokenType
    {
        TOKEN_ASCII,
        TOKEN_NUMBER_DECIMAL,
        TOKEN_BOOL,
        TOKEN_STRING,
        TOKEN_IDENTIFIER,
        TOKEN_PAREN_OPEN,
        TOKEN_PAREN_CLOSE,
        TOKEN_COMMA,
        TOKEN_OP,
        TOKEN_UOP,
        TOKEN_IF,
        TOKEN_CASE,
        TOKEN_EOF
    }

    #endregion

    /// <summary>
    /// 
    /// </summary>
    public static class Common
    {

        #region Key

        #endregion

        #region Function

        /// <summary>To first-char-upper-camel text.</summary>
        public static string ToCamelUpper(this string text)
        {
            if (String.IsNullOrEmpty(text))
                return "";
            if (text.Length == 1)
                return text.ToUpper();
            return text.Substring(0, 1).ToUpper() + text.Substring(1).ToLower();
        }

        /// <summary>
        /// A string extension method that query if value is Alpha.
        /// </summary>
        /// <param name="value">The value to act on.</param>
        /// <returns>true if Alpha, false if not.</returns>
        public static bool IsAlpha(char value)
        {
            Regex rg = new Regex(@"^[a-zA-Z_]+$");
            return rg.IsMatch(value.ToString());
        }

        /// <summary>
        /// A string extension method that query if value is IsAlphaNumeric.
        /// </summary>
        /// <param name="value">The value to act on.</param>
        /// <returns>true if IsAlphaNumeric, false if not.</returns>
        public static bool IsAlphaNumeric(char value)
        {
            Regex rg = new Regex(@"^[a-zA-Z0-9_]+$");
            return rg.IsMatch(value.ToString());
        }

        /// <summary>
        /// A string extension method that query if value is isNumeric.
        /// </summary>
        /// <param name="value">The value to act on.</param>
        /// <returns>true if IsNumeric, false if not.</returns>
        public static bool IsNumeric(char value)
        {
            Regex rg = new Regex(@"^[0-9]+$");
            return rg.IsMatch(value.ToString());
        }

        /// <summary>
        /// Formula Right
        /// </summary>
        /// <param name="stringValue">stringValue</param>
        /// <param name="count">count</param>
        /// <returns>Value Right</returns>
        public static string Right(string stringValue, int count)
        {
            if (!string.IsNullOrEmpty(stringValue))
            {
                return stringValue.Substring(stringValue.Length - count, count);
            }
            return string.Empty;
        }

        /// <summary>
        /// Round
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="dc">dc</param>
        /// <returns>Value Round</returns>
        public static decimal Round(object value, ExpressionContext dc)
        {
            return Math.Round(Convert.ToDecimal(value, dc.Culture), dc.Scale, dc.Rd);
        }

        /// <summary>
        /// Check object is number instance
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumber(object value)
        {
            return value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is float
                    || value is double
                    || value is decimal;
        }

        /// <summary>
        /// TODO poner default invariant culture.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object value, CultureInfo cultureInfo)
        {
            if (value is decimal)
            {
                return (decimal)value;
            }
            else
            {
                return Convert.ToDecimal(value, cultureInfo);
            }
        }

        /// <summary>
        /// Connvert object to string
        /// TODO poner default invariant culture.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static string ToString(object value, CultureInfo cultureInfo)
        {
            if (value is string)
            {
                return (string)value;
            }
            else
            {
                return Convert.ToString(value, cultureInfo);
            }
        }



        /// <summary>
        /// Check object instance of List
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool IsList(object o)
        {
            if (o == null) return false;
            return o is IList &&
                   o.GetType().IsGenericType &&
                   o.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
        }

        /// <summary>
        /// Round Manual Scale
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="dc">dc</param>
        /// <returns>Value Round</returns>
        public static decimal RoundManualScale(object value, object digit, ExpressionContext dc)
        {
            return Math.Round((decimal)value, (int)digit, dc.Rd);
        }

        /// <summary>
        /// DateDif
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="unit">unit</param>
        /// <returns>Total Value</returns>
        public static int DateDif(DateTime startDate, DateTime endDate, string unit)
        {
            // TODO: 
            if (unit != null && unit.Equals("d", StringComparison.InvariantCultureIgnoreCase))
            {
                return (endDate - startDate).Days;
            }
            else if (unit != null && unit.Equals("m", StringComparison.InvariantCultureIgnoreCase))
            {
                int monthDiff = endDate.Year * 12 + endDate.Month - (startDate.Year * 12 + startDate.Month);
                if (endDate.Day < startDate.Day)
                {
                    monthDiff--;
                }
                return monthDiff;
            }
            else if (unit != null && unit.Equals("y", StringComparison.InvariantCultureIgnoreCase))
            {
                int monthDiff = endDate.Year * 12 + endDate.Month - (startDate.Year * 12 + startDate.Month);
                if (endDate.Day < startDate.Day)
                {
                    monthDiff--;
                }
                return monthDiff / 12;
            }
            else if (unit != null && unit.Equals("ym", StringComparison.InvariantCultureIgnoreCase))
            {
                DateTime stDate = startDate;
                int yearDiff = DateDif(startDate, endDate, "y");
                stDate = stDate.AddYears(yearDiff);
                return DateDif(stDate, endDate, "m");
            }
            else if (unit != null && unit.Equals("yd", StringComparison.InvariantCultureIgnoreCase))
            {
                DateTime stDate = startDate;
                int yearDiff = DateDif(startDate, endDate, "y");
                stDate = stDate.AddYears(yearDiff);
                return DateDif(stDate, endDate, "d");
            }
            else if (unit != null && unit.Equals("md", StringComparison.InvariantCultureIgnoreCase))
            {
                DateTime stDate = startDate;
                int mDiff = DateDif(startDate, endDate, "m");
                stDate = stDate.AddMonths(mDiff);
                return DateDif(stDate, endDate, "d");
            }
            throw new Exception("Please set M or D or Y for UNIT param");
        }

        #endregion


    }
}
