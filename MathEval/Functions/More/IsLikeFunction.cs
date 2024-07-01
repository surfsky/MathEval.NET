/*
    The MIT License
    surfsky@sina.com 2024-05
*/
using Org.MathEval;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Org.MathEval.Functions
{
    /// <summary>
    /// Combines the text from multiple strings
    /// LIKE("Abc","_bc") -> true
    /// LIKE("Abc","*b*") -> true
    /// LIKE("Abc","%b%") -> true
    /// </summary>
    public class IsLikeFunction : IFunction
    {
        /// <summary>Get Information</summary>
        public List<FunctionDef> GetDefs()
        {
            return new List<FunctionDef> { 
                new FunctionDef("ISLIKE", typeof(bool), 2, typeof(string), typeof(string)) 
            };
        }

        /// <summary>Execute</summary>
        /// <param name="args">args</param>
        /// <param name="dc">expression context</param>
        /// <param name="funcName">function name</param>
        /// <returns>Value</returns>
        public object Execute(List<object> args, ExpressionContext dc, string funcName = "")
        {
            var text = args[0].ToString();
            var likeExpression = args[1].ToString();
            if (string.IsNullOrEmpty(likeExpression))
                return true;
            else
            {
                likeExpression = likeExpression.Replace("*", ".*");
                likeExpression = likeExpression.Replace("%", ".*");
                likeExpression = likeExpression.Replace("_", ".{1}");
                Regex regex = new Regex(likeExpression, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                return regex.Match(text).Success;
            }
        }
    }
}
