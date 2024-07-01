/*
    The MIT License
    surfsky@sina.com 2024-05
*/
using Org.MathEval;
using Org.MathEval.Nodes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Org.MathEval.Functions
{
    /// <summary>
    /// Text extension functions.
    /// 
    /// contains('abcd', 'a') -> true
    /// regex('abc13df', '/d.*') -> 13
    /// regexs('abc13def26ghi33', '/d.*') -> ['13', '26', '33']
    /// number('abc13d') -> 13
    /// numbers('abc13def26ghi33') -> [13, 26, 33]
    /// alltext('abc13def26ghi33中文') -> 'abcdefghi中文'
    /// entext('abc13def26ghi33中文')  -> 'abcdefghi'
    /// cntext('abc13def26ghi33中文')  -> '中文'
    /// cnmobile('abc15305770001sss') -> '15305770001'
    /// cnnumber('abc1530sss') -> '壹仟伍佰叁拾'
    /// </summary>
    public class TextFunctions : IFunction
    {
        public List<FunctionDef> GetDefs()
        {
            return new List<FunctionDef>()
            {
                new FunctionDef("Contains", typeof(bool),   2, typeof(string), typeof(string)),
                new FunctionDef("Regex",    typeof(string), 2, typeof(string)),
                new FunctionDef("Regexs",   typeof(IList),  2, typeof(string)),
                new FunctionDef("Number",   typeof(string), 1, typeof(string)),
                new FunctionDef("Numbers",  typeof(IList),  1, typeof(string)),
                new FunctionDef("AllText",  typeof(string), 1, typeof(string)),
                new FunctionDef("EnText",   typeof(string), 1, typeof(string)),
                new FunctionDef("CnText",   typeof(string), 1, typeof(string)),
                new FunctionDef("CnMobile", typeof(string), 1, typeof(string)),
                new FunctionDef("CnNumber", typeof(string), 1, typeof(string)),
            };
        }

        public object Execute(List<object> args, ExpressionContext dc, string funcName = "")
        {
            var text = args[0].ToString();
            var name = funcName.ToLower();
            switch (name)
            {
                case "contains":        return text.Contains(args[1].ToString());
                case "regex":           return text.Find(args[1].ToString()).FirstOrDefault();
                case "regexs":          return text.Find(args[1].ToString());
                case "number":          return text.FindNumber();
                case "numbers":         return text.FindNumbers();
                case "alltext":         return text.FindChars();
                case "entext":          return text.FindEnglishChars();
                case "cntext":          return text.FindChineseChars();
                case "cnmobile":        return text.FindChinesedMobile();
                case "cnnumber":        return text.FindDecimal().ToChineseBigNumber();
            }
            return args[0].ToString();
        }
    }
}
