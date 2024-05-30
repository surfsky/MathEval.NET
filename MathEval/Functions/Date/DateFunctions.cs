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
using static Org.MathEval.Common;

namespace Org.MathEval.Functions
{
    /// <summary>
    /// DateTime functions
    /// </summary>
    public class DateFunctions : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetDefs()
        {
            return new List<FunctionDef> {
                new FunctionDef("today",      typeof(DateTime), 0, null),
                new FunctionDef("now",        typeof(DateTime), 0, null),
                new FunctionDef("year",       typeof(int),      1, typeof(DateTime)),
                new FunctionDef("month",      typeof(int),      1, typeof(DateTime)),
                new FunctionDef("day",        typeof(int),      1, typeof(DateTime)),
                new FunctionDef("hour",       typeof(int),      1, typeof(DateTime)),
                new FunctionDef("minute",     typeof(int),      1, typeof(DateTime)),
                new FunctionDef("second",     typeof(int),      1, typeof(DateTime)),
                new FunctionDef("weekday",    typeof(DayOfWeek),1, typeof(DateTime)),
                new FunctionDef("AddYears",   typeof(DateTime), 2, typeof(DateTime), typeof(int)),
                new FunctionDef("AddMonths",  typeof(DateTime), 2, typeof(DateTime), typeof(int)),
                new FunctionDef("AddDays",    typeof(DateTime), 2, typeof(DateTime), typeof(int)),
                new FunctionDef("AddHours",   typeof(DateTime), 2, typeof(DateTime), typeof(int)),
                new FunctionDef("AddMinutes", typeof(DateTime), 2, typeof(DateTime), typeof(int)),
                new FunctionDef("AddSeconds", typeof(DateTime), 2, typeof(DateTime), typeof(int)),
                new FunctionDef("AddDate",    typeof(DateTime), 7, typeof(DateTime), typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(int)),
            };
        }

        /// <summary>Execute</summary>
        /// <param name="args">args</param>
        /// <param name="dc">expression context</param>
        /// <param name="funcName">function name</param>
        /// <returns>Value</returns>
        public object Execute(List<object> args, ExpressionContext dc, string funcName = "")
        {
            var name = funcName.ToLower();
            switch (name)
            {
                case "today":      return DateTime.Today;
                case "now":        return DateTime.Now;
                case "year":       return ToDateTime(args[0]).Year;
                case "month":      return ToDateTime(args[0]).Month;
                case "day":        return ToDateTime(args[0]).Day;
                case "hour":       return ToDateTime(args[0]).Hour;
                case "minute":     return ToDateTime(args[0]).Minute;
                case "second":     return ToDateTime(args[0]).Second;
                case "weekday":    return ToDateTime(args[0]).DayOfWeek;
                case "addyears":   return ToDateTime(args[0]).AddYears(ToInt(args[1]));
                case "addmonths":  return ToDateTime(args[0]).AddMonths(ToInt(args[1]));
                case "adddays":    return ToDateTime(args[0]).AddDays(ToInt(args[1]));
                case "addhours":   return ToDateTime(args[0]).AddHours(ToInt(args[1]));
                case "addminutes": return ToDateTime(args[0]).AddMinutes(ToInt(args[1]));
                case "addseconds": return ToDateTime(args[0]).AddSeconds(ToInt(args[1]));
                case "adddate":    return AddDate(ToDateTime(args[0]), ToInt(args[1]), ToInt(args[2]), ToInt(args[3]), ToInt(args[4]), ToInt(args[5]), ToInt(args[6]));
            }
            return DateTime.Now;
        }

        DateTime AddDate(DateTime date, int years, int months, int days, int hours, int minutes, int seconds)
        {
            return date.AddYears(years).AddMonths(months).AddDays(days).AddHours(hours).AddMinutes(minutes).AddSeconds(seconds);
        }
    }
}
