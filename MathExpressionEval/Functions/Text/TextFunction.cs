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
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

namespace Org.MathEval.Functions
{
    /// <summary>
    /// Convert a numeric value, datetime value into a text string
    /// TEXT(123) -> 123 (string)
    /// TEXT(DATEVALUE("2021-01-23"),"dd-MM-yyyy") -> 23-01-2021 (string)
    /// TEXT(2.61,"hh:mm") -> 14:38 (string)
    /// TEXT(2.61,"[hh]") -> 62 (string)
    /// TEXT(0.1,"h") -> 2 (string)
    /// TEXT(2.61,"[mm]") -> 3758 (string)
    /// TEXT(2.61,"hh-mm-ss") -> 14-38-24 (string)
    /// TEXT(DATEVALUE("2021-01-03")-DATEVALUE("2021-01-01"),"[h]") -> 48 (string)
    /// TEXT(TIME(12,00,00)-TIME(10,30,10),"hh hours and mm minutes and ss seconds") -> "01 hours and 29 minutes and 50 seconds"
    /// </summary>
    public class TextFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetDefs()
        {
            return new List<FunctionDef>{
                new FunctionDef(Consts.Text, typeof(string), new Type[] { typeof(Object) }, 1),
                new FunctionDef(Consts.Text, typeof(string), new Type[] { typeof(Object), typeof(string)}, 2)
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
            if (args.Count == 2)
            {
                string pattern = Common.ToString(args[2], dc.Culture);
                if (args[1] is decimal)
                {
                    // because Contains uses IndexOf that uses the current culture info for string comparison
                    var ci = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = dc.Culture;
                    string ret = pattern;
                    decimal t = Common.ToDecimal(args[1], dc.Culture);
                    // Hours
                    if (pattern.ToLower(dc.Culture).Contains("[hh]"))
                    {
                        decimal hh = Common.Round(t * 24, dc);
                        ret = Regex.Replace(ret, "\\[[hH]{2,2}\\]", ((int)hh).ToString(dc.Culture).PadLeft(2, '0'));
                    }
                    else if (pattern.ToLower(dc.Culture).Contains("hh"))
                    {
                        decimal hh = Common.Round((t - (int)(t)) * 24, dc);
                        ret = Regex.Replace(ret, "[hH]{2,2}", ((int)hh).ToString(dc.Culture).PadLeft(2, '0'));
                    }
                    else if (pattern.ToLower(dc.Culture).Contains("[h]"))
                    {
                        decimal hh = Common.Round(t * 24, dc);
                        ret = Regex.Replace(ret, "\\[[hH]{1,1}\\]", ((int)hh).ToString(dc.Culture));
                    }
                    else if (pattern.ToLower(dc.Culture).Contains("h"))
                    {
                        decimal hh = Common.Round((t - (int)(t)) * 24, dc);
                        ret = Regex.Replace(ret, "[hH]{1,1}", ((int)hh).ToString(dc.Culture));
                    }
                    //minute
                    if (pattern.Contains("[mm]"))
                    {
                        decimal hh = Common.Round(t * 24 * 60, dc);
                        ret = Regex.Replace(ret, "\\[[m]{2,2}\\]", ((int)hh).ToString(dc.Culture).PadLeft(2, '0'));
                    }
                    else if (pattern.Contains("mm"))
                    {
                        decimal hh = Common.Round(((t * 24) - (int)(t * 24)) * 60, dc);
                        ret = Regex.Replace(ret, "[m]{2,2}", ((int)hh).ToString(dc.Culture).PadLeft(2, '0'));
                    }
                    else if (pattern.Contains("[m]"))
                    {
                        decimal hh = Common.Round(t * 24 * 60, dc);
                        ret = Regex.Replace(ret, "\\[[m]{1,1}\\]", ((int)hh).ToString(dc.Culture));
                    }
                    else if (pattern.Contains("m"))
                    {
                        decimal hh = Common.Round(((t * 24) - (int)(t * 24)) * 60, dc);
                        ret = Regex.Replace(ret, "[m]{1,1}", ((int)hh).ToString(dc.Culture));
                    }
                    //sec
                    if (pattern.ToLower(dc.Culture).Contains("[ss]"))
                    {
                        decimal hh = Common.Round(t * 24 * 60 * 60, dc);
                        ret = Regex.Replace(ret, "\\[[s]{2,2}\\]", ((int)hh).ToString(dc.Culture).PadLeft(2, '0'));
                    }
                    else if (pattern.ToLower(dc.Culture).Contains("ss"))
                    {
                        decimal hh = Common.Round(
                            ((t * 24m * 60m) - decimal.ToInt32((t * 24m * 60m))) * 60m,
                            dc);
                        ret = Regex.Replace(ret, "[s]{2,2}", (decimal.ToInt32(hh)).ToString(dc.Culture).PadLeft(2, '0'));
                    }
                    else if (pattern.ToLower(dc.Culture).Contains("[s]"))
                    {
                        decimal hh = Common.Round(t * 24 * 60 * 60, dc);
                        ret = Regex.Replace(ret, "\\[[s]{1,1}\\]", ((int)hh).ToString(dc.Culture));
                    }
                    else if (pattern.ToLower(dc.Culture).Contains("s"))
                    {
                        decimal hh = Common.Round(
                            ((t * 24 * 60) - (int)(t * 24 * 60)) * 60,
                            dc);
                        ret = Regex.Replace(ret, @"[sS]{1,1}", ((int)hh).ToString(dc.Culture));
                    }
                    if (ret != null && ret.Equals(pattern))
                    {
                        Thread.CurrentThread.CurrentCulture = ci;
                        return t.ToString(pattern, dc.Culture);
                    }
                    Thread.CurrentThread.CurrentCulture = ci;
                    return ret;
                }
            }

            return Common.ToString(args[1], dc.Culture);
        }
    }
}
