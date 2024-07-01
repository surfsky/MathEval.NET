/*
    The MIT License
    surfsky@sina.com 2024-05
*/
using Org.MathEval;
using System;
using System.Collections.Generic;
using static Org.MathEval.Common;

namespace Org.MathEval.Functions
{
    /// <summary>
    /// Judge whether first item is in the subsequency items.
    /// IsBetween("A","A","B") -> true
    /// IsBetween("2021-01-02","2021-01-01","2021-02-01") -> true
    /// </summary>
    public class IsBetweenFunction : IFunction
    {
        /// <summary>Get Information</summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetDefs()
        {
            return new List<FunctionDef> { 
                new FunctionDef("IsBetween", typeof(bool), 3, typeof(DateTime), typeof(DateTime), typeof(DateTime)) ,
                new FunctionDef("IsBetween", typeof(bool), 3, typeof(string), typeof(string), typeof(string)),
                new FunctionDef("IsBetween", typeof(bool), 3, typeof(decimal), typeof(decimal), typeof(decimal))
            };
        }

        /// <summary>Execute</summary>
        public object Execute(List<object> args, ExpressionContext dc, string funcName = "")
        {
            var type = args[0].GetType();
            if (type == typeof(string))
            {
                var v0 = args[0].ToString();
                var v1 = args[1].ToString();
                var v2 = args[2].ToString();
                return v0.CompareTo(v1)>=0 && v0.CompareTo(v2)<=0;
            }
            else if (type == typeof(DateTime))
            {
                var v0 = ToDateTime(args[0]);
                var v1 = ToDateTime(args[1]);
                var v2 = ToDateTime(args[2]);
                return v0 >= v1 && v0 <= v2;
            }
            else if (type == typeof(decimal) || type == typeof(float) || type == typeof(double)
                || type == typeof(int) || type == typeof(long) || type == typeof(uint) || type == typeof(ulong)
                )
            {
                var v0 = ToDecimal(args[0], dc.Culture);
                var v1 = ToDecimal(args[1], dc.Culture);
                var v2 = ToDecimal(args[2], dc.Culture);
                return v0 >= v1 && v0 <= v2;
            }
            return false;
        }
    }
}
