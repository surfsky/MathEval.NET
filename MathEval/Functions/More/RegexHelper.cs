using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


/*
    The MIT License
    surfsky@sina.com 2024-05
*/
namespace Org.MathEval.Functions
{
    internal static class RegexHelper
    {
        //------------------------------------------------------
        // Common regex functions
        //------------------------------------------------------
        /// <summary>Find all matched texts by regex</summary>
        public static List<string> Find(this string text, string pattern)
        {
            List<string> list = new List<string>();
            if (!string.IsNullOrEmpty(text))
            {
                MatchCollection matchCollection = Regex.Matches(text, pattern);
                foreach (Match item in matchCollection)
                {
                    list.Add(item.Value);
                }
            }

            return list;
        }

        /// <summary>Find first matched text by regex</summary>
        public static string FindFirst(this string text, string pattern, string part = "")
        {
            if (string.IsNullOrEmpty(text))
                return "";

            Match match = Regex.Match(text, pattern);
            if (!match.Success)
                return "";

            if (string.IsNullOrEmpty(part))
                return match.Value;

            if (!part.StartsWith("$"))
                part = "${" + part + "}";
            return match.Result(part);
        }

        /// <summary>Find  matched text and join them</summary>
        public static string FindJoin(this string text, string pattern)
        {
            return text.Find(pattern).JoinString();
        }

        /// <summary>Join string</summary>
        public static string JoinString(this IEnumerable data)
        {
            var sb = new StringBuilder();
            foreach (object o in data)
                sb.Append(o.ToString());
            return sb.ToString();
        }

        /// <summary>Cast source list to another type list</summary>
        public static List<T> Cast<T>(this IEnumerable source, Func<object, T> func)
        {
            List<T> list = new List<T>();
            if (source != null)
            {
                foreach (object item in source)
                    list.Add(func(item));
            }
            return list;
        }



        //------------------------------------------------------
        // Find special text
        //------------------------------------------------------
        /// <summary>Find first number by regex</summary>
        public static string FindNumber(this string text)
        {
            return text.FindFirst("(-)?\\d+(\\.\\d+)?");
        }


        /// <summary>Find all numbers by regex</summary>
        public static List<decimal> FindNumbers(this string text)
        {
            return text.Find("(-)?\\d+(\\.\\d+)?").Cast<decimal>(t => decimal.Parse(t.ToString()));
        }


        /// <summary>Find all texts</summary>
        public static string FindChars(this string text)
        {
            return text.FindJoin("[A-Za-z\\u4e00-\\u9fa5]");
        }

        /// <summary>Find enghish text</summary>
        public static string FindEnglishChars(this string text)
        {
            return text.FindJoin("[A-Za-z]");
        }

        /// <summary>Find chinese text</summary>
        public static string FindChineseChars(this string text)
        {
            return text.FindJoin("[\\u4e00-\\u9fa5]");
        }


        /// <summary>Find mobile text</summary>
        public static string FindChinesedMobile(this string text)
        {
            return text.FindFirst("\\d{11}");
        }


        /// <summary>Find and translate to chinese number</summary>
        public static string ToChineseNumber(this string text)
        {
            decimal num = FindDecimal(text);
            return ChineseDecimalHelper.ToChineseBigNumber(num);
        }

        /// <summary>Find decimal number</summary>
        public static decimal FindDecimal(this string text)
        {
            return Decimal.Parse(text.FindFirst("(-)?\\d+(\\.\\d+)?"));
        }
    }
}